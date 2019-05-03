using System;
using System.Collections;
namespace SZTF2_Beadandó
{
    //[System.Runtime.InteropServices.ComVisible(true)]
    abstract class VizesBlokk //:ICloneable
    {
        private double vizhozam;
        public int index;
        public int parentid;
        public virtual double Vizhozam { get => vizhozam; set => vizhozam = value; }
        public int Index { get => index; set => index = value; }
        protected VizesBlokk(double vizhozam,int parentid) {
            this.vizhozam = vizhozam;
            index = GlobalSettings.UtolsoIndex++;
            this.parentid = parentid;
        }
        public override string ToString()
        {
            return $"N:{index} {GetType().ToString().Substring(GetType().ToString().IndexOf('.')+1)} vizhozam{vizhozam} parentid: {parentid}";
        }

        /*public object Clone()
        {
            return MemberwiseClone();
        }*/
    }
    
}
