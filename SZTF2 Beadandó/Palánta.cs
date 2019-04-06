using System;
namespace SZTF2_Beadandó
{
    class Palánta : VizesBlokk
    {
        public Palánta(int vizhozam):base(vizhozam) {
            OnLeNullazodott += Palánta_OnLeNullazodott;
        }

        private void Palánta_OnLeNullazodott(object sender, EventArgs e) {
            Console.WriteLine("Egy palánta lennullázódott");
        }

        public event EventHandler OnLeNullazodott;
        public override int Vizhozam {
            get => base.Vizhozam;
            set {
                base.Vizhozam = value;
                if (value == 0) {
                    OnLeNullazodott(this, EventArgs.Empty);
                }
            }
        }
    }
    class LennulazodottArgs : EventArgs
    {
        //Not implemented
    }
}
