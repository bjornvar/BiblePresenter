using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebookParser
{
    class Controller
    {
        Model _m;

        public void setDirectory(String path)
        {
            _m = new Model(path);
        }

        public bool parseDirectoryContent()
        {
            try
            {
                Parser p = new Parser();
                p.parse(_m);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
