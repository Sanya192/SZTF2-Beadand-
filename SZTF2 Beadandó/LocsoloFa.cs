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
        private int playerViz;
        private int comViz;
        int playerScore;
        int comScore;
        public VizesBlokk[] Vektor { get => vektor; set => vektor = value; }
        public List<VizesBlokk>[] FogasLista { get => fogasLista; set => fogasLista = value; }
        public int PlayerViz{ get => playerViz; set => playerViz = value; }
        public int ComViz { get => comViz; set => comViz = value; }
        public int PlayerScore { get => playerScore; set => playerScore = value; }
        public int ComScore { get => comScore; set => comScore = value; }

        public LocsoloFa(Locsolo gyökér) {
            this.gyökér = gyökér;
            vektor=this.Select(p => p).ToArray();
            fogasLista = new List<VizesBlokk>[GlobalSettings.Összint];
            for (int i = 0; i < fogasLista.Length; i++)
            {
                fogasLista[i] = Szintenkent(i);
            }
            playerScore = 0;
            comScore = 0;
        }
        public LocsoloFa Clone()
        {
            return new LocsoloFa(gyökér.Clone() as Locsolo);
        }
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
       public void CalculateScore(Turn turn)
        {
            int beforePlayerViz = playerViz;
            int beforeComViz = comViz;
            playerViz = 0;
            comViz = 0;
            for (int i = 0; i < fogasLista[fogasLista.Length-1].Count; i++)
            {
                Palánta növény = fogasLista[fogasLista.Length - 1][i] as Palánta;
                if (!növény.Tulajdonos)
                {
                    playerViz += (int)növény.Vizhozam;
                }
                else
                {
                    comViz += (int)növény.Vizhozam;

                }
            }
            switch (turn)
            {
                case Turn.player:
                    playerScore +=(playerViz- beforePlayerViz)+(beforeComViz-ComViz);
                    break;
                case Turn.comp:
                    comScore += ( beforePlayerViz-playerViz) + (comViz - beforeComViz);
                    break;
                case Turn.nobody:
                    break;
                default:
                    break;
            }

        }
        public int CalculateScoreOut(Turn turn)
        {
            int beforePlayerViz = playerViz;
            int beforeComViz = comViz;
            playerViz = 0;
            comViz = 0;
            for (int i = 0; i < fogasLista[fogasLista.Length - 1].Count; i++)
            {
                Palánta növény = fogasLista[fogasLista.Length - 1][i] as Palánta;
                if (!növény.Tulajdonos)
                {
                    playerViz += (int)növény.Vizhozam;
                }
                else
                {
                    comViz += (int)növény.Vizhozam;

                }
            }
            switch (turn)
            {
                case Turn.player:
                    return(playerViz - beforePlayerViz) + (beforeComViz - ComViz);
                    break;
                case Turn.comp:
                    return (beforePlayerViz - playerViz) + (comViz - beforeComViz);
                case Turn.nobody:
                default:
                    return 0;
                    break;
            }

        }
    }

}

