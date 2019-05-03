using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Beadandó
{
    class AI
    {
        private List<VizesBlokk>[] masik;

        public AI(List<VizesBlokk>[] be)
        {
            //ez nem fölös, biztos akarunk lenni nem referenciaként kapjuk meg. Mert annak csúnya vége lenne;
            masik = be.Select(p => p.Select(k => k as VizesBlokk).ToList()).ToArray();
            masik[0][0].Vizhozam = 0;
        }
        
    }
}
