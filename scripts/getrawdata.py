"""Return raw data."""
import csv
import datetime
from itertools import groupby

DATE_FORMAT = "%d.%m.%Y" #11.07.2014

RAWDATA = []
NAMES = []
F = open("C:\\Users\\User\\Documents\\imagineML\\data\\parsed.csv", encoding="utf8")
CSV_F = csv.reader(F)
for idx, line in enumerate(CSV_F):
    z = (idx, line[0], line[1], line[2], line[3])
    RAWDATA.append(z)
    NAMES.append(line[1])
print(len(RAWDATA))
print(len(NAMES))

UNIQUE_NAMES = sorted(list(set(NAMES)))
print(len(UNIQUE_NAMES)) #save to file to check duplicates

UNIQUE_NAMES_DICT = {}
for index, item in enumerate(UNIQUE_NAMES):
    UNIQUE_NAMES_DICT[item] = index
print(len(UNIQUE_NAMES_DICT)) #save to file to check duplicates


PARSEDDATA = []
for line in RAWDATA:
    dt = datetime.datetime.strptime(line[1], DATE_FORMAT).date()
    itemId = UNIQUE_NAMES_DICT[line[2]]
    #row = (line[0], dt,  itemId, float(line[3]), float(line[4]))
    row = (line[0], dt,  itemId, line[3], line[4])
    PARSEDDATA.append(row)

KEY_NAME = lambda x: x[2]
SORTED_DATA = sorted(PARSEDDATA, key=KEY_NAME)
RESULT = []
for key, group in groupby(SORTED_DATA, key=KEY_NAME):
    RESULT.append(dict(type=key, items=list(group)))

print(len(RESULT))
