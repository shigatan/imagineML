import csv

with open("C:\\Users\\Tatyana\\Documents\\imagineML\\data\\data-csv.csv") as csvfile:
    reader = csv.DictReader(csvfile)
    i=0
    for row in reader:
        if (i < 20):
            print (row)
            i+=1