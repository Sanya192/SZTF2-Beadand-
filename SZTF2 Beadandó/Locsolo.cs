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
        private int leszarmazhatosag;
        public int Leszarmazhatosag { get => leszarmazhatosag; set => leszarmazhatosag = value; }
        public VizesBlokk[] Kivezetes { get => kivezetes; set => kivezetes = value; }
        public int[] Kivezetesmenny { get => kivezetesmenny; set => kivezetesmenny = value; }
        



        /// <summary>
        /// Nem használt csak későbbi implementásért van.
        /// </summary>
        /// <param name="kivezetes"></param>
        /// <param name="kivezetesmenny"></param>
        /// <param name="leszarmazhatosag"></param>
        /// <param name="vizhozam"></param>
        public Locsolo(VizesBlokk[] kivezetes, int[] kivezetesmenny, int leszarmazhatosag, int vizhozam,int parentid) : base(vizhozam,parentid)
        {
            this.kivezetes = kivezetes;
            this.kivezetesmenny = kivezetesmenny;
            this.leszarmazhatosag = leszarmazhatosag;
        }
        public Locsolo(double vizhozam, int leszarmazhatosag, int parentid) : base(vizhozam,parentid)
        {
            if (leszarmazhatosag > 0)
            {
                kivezetes = new VizesBlokk[GlobalSettings.Gyari_csapkivezetesek];
                kivezetesmenny = new int[kivezetes.Length];
                this.leszarmazhatosag = leszarmazhatosag;
                for (int i = 0; i < kivezetes.Length; i++)
                {
                    kivezetesmenny[i] = GlobalSettings.R.Next(0, 101 - kivezetesmenny.Sum());
                    kivezetes[i] = new Locsolo(vizhozam * (kivezetesmenny[i] / 100f), leszarmazhatosag - 1,this.index);
                }
            }
            else
            {
                kivezetes = new VizesBlokk[GlobalSettings.Gyari_csapkivezetesek];
                kivezetesmenny = new int[kivezetes.Length];
                this.leszarmazhatosag = leszarmazhatosag;
                for (int i = 0; i < kivezetes.Length; i++)
                {
                    kivezetesmenny[i] = GlobalSettings.R.Next(0, 101 - kivezetesmenny.Sum());
                    kivezetes[i] = new Palánta(vizhozam * (kivezetesmenny[i] / 100f),this.index);
                }
            }
        }


        public override double Vizhozam {
            get => base.Vizhozam;
            set {
                base.Vizhozam = value;
                for (int i = 0; i < kivezetes.Length; i++)
                {
                    kivezetes[i].Vizhozam = base.Vizhozam * (kivezetesmenny[i] / 100);
                }
            }
        }


        public void Csapállítás(int index, int érték)
        {

            int eredeti = kivezetesmenny[index];
            kivezetesmenny[index] = érték;
            if (kivezetesmenny.Sum() > 0)
            {
                kivezetesmenny[index] = eredeti;
                throw new Többmintszaz();
            }

        }
        public override string ToString()
        {
           return base.ToString()+$" Szint:{GlobalSettings.Összint-Leszarmazhatosag}";
           
        }
        public void Vizfrissites()
        {
            for (int i = 0; i < kivezetes.Length; i++)
            {
                kivezetes[i].Vizhozam = (kivezetesmenny[i] / 100f) * Vizhozam;
                if (kivezetes[i].GetType()==typeof(Locsolo))
                {
                    (kivezetes[i] as Locsolo).Vizfrissites();
                }
            }
        }
    }
}
