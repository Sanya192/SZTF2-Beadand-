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
            var temp = new LocsoloFa(new Locsolo(10,3));
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

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        IEnumerator<VizesBlokk> IEnumerable<VizesBlokk>.GetEnumerator()
        {
            return new LocsolaFaIenumarator(gyökér);
        }
    }
    class LocsolaFaIenumarator : IEnumerator<VizesBlokk>
    {
        Locsolo gyökér;
        VizesBlokk jelenlegi;
        bool used;
        public LocsolaFaIenumarator(Locsolo gyökér)
        {
            this.gyökér = gyökér;
            used = false;
        }

        public VizesBlokk Current => jelenlegi;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            gyökér = null;
            jelenlegi = null;
            
        }

        public bool MoveNext()
        {
            if (!used)
            {
                used = true;
                jelenlegi = gyökér;
                return true;
            }
            else
            {
                try
                {
                    foreach (var item in (jelenlegi as Locsolo).Kivezetes)
                    {
                        jelenlegi = item;
                        return true;
                    }
                }
                catch (NullReferenceException)
                {
                    try
                    {
                        if (jelenlegi.GetType() == typeof(Palánta))
                        {
                            jelenlegi = null;
                            return false;
                        }
                    }
                    catch (NullReferenceException)
                    {

                        return false;

                    }
                }

            }
            return false;
        }
        public IEnumerable<VizesBlokk> Bejaro(VizesBlokk bejaro)
        {
            if (typeof(Palánta)==bejaro.GetType())
            {
                
                yield return bejaro;
            }
            else
            foreach (var item in (bejaro as Locsolo).Kivezetes)
            {
                    
               yield return Bejaro(item) as VizesBlokk;
            }
            
        }
        public void Reset()
        {
            used = false;
        }
    }
}

