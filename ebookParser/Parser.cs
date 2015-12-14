using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebookParser
{
    public class Parser
    {
        public void parse(Model model)
        {
            DirectoryInfo directory = new DirectoryInfo(model.path);
            IEnumerable<FileInfo> files = directory.EnumerateFiles("*.html");

            foreach (FileInfo f in files)
            {
                XmlReader reader = XmlReader.Create(f.OpenRead());
            }
        }
    }
}
