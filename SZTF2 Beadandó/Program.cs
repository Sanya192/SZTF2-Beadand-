using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Beadandó
{
    
    class Program
    {
        static void Main(string[] args) {
            GlobalSettings.Init();
            var temp = new LocsoloFa(new Locsolo(10000,3));
                Console.ReadLine();
        }

    }
    class LocsoloFa
    {
        VizesBlokk gyökér;

        public LocsoloFa(VizesBlokk gyökér) {
            this.gyökér = gyökér;
        }
    }
}
