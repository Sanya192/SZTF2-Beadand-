using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SZTF2_Beadandó
{
    class LocsoloFa :IEnumerable<VizesBlokk>
    {
        private Locsolo gyökér;
        private VizesBlokk[] vektor;
        private List<VizesBlokk>[] fogasLista;

        internal VizesBlokk[] Vektor { get => vektor; set => vektor = value; }
        internal List<VizesBlokk>[] FogasLista { get => fogasLista; set => fogasLista = value; }

        public LocsoloFa(Locsolo gyökér) {
            this.gyökér = gyökér;
            vektor=this.Select(p => p).ToArray();
            fogasLista = new List<VizesBlokk>[GlobalSettings.Összint];
            for (int i = 0; i < fogasLista.Length; i++)
            {
                fogasLista[i] = Szintenkent(i);
            }

        }
        //Azt tudom ez a foreach a masik meg a linq-s része a dolognak.
        //de hogy mi miért működik azt nem biztos
        public IEnumerator GetEnumerator()
        {
            foreach (var item in enumarate(gyökér))
            {
                yield return item;
            }
        }
        public List<VizesBlokk> Szintenkent(int x)
        {
            var szint = new List<VizesBlokk>();
            foreach (VizesBlokk item in this)
            {
                if (x==GlobalSettings.Szintek+1&&item.GetType()==typeof(Palánta))
                {
                    szint.Add(item);
                }
                else if(!(item.GetType() == typeof(Palánta))&&x == GlobalSettings.Szintek-(item as Locsolo).Leszarmazhatosag)
                {
                    szint.Add(item);
                }
            }
            return szint;
        }
        IEnumerator<VizesBlokk> IEnumerable<VizesBlokk>.GetEnumerator()
        {
            // return GetEnumerator();
            //yield return gyökér;
            foreach (var item in enumarate(gyökér))
            {
                yield return item;
            }

        }
        IEnumerable<VizesBlokk> enumarate( VizesBlokk jelenlegi)
        {
            

            if (jelenlegi==null||jelenlegi.GetType()==typeof(Palánta))
            {
                yield break;
            }
            yield return jelenlegi;
            foreach (var item in (jelenlegi as Locsolo).Kivezetes)
            {
                if (typeof(Palánta)==item.GetType())
                {
                    yield return item;
                }
                else
                foreach (var temp in (enumarate(item)))
                {
                    yield return temp;
                }
            }
        }
    }
  
}

