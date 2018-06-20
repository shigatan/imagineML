using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlToCsvConverter
{
    internal class XmlToCsvConverter
    {
        private const string columns = "date\tid1\tid2\tname\tprice\tsales\tincome\tbalance";

        internal static void Run(ConvertParams @params, IXmlFileProvider xmlFileProvider)
        {
            var xmlFiles = xmlFileProvider.FindFiles(@params);
            if (xmlFiles == null || xmlFiles.Count() == 0)
            {
                Console.WriteLine("Files are not found.");
                return;
            }
            Console.WriteLine($"Found: {xmlFiles.Count()}");
            Console.ReadLine();
            long errorCount = 0, total = 0;
            foreach (var xmlFile in xmlFiles)
            {
                try
                {
                    total += ConvertXmlToCsv(xmlFile, @params.DestinationDir);
                }
                catch (Exception ex)
                {
                    errorCount++;
                    Console.WriteLine(ex);
                }
            }
            Console.WriteLine($"Handles {total} items, errors {errorCount}");
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

        private static int ConvertXmlToCsv(string xmlFile, string destination)
        {
            string onlyFileName = Path.GetFileName(xmlFile);
            Console.WriteLine("Reading file: {0}", xmlFile);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);

            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine(columns);

            int total = 0;
            foreach (XmlNode tovari in xmlDoc.DocumentElement.ChildNodes) // Данные -> Товары -> список nodes with name Товар
            {
                var dt = tovari.Attributes["Дата"].Value;
                foreach (XmlNode tovar in tovari.ChildNodes)
                {
                    try
                    {
                        var name = tovar["НаименованиеРабочее"].InnerText;
                        string id1 = string.Empty;
                        try
                        {
                            id1 = tovar["Код"].InnerText;
                        }
                        catch
                        {
                            //
                        }
                        var id2 = name.GetHashCode();
                        var salesNode = tovar["РозничныеПродажи"];
                        var sales = salesNode.ChildNodes[0].InnerText; // Количество
                        var price = salesNode.ChildNodes[1].InnerText; // Цена
                        var income = tovar["Поступление"].ChildNodes[0].InnerText; // Количество
                        var balance = tovar["Остаток"].InnerText; // Количество

                        var csvRow = $"{dt}\t{id1}\t{id2}\t{name}\t{price}\t{sales}\t{income}\t{balance}";
                        csvContent.AppendLine(csvRow);
                        //Console.WriteLine(csvRow);
                        total++;
                    }
                    catch
                    {
                        // 
                    }
                }
            }
            var csvFilePath = BuildCSVFileName(xmlFile, destination);
            File.WriteAllText(csvFilePath, csvContent.ToString());
            Console.WriteLine($"CSV file is ready: {csvFilePath}");
            return total;
        }
    }
}
