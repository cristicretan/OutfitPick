using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Pick
{
    public class ListArticle
    {
        public List<string> Clothes { get;  set; }
        public List<string> Colors { get; set; }

        public ListArticle()
        {
            Clothes = new List<string>();
            Colors = new List<string>();
        }
    }
}
