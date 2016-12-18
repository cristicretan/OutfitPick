using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODB
{
    public class Connection
    {
        //public static string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //public static string path2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path1 + @"\Clothes Pick\Clothes Pick\Clothes Pick\DB.mdf;Integrated Security=True";
        public static string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Visual Studio 2015\Projects\Clothes Pick\Clothes Pick\DB.mdf;Integrated Security=True;Connect Timeout=30";
    }
}

