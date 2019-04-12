using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SZTF2_Beadandó
{

    class Program
    {
        static void Main(string[] args) {
            GlobalSettings.Init();
            var temp = new LocsoloFa(new Locsolo(10,3));
            var temp2 = temp.Select(p => p).ToArray();
            foreach (var item in temp) {
                Console.WriteLine(item);
            }
            var temp3 = new List<VizesBlokk>[GlobalSettings.Összint];
            for (int i = 0; i < temp3.Length; i++)
            {
                temp3[i] = temp.Szintenkent(i);
                
            }
            Console.ReadLine();

        }

    }
  
}

