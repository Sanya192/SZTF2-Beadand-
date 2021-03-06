﻿using System;
namespace SZTF2_Beadandó
{
    class Palánta : VizesBlokk
    {
        /// <summary>
        /// ha Igaz akkor nem a gépé egyébként az
        /// </summary>
        bool tulajdonos;
        public event EventHandler OnLeNullazodott;
        /// <summary>
        /// True if player
        /// </summary>
        public bool Tulajdonos { get => tulajdonos; set => tulajdonos = value; }
        public override double Vizhozam {
            get => base.Vizhozam;
            set {
                base.Vizhozam = value;
                if (value == 0&&OnLeNullazodott!=null) {
                    OnLeNullazodott(this, EventArgs.Empty);
                }
                
            }
        }
        public override VizesBlokk Clone()
        {
            Palánta temp= base.Clone() as Palánta;
            temp.OnLeNullazodott = null;
            return temp;
        }
        public Palánta(double vizhozam,int parentid):base(vizhozam,parentid) {
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
