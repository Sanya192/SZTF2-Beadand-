using System;
namespace SZTF2_Beadandó
{

    enum Nehezseg
    {
        Easy,
        Medium,
        Hard
    }
    static class GlobalSettings
    {
        static int szintek;
        static int gyari_csapkivezetesek;
        static Nehezseg nehezseg;
        static int korok;
        static int gyozelmek;
        static int vesztelmek;
        static Random r;
        static void Init(int _szintek, int _gyari_csapkivezetesek, Nehezseg _nehezseg, int _korok, int _gyozelmek, int _vesztelmek) {
            szintek = _szintek;
            gyari_csapkivezetesek = _gyari_csapkivezetesek;
            nehezseg = _nehezseg;
            korok = _korok;
            gyozelmek = _gyozelmek;
            vesztelmek = _vesztelmek;
        }
        static void Init() {
            szintek = 3;
            gyari_csapkivezetesek = 2;
            nehezseg = Nehezseg.Hard;
            korok = 1;
            gyozelmek = 0;
            vesztelmek = 0;
        }
            /* public GlobalSettings(int szintek, int gyari_csapkivezetesek, Nehezseg nehezseg, int korok, int gyozelmek, int vesztelmek) {
                 this.szintek = szintek;
                 this.gyari_csapkivezetesek = gyari_csapkivezetesek;
                 this.nehezseg = nehezseg;
                 this.korok = korok;
                 this.gyozelmek = gyozelmek;
                 this.vesztelmek = vesztelmek;
             }

             public int Szintek { get => szintek; set => szintek = value; }
             public int Gyari_csapkivezetesek { get => gyari_csapkivezetesek; set => gyari_csapkivezetesek = value; }
             public int Korok { get => korok; set => korok = value; }
             public int Gyozelmek { get => gyozelmek; set => gyozelmek = value; }
             public int Vesztelmek { get => vesztelmek; set => vesztelmek = value; }
             internal Nehezseg Nehezseg { get => nehezseg; set => nehezseg = value; }*/
        }
    }

