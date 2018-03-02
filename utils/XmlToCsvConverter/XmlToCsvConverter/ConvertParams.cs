using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToCsvConverter
{
    internal class ConvertParams
    {
        public string SourceDir { get; private set; }
        public string DestinationDir { get; private set; }
        public string Date { get; private set; }
        public string Shop { get; private set; }        


        public ConvertParams(string[] args)
        {
            this.SourceDir = args.Length > 0 ? args[0] : string.Empty;
            this.DestinationDir = args.Length > 1 ? args[1] : string.Empty;
            this.Date = args.Length > 2 ? args[2] : string.Empty; 
            this.Shop = args.Length > 3 ? args[3] : string.Empty;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Source dir: " + SourceDir);
            sb.AppendLine("Destination dir: " + DestinationDir);
            sb.AppendLine("Date: " + Date);
            sb.AppendLine("Shop: " + Shop);            
            return sb.ToString();
        }
    }
}
