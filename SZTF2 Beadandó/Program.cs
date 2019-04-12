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
            var temp = new LocsoloFa(new Locsolo(10000,3));
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
    class Graphic {
        List<VizesBlokk>[] kirajzolando;
        string input;
        string output;
        public Graphic(List<VizesBlokk>[] rajzold,string file,string output){
            kirajzolando = rajzold;
            input = file;
            this.output = output;
        }
        void Draw()
        {
            var htmlin = File.ReadAllText(input);
            string masterpiece = "";
            for (int i = 0; i < kirajzolando.Length; i++)
            {
                foreach (var item in kirajzolando[i])
                {
                    masterpiece+=
                }
            }
        }
    }
  
}

