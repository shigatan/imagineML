import csv
import hashlib

target_file = "C:\\Users\\User\\Documents\\repositories\\imagineML\\data\\data_2018-01-20\\result_v2.csv"
hash_dict = {}
duplicate_row1 = {}
duplicate_row2 = {}
lines = 1


for line in open(target_file, "r", encoding="utf8"):
    lineHash = hash(line)
    if (lineHash not in hash_dict):
        hash_dict[lineHash] = 1
        duplicate_row1[lineHash] = lines
    else:
        #print(lines, "  ", line.encode('ascii', 'ignore'))
        duplicate_row2[duplicate_row1[lineHash]] = lines
    lines += 1

#size = len(hash_dict)
#print("Lines in file:", lines, "Hashes:", size, "Diff:", lines-size-1)

target_file_track_file_name = "C:\\Users\\User\\Documents\\repositories\\imagineML\\data\\data_2018-01-20\\result_v3.csv"
lines_idx = 1
file_content = {}
for line in open(target_file_track_file_name, "r", encoding="utf8"):
    file_content[lines_idx] = line
    lines_idx +=1

count = 0
for dup in duplicate_row2.keys():
    l1 = dup
    l2 = duplicate_row2[dup]
    h1 = hash(file_content[l1])
    h2 = hash(file_content[l2])
    if (h1 != h2):
        print(count, "duplicate in different files:", l1, "and", l2)
        count += 1
print("total different in duplicates", count)
