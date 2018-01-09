using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Database
{
    class FileHelper
    {
        public string GetFilePath(string filename)
        {
            return Path.Combine("", filename);
        }
    }
}
