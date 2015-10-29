using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PNGToJPG
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string location = Directory.GetCurrentDirectory().ToString();
                ConvertPNGToJPG.ConvertDir(location);
            }
            else if (args.Length == 1)
            {
                ConvertPNGToJPG.ConvertFile(args[0]);
            }
        }
    }
}
