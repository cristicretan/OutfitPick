using OODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    static class Program
    {

        public static ListArticle Buffer = new ListArticle();
        public static int coatclicks = 0;
        public static int tshirtclicks = 0;
        public static int hoodieclicks = 0;
        public static int jacketclicks = 0;
        public static int pantsclicks = 0;
        public static int shirtclicks = 0;
        public static int sweaterclicks = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
