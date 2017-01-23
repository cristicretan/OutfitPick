using OODB;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static List<Image> HoodiesListBelow = new List<Image>();
        public static List<Image> SweatersListBelow = new List<Image>();
        public static List<Image> ShirtsListBelow = new List<Image>();
        public static List<Image> PantsListBelow = new List<Image>();

        public static List<string> HoodiesPathBelow = new List<string>();
        public static List<string> SweatersPathBelow = new List<string>();
        public static List<string> ShirtsPathBelow = new List<string>();
        public static List<string> PantsPathBelow = new List<string>();
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
