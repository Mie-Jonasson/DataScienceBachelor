###############################################################################
# Imports
import pandas as pd
import numpy as np

###############################################################################
# Transforming InfluxDB to dataframe

def get_df(results):
    """
    Assumes InflusDB output, and a column named 'time'
    Transforms input to a pandas dataframe with 'time' as index column 
    """
    values = results.raw["series"][0]["values"]
    columns = results.raw["series"][0]["columns"]
    df = pd.DataFrame(values, columns=columns).set_index("time")
    df.index = pd.to_datetime(df.index)
    return df

###############################################################################
# Wind Direction Transformation

# First we map the directions to degrees, using the mapping depicted on;
# http://colaweb.gmu.edu/dev/clim301/lectures/wind/wind-uv
dir_to_deg = {'W':0, 'S':90, 'E':180, 'N':270, 
    'SW':45, 'SE':135, 'NE':225, 'NW':315,
    'SSW':22.5, 'WSW':67.5, 'SSE':112.5,'ESE':157.5,
    'NNE':202.5, 'ENE':247.7, 'NNW':292.5, 'WNW':337.5}

class DirectionTransformer():
    def __init__(self):
        pass 

    def fit(self, X, y):
        return self
    
    def transform(self, df, d_col='Direction', s_col='Speed'):
        """
        Assumes a column with direction (categorical) and a column with speed (numerical)
        Transforms the data to add 2 additional columns and drops the categorical
        feature before returning
        """
        # We convert the degree into radians, and calculate the vector parts as described in;
        # https://www.tensorflow.org/tutorials/structured_data/time_series#wind
        wd_rad = [dir_to_deg[i] *np.pi / 180 for i in df[d_col]]
        df['Wind_x'] = df[s_col]*np.cos(wd_rad)
        df['Wind_y'] = df[s_col]*np.sin(wd_rad)
        df.drop([d_col], axis=1, inplace=True)
        return df