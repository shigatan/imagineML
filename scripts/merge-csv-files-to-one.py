"""Merge all csv files to one csv"""

import os
import glob
import csv

path = "C:\\Users\\User\\Documents\\repositories\\imagineML\\data\\data_2018-01-20\\csv"
extension = 'csv'
os.chdir(path)
csvFiles = [i for i in glob.glob('*.{}'.format(extension))]

fout = open("C:\\Users\\User\\Documents\\repositories\\imagineML\\data\\data_2018-01-20\\result.csv", "a", encoding="utf8")
# todo: delete if result file exists

# first file:
for line in open(csvFiles[0], "r", encoding="utf8"):
    fout.write(line)

# now the rest:    
for idx in range(1, len(csvFiles)):
    f = open(csvFiles[idx], "r+", encoding="utf8")
    next(f) # skip the header
    for line in f:
         fout.write(line)
    f.close() # not really needed

fout.close()