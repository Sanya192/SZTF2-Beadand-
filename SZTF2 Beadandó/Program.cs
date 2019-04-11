using System;
using System.Collections;
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
            var temp2 = temp.Select(p => p).ToArray();
            foreach (var item in temp) {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();

        }

    }
    class LocsoloFa :IEnumerable<VizesBlokk>
    {
        public Locsolo gyökér;

        public LocsoloFa(Locsolo gyökér) {
            this.gyökér = gyökér;
        }

        public IEnumerator<VizesBlokk> GetEnumerator() {
            return Bejaro(gyökér);
            
        }
        public IEnumerator<VizesBlokk> Bejaro(VizesBlokk bejaro) {
             {
                
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
