###############################################################################
### Taking sys arguments

# import sys
# num_samples = int(sys.argv[1]) if len(sys.argv) > 1 else 100

###############################################################################
### MLFlow setup

import mlflow

# Comment out below line to use the local tracking server.
mlflow.set_tracking_uri("http://training.itu.dk:5000/")

# Set Experiment Name
mlflow.set_experiment("miejo - Testing")

# Credentials for logging artifacts
import os
os.environ["MLFLOW_S3_ENDPOINT_URL"] = "http://130.226.140.28:5000"
os.environ["AWS_ACCESS_KEY_ID"] = "training-bucket-access-key"
os.environ["AWS_SECRET_ACCESS_KEY"] = "tqvdSsEDnBWTDuGkZYVsRKnTeu"

###############################################################################
### Imports

import script.processing as processing

import pandas as pd
import numpy as np
import pickle

from sklearn.pipeline import Pipeline
from sklearn.preprocessing import StandardScaler
from sklearn.tree import DecisionTreeRegressor
from sklearn.kernel_ridge import KernelRidge
from sklearn.svm import SVR
from sklearn.model_selection import TimeSeriesSplit
from sklearn.metrics import mean_squared_error, mean_absolute_error, r2_score

###############################################################################
### SPECIFIC USECASE HELPERS

def load_and_drop(fpath, include_prints=False):
    """
    Loads dataset and drops irrelevant columns + nan rows
    if include_prints is set to True, also print some relevant line-counts that 
    can be used to evaluate whether the function drops columns with only few
    missing values, that could have been interpolated.
    """
    # Loading data
    df = pd.read_json(fpath, orient="split")

    # Dropping unneccessary columns
    df.drop(['ANM', 'Non-ANM', 'Lead_hours', 'Source_time'], axis=1, inplace=True)

    # Handle missing data
    if include_prints:
        print('Direction nulls: ', sum(df['Direction'].isnull()))
        print('Speed nulls: ', sum(df['Speed'].isnull()))
        print('Total nulls: ', sum(df['Total'].isnull()))
        print('\nTotal number of lines: ', df.shape[0])

    # We drop all nans (weather data seems to be missing on the same lines, thus no "unneccessary" loss of data)
    df.dropna(inplace=True)

    if include_prints:
        print('\nNEW Total number of lines: ', df.shape[0])

    return df

def test_hyper_param(model, parameter, df):
    """
    This model takes 1 models, the name of a hyper-parameter and list of values 
    to test. Furthermore, it expects to get the data in a pandas Dataframe. 
    The function initiates, fits and tests a whole pipeline, which preprocesses 
    and calculates predictions.

    Metrics that are logged; MAE, MSE & R2 
    Parameters that are logged; Model name & hyper parameter value
    """
    for i in parameter[1]:
        with mlflow.start_run(run_name=f'{model[0]} with {parameter[0]} = {i}'):
            pipeline = Pipeline([
                ('Direction Feature Encoding', processing.DirectionTransformer()),
                ('Scaling', StandardScaler()),
                ('Classifier', model[1])
            ])
            setattr(pipeline.steps[2][1], parameter[0], i)

            metrics = [
                ("MAE", mean_absolute_error, []),
                ("MSE", mean_squared_error, []),
                ("R2", r2_score, [])
            ]

            X = df[["Speed","Direction"]]
            y = df["Total"]

            number_of_splits = 5

            mlflow.log_param('model', model[0])
            mlflow.log_param(parameter[0], i)
            
            for train, test in TimeSeriesSplit(number_of_splits).split(X,y):
                pipeline.fit(X.iloc[train],y.iloc[train])
                predictions = pipeline.predict(X.iloc[test])
                truth = y.iloc[test]
                
                # Calculate and save the metrics for this fold
                for name, func, scores in metrics:
                    score = func(truth, predictions)
                    scores.append(score)
            
            mean_scores = []
            # Log a summary of the metrics
            for name, _, scores in metrics:
                    mean_score = sum(scores)/number_of_splits
                    mean_scores.append(mean_score)
                    mlflow.log_metric(f"mean_{name}", mean_score)
                    mlflow.log_metric(f"min_{name}", min(scores))
                    mlflow.log_metric(f"max_{name}", max(scores))
    return pipeline, mean_scores, model[0]

###############################################################################
### APPLICATIONS

def tracking_experiment(return_best=False, evaluation=2):
    if return_best:
        started=False

    ## Loading and cleaning Data
    df = load_and_drop("data/dataset.json")

    ## Defining models and parameters to test
    models = [['Decision Tree', DecisionTreeRegressor()], 
            ['Ridge Kernel', KernelRidge(kernel='polynomial')],
            ['Support Vector Regression', SVR(kernel='poly')]]
    parameters = [['min_samples', [1, 5, 10, 20, 40, 80, 160, 320, 500, 1000, 1500, 2000, 2500, 3000, 3500]], 
                ['degree', [1, 2, 3, 4, 5, 6]],
                ['degree', [1, 2, 3, 4, 5, 6]]]
    
    ## Testing parameters, logging experiment runs & evaluating best models
    for model, parameter in zip(models, parameters):
        model, scores, name = test_hyper_param(model, parameter, df)
        if return_best:
            if started:
                if best[1] < scores[evaluation]:
                    best = [model, scores[evaluation], name]
            else:
                best = [model, scores[evaluation], name]
                started = True
    
    if return_best:
        return df, best
    return df


###############################################################################
### MAIN

def main():
    df, msn = tracking_experiment(return_best=True)
    m, s, n = msn

    X = df[["Speed","Direction"]]
    y = df["Total"]

    # print("logging best model - current run")
    # with mlflow.start_run(run_name=f'logging best model (current run)'):
    #     mlflow.sklearn.log_model(m, 'models')
    #     mlflow.log_param('Model Name', n)
    #     mlflow.log_metric('Score', s)

    print("loading old best and saving best of bests")
    with open('models/best_model.pkl', 'rb') as file:
        om = pickle.load(file)

    preds = m.predict(X.iloc[-20:])
    opreds = om.predict(X.iloc[-20:])
    r2 = r2_score(y.iloc[-20:], preds)
    or2 = r2_score(y.iloc[-20:], opreds)
    if r2 > or2:
        print('New Model is better - Deprecating old')
        with open('models/best_model.pkl', 'wb') as file:
            pickle.dump(m, file)
        with open(f'models/depr_{str(np.datetime64("now", "h"))}.pkl', 'wb') as file:
            pickle.dump(om, file)
    else:
        print('Old Model is still best - no deprecation needed')

if __name__ == "__main__":
    main()