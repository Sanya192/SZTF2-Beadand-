using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Beadandó
{
    class AI
    {
        LocsoloFa referencia;
        Kimenet leguttobi;

        internal Kimenet Leguttobi { get => leguttobi; set => leguttobi = value; }

        public AI(LocsoloFa referencia)
        {
            this.referencia = referencia;

        }
        public Kimenet Szamolj()
        {
            List<Kimenet> esetek = new List<Kimenet>();
            for (int i = 0; i < referencia.Vektor.Length; i++)
            {
                if (referencia.Vektor[i].GetType()==typeof(Locsolo))
                {
                    for (int j = 0; j < (referencia.Vektor[i]as Locsolo).Kivezetes.Length; j++)
                    {
                        var masolt = referencia.Clone();

                        (masolt.Vektor[i] as Locsolo).Kivezetesmenny[j] = 0;
                        (masolt.Vektor[0] as Locsolo).Vizfrissites();
                        esetek.Add(new Kimenet(i, masolt.CalculateScoreOut(Turn.comp), j, 0));
                    }
                    for (int j = 0; j < (referencia.Vektor[i] as Locsolo).Kivezetes.Length; j++)
                    {
                        var masolt = referencia.Clone();

                        (masolt.Vektor[i] as Locsolo).Kivezetesmenny[j] = 100;
                        (masolt.Vektor[0] as Locsolo).Vizfrissites();
                        esetek.Add(new Kimenet(i, masolt.CalculateScoreOut(Turn.comp), j, 100));
                    }
                }
                
            }
            return esetek.OrderByDescending(p=>p.Ertek).First();
        }
        public void Csinald()
        {
            var be = Szamolj();
            leguttobi = be;
            (referencia.Vektor[be.Index] as Locsolo).Kivezetesmenny[be.Alindex] = be.Teljesitmeny;
        }
        public class Kimenet
        {
            int index;
            double ertek;
            int alindex;
            int teljesitmeny;



            public int Index { get => index; set => index = value; }
            public double Ertek { get => ertek; set => ertek = value; }
            public int Alindex { get => alindex; set => alindex = value; }
            public int Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
            public Kimenet(int index, double ertek, int alindex, int teljesitmeny)
            {
                this.index = index;
                this.ertek = ertek;
                this.alindex = alindex;
                this.teljesitmeny = teljesitmeny;
            }
        }
    }


}
