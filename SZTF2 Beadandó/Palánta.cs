using System;
namespace SZTF2_Beadandó
{
    class Palánta : VizesBlokk
    {
        /// <summary>
        /// ha Igaz akkor nem a gépé egyébként az
        /// </summary>
        bool tulajdonos;
        public event EventHandler OnLeNullazodott;

        public bool Tulajdonos { get => tulajdonos; set => tulajdonos = value; }
        public override double Vizhozam {
            get => base.Vizhozam;
            set {
                base.Vizhozam = value;
                if (value == 0) {
                    OnLeNullazodott(this, EventArgs.Empty);
                }
            }
        }

        public Palánta(double vizhozam):base(vizhozam) {
            OnLeNullazodott += Palánta_OnLeNullazodott;
            tulajdonos = !GlobalSettings.UtlosoTulajdonos;
            GlobalSettings.UtlosoTulajdonos ^= true;
        }

        private void Palánta_OnLeNullazodott(object sender, EventArgs e) {
            Console.WriteLine("Egy palánta lennullázódott");
        }
        public override string ToString()
        {
            return base.ToString()+$" Tulajdonos: {(tulajdonos?"számitógép":"Jatékos")}";
        }

    }
    class LennulazodottArgs : EventArgs
    {
        //Not implemented
    }
}
