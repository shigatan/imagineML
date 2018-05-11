import csv
import hashlib

target_file = "C:\\Users\\User\\Documents\\repositories\\imagineML\\data\\data_2018-01-20\\result_v2.csv"
hash_dict = {}
lines = 1
for line in open(target_file, "r", encoding="utf8"):
    lineHash = hash(line)
    if (lineHash not in hash_dict):
        hash_dict[lineHash] = 1
    else:
        print(lines, "  ", line.encode('ascii', 'ignore'))
    lines += 1

size = len(hash_dict)
print("Lines in file:", lines, "Hashes:", size, "Diff:", lines-size-1)