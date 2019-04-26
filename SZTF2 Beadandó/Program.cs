using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace SZTF2_Beadandó
{

    class Program
    {
        static void Main(string[] args) {
            GlobalSettings.Init();
            var temp = new LocsoloFa(new Locsolo(10000,GlobalSettings.Összint-2,0));
            var temp2 = temp.Select(p => p).ToArray();
            foreach (var item in temp) {
                Console.WriteLine(item);
            }
            var temp3 = new List<VizesBlokk>[GlobalSettings.Összint];
            for (int i = 0; i < temp3.Length; i++)
            {
                temp3[i] = temp.Szintenkent(i);
            }
            var rajzol = new Graphic(temp3, "bemenet.html", "index.html");
            rajzol.Draw();
            rajzol.xDraw();
            System.Diagnostics.Process.Start("index.html");

            //Console.ReadLine();

        }

    }
  
}

