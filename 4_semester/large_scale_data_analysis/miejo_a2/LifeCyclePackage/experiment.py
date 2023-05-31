import pickle
import sys
import pandas as pd

def parse_arguments():
    """
    Parsing and grabbing the relevant arguments
    """
    return [float(sys.argv[1]), sys.argv[2]]

def main():
    # Take arguments from commandline
    data = pd.DataFrame([parse_arguments()], columns=['Speed', 'Direction'])
    
    # Load Best pickled Model from folder
    with open('models/best_model.pkl', 'rb') as file:
        model = pickle.load(file)
    
    # Predicting
    pred = model.predict(data)
    print(pred)
    return pred

if __name__ == "__main__":
    main()