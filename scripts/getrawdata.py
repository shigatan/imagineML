"""Return raw data."""
#http://www.coderholic.com/parsing-csv-data-in-python/
import csv

RAWDATA = []
with open("C:\\Users\\User\\Documents\\imagineML\\data\\parsed.csv", encoding="utf8") as csvfile:
    READER = csv.DictReader(csvfile)
    for idx, line in enumerate(READER):
        if idx < 20:
            z = (idx)
            print(idx)
            for column in line:
                print(column)
            print("-------")
            RAWDATA.append(z)   



    
