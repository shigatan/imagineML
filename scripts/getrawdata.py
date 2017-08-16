"""Return raw data."""
import csv

RAWDATA = []
F = open("C:\\Users\\User\\Documents\\imagineML\\data\\parsed.csv", encoding="utf8")
CSV_F = csv.reader(F)
for idx, line in enumerate(CSV_F):
    z = (idx, line[0], line[1], line[2], line[3])
    RAWDATA.append(z)
print(len(RAWDATA))
