using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToCsvConverter
{
    internal class LocalXmlFilesProvider : IXmlFileProvider
    {
        public IEnumerable<string> FindFiles(ConvertParams convertParams)
        {
            //yield return "C:\\Users\\User\\Documents\\repositories\\imagineML\\data_2018-01-20\\data\\20170801_Щука_20170802.xml";

            if (!Directory.Exists(convertParams.SourceDir))
            {
                Console.WriteLine("dir with XML files not found");
                return null;
            }

            var searchPattern = BuildSearchPattern(convertParams);
            var files = Directory.GetFiles(convertParams.SourceDir, searchPattern);
            return files;
        }

        private string BuildSearchPattern(ConvertParams convertParams)
        {
            string searchPattern = string.Empty;
            bool isEmpty = true;

            if (!string.IsNullOrEmpty(convertParams.Date))
            {
                searchPattern += convertParams.Date;
                isEmpty = false;
            }

            if (!string.IsNullOrEmpty(convertParams.Shop))
            {
                searchPattern += isEmpty ? "*" : "_";
                searchPattern += convertParams.Shop;
            }

            searchPattern += "*.xml";
            return searchPattern;
        }
    }
}
