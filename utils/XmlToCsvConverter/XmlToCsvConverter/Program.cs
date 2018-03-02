using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToCsvConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // "C:\Users\User\Documents\repositories\imagineML\data_2018-01-20\data" "C:\Users\User\Documents\repositories\imagineML\data_2018-01-20\csv" "20171022" "Щука"
            // "C:\Users\User\Documents\repositories\imagineML\data_2018-01-20\data" "C:\Users\User\Documents\repositories\imagineML\data_2018-01-20\csv" "" "Щука"
            Console.WriteLine("Starting...");
            ConvertParams @params = new ConvertParams(args);
            XmlToCsvConverter.Run(@params, new LocalXmlFilesProvider());
            Console.WriteLine("Finishing...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();           
        }
    }
}
