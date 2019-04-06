using System;
using System.Linq;

namespace SZTF2_Beadandó
{
    class Többmintszaz : Exception
    {
        public override string Message => "A locsolók százalékos összege nem lehet több mint 100,nem valosult meg a csapállítás!";
    }
    class HelytelenAdat : Exception
    {
        public override string Message => "A csap %-a 0 és száz közti szám.";
    }
    class Locsolo : VizesBlokk
    {
        private VizesBlokk[] kivezetes;
        private int[] kivezetesmenny;
        public override int Vizhozam {
            get => base.Vizhozam;
            set {
                base.Vizhozam = value;
                for (int i = 0; i < kivezetes.Length; i++) {
                    kivezetes[i].Vizhozam = base.Vizhozam / kivezetesmenny[i];
                }
            }
        }
        public void Csapállítás(int index, int érték) {
            
            int eredeti = kivezetesmenny[index];
            kivezetesmenny[index] = érték;
            if (kivezetesmenny.Sum() > 0) {
                kivezetesmenny[index] = eredeti;
                throw new Többmintszaz();
            }
            
        }
    }

}
