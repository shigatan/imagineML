# XmlToCsvConverter
This app allows to extract data related to sales and demand into csv file.
CSV file contains:
- header row
- sales data rows. Each row is a line in format *date;id;name;price;sales;income;balance*
- separator ';'
## Getting Started
The app can be run with set of params:  
*<path_to_xml_file_folder>* - path to local folder with xml files  
*<path_to_csv_file_folder>* - path to local folder where new csv files will be stored  
*<_date_>* - date in format "yyyymmdd". The app will convert xml files with the same date only  
*<_shop_>* - shop name. The app will convert xml files for this shop only  
## Run 
```
// convert all xml files
XmlToCsvConverter.exe "<path_to_xml_file_folder>" "<path_to_csv_file_folder>"

// convert xml files with specified date
XmlToCsvConverter.exe "<path_to_xml_file_folder>" "<path_to_csv_file_folder>" "<_date_>"

// convert xml files for one shop
XmlToCsvConverter.exe "<path_to_xml_file_folder>" "<path_to_csv_file_folder>" "" "<_shop_>"

// convert xml files for one shop and one day
XmlToCsvConverter.exe "<path_to_xml_file_folder>" "<path_to_csv_file_folder>" "<_date_>" "<_shop_>"
```
## Todo
- in result it should be cross-platform service which every day downloads new appeared xml files, converts them to csv file and loads csv files to csv storage
- add setting: limited by csv file size/1 xml => 1 csv/all xml => 1 csv. Now it works as 1 xml(>21000Kb) to 1 csv(~330Kb)

