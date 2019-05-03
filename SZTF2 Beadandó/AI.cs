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
        private VizesBlokk[] be;
       public int[] maxindexek { get; set; }
        public int legutobbiindex { get; private set; }
        //internal VizesBlokk[] Be { get => be; set => be = value; }

        public AI(VizesBlokk[] be)
        {
            //emost kajak generáljak le ennyit? na jó
            this.be = be;
        }
        public void Szamolj(VizesBlokk[] be)
        {
            var duplatomb = new double[be.Length * 2];
            maxindexek = new int[duplatomb.Length];

            for (int i = 0; i < duplatomb.Length / 2; i++)
            {
                if (be[i].GetType()==typeof(Locsolo))
                {
                    duplatomb[i] =
                MindentModositokÖsszegzek(be[i], 0, be[i].Vizhozam,i);
                }
            }
            for (int i = duplatomb.Length / 2; i < duplatomb.Length; i++)
            {
                if (be[i/2].GetType() == typeof(Locsolo))
                {
                    duplatomb[i] =
                MindentModositokÖsszegzek(be[i/2], 100, be[i/2].Vizhozam,i);
                }
            }
            
            int legnagyobbindex = Array.IndexOf(duplatomb, duplatomb.Max());
            legutobbiindex = legnagyobbindex < be.Length ? legnagyobbindex : legnagyobbindex / 2;
           ( be[legnagyobbindex < be.Length ? legnagyobbindex : legnagyobbindex / 2] as Locsolo).Kivezetesmenny[ maxindexek[legnagyobbindex]]=legnagyobbindex<be.Length?0:100;
            
        }

        public double MindentModositokÖsszegzek(VizesBlokk be, int csapertek,double vizhozambe,int index)
        {
            if (be.GetType()==typeof(Palánta))
            {
                if (!(be as Palánta).Tulajdonos)
                {
                    return vizhozambe;

                }
                else return 0;
            }
            Locsolo referencia = be as Locsolo;
            var kimenet = new List<double>();
            var vizhozam = be.Vizhozam;
            for (int i = 0; i < referencia.Kivezetes.Length; i++)
            {
                kimenet.Add(MindentModositokÖsszegzek(referencia.Kivezetes[i],csapertek, csapertek*vizhozam*.100f, index));
                //ez ha nem módusulna
                if (referencia.Kivezetesmenny[i] * .100f * vizhozam>0)
                {
                    vizhozam = 0;
                }
                else
                vizhozam -= referencia.Kivezetesmenny[i]*.100f*vizhozam;
            }
            maxindexek[index] = kimenet.IndexOf(kimenet.Max());
            return kimenet.Max();
        }
        class Kimenet
        {
            double value;
            int index;

            public Kimenet(double value, int index)
            {
                this.value = value;
                this.index = index;
            }
        }
    }
}
