using System.Collections;
namespace SZTF2_Beadandó
{
    abstract class VizesBlokk 
    {
        private double vizhozam;
        private int index;
        public virtual double Vizhozam { get => vizhozam; set => vizhozam = value; }
        public int Index { get => index; set => index = value; }
        protected VizesBlokk(double vizhozam) {
            this.vizhozam = vizhozam;
            index = GlobalSettings.UtolsoIndex++;
        }
        public override string ToString()
        {
            return $"N:{index} {GetType().ToString().Substring(GetType().ToString().IndexOf('.')+1)} vizhozam{vizhozam}";
        }
    }
    
}
