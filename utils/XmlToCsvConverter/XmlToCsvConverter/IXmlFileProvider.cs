using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToCsvConverter
{
    internal interface IXmlFileProvider
    {
        IEnumerable<string> FindFiles(ConvertParams convertParams);
    }
}
