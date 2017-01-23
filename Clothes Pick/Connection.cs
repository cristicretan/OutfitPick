using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODB
{
    public class Connection
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string path2 = path + @"\Clothes Pick\Clothes Pick\DB.mdf";
        public static string connection_string = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ path2 + ";Integrated Security=True;Connect Timeout=30";
    }
}

