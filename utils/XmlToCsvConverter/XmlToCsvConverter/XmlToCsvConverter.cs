using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlToCsvConverter
{
    internal class XmlToCsvConverter
    {
        private const string columns = "date;id;name;price;sales;income;balance";

        internal static void Run(ConvertParams @params, IXmlFileProvider xmlFileProvider)
        {
            var xmlFiles = xmlFileProvider.FindFiles(@params);
            if (xmlFiles == null || xmlFiles.Count() == 0)
            {
                Console.WriteLine("Files are not found.");
                return;
            }
            
            foreach(var xmlFile in xmlFiles)
            {
                ConvertXmlToCsv(xmlFile, @params.DestinationDir); 
            }
        }

        private static string BuildCSVFileName(string xmlFile, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
                Console.WriteLine($"Destination folder created: {destination}.");
            }
            else
            {
                Console.WriteLine($"Destination folder exists: {destination}.");
            }
            var filename = Path.GetFileNameWithoutExtension(xmlFile);
            return Path.Combine(destination, $"{filename}.csv");
        }

        private static void ConvertXmlToCsv(string xmlFile, string destination)
        {
            try
            {
                Console.WriteLine("Reading file: {0}", xmlFile);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFile);

                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine(columns);

                foreach (XmlNode tovari in xmlDoc.DocumentElement.ChildNodes) // Данные -> Товары -> список nodes with name Товар
                {
                    var dt = tovari.Attributes["Дата"].Value;
                    foreach(XmlNode tovar in tovari.ChildNodes)
                    {
                        var name = tovar["НаименованиеРабочее"].InnerText;
                        var id = name.GetHashCode();
                        var salesNode = tovar["РозничныеПродажи"];
                        var sales = salesNode.ChildNodes[0].InnerText; // Количество
                        var price = salesNode.ChildNodes[1].InnerText; // Цена
                        var income = tovar["Поступление"].ChildNodes[0].InnerText; // Количество
                        var balance = tovar["Остаток"].InnerText; // Количество

                        var csvRow = $"{dt};{id};{name};{price};{sales};{income};{balance}";
                        csvContent.AppendLine(csvRow);
                        Console.WriteLine(csvRow);                        
                    }                    
                }
                var csvFilePath = BuildCSVFileName(xmlFile, destination);
                File.WriteAllText(csvFilePath, csvContent.ToString());
                Console.WriteLine($"CSV file is ready: {csvFilePath}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
