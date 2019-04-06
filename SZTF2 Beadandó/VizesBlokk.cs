namespace SZTF2_Beadandó
{
    abstract class VizesBlokk
    {
        private int vizhozam;
        public virtual int Vizhozam { get => vizhozam; set => vizhozam = value; }
        protected VizesBlokk(int vizhozam) {
            this.vizhozam = vizhozam;
        }
    }

}
