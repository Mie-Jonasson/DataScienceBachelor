import subprocess
import sys

def install(package_name):
    subprocess.check_call([sys.executable, "-m", "pip", "install", package_name])