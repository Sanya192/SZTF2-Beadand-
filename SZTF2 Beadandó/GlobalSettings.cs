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
        #region Valtozok
        static int szintek;
        static int gyari_csapkivezetesek;
        static Nehezseg nehezseg;
        static int korok;
        static int gyozelmek;
        static int vesztelmek;
        static Random r;
        static bool utlosoTulajdonos;
        static int utolsoIndex;

        public static int Szintek { get => szintek; set => szintek = value; }
        public static int Gyari_csapkivezetesek { get => gyari_csapkivezetesek; set => gyari_csapkivezetesek = value; }
        public static int Korok { get => korok; set => korok = value; }
        public static int Gyozelmek { get => gyozelmek; set => gyozelmek = value; }
        public static int Vesztelmek { get => vesztelmek; set => vesztelmek = value; }
        public static Nehezseg Nehezseg { get => nehezseg; set => nehezseg = value; }
        public static Random R { get => r; set => r = value; }
        public static bool UtlosoTulajdonos { get => utlosoTulajdonos; set => utlosoTulajdonos = value; }
        public static int UtolsoIndex { get => utolsoIndex; set => utolsoIndex = value; }
        #endregion Valtozok

        public static void Init(int _szintek, int _gyari_csapkivezetesek, Nehezseg _nehezseg, int _korok, int _gyozelmek, int _vesztelmek,bool _utlosoTulajdonos) {
            szintek = _szintek;
            gyari_csapkivezetesek = _gyari_csapkivezetesek;
            nehezseg = _nehezseg;
            korok = _korok;
            gyozelmek = _gyozelmek;
            vesztelmek = _vesztelmek;
            UtlosoTulajdonos = _utlosoTulajdonos;
            r = new Random();
        }
        public static void Init() {
            szintek = 3;
            gyari_csapkivezetesek = 2;
            nehezseg = Nehezseg.Hard;
            korok = 1;
            gyozelmek = 0;
            vesztelmek = 0;
            UtlosoTulajdonos = true;
            r = new Random();
        }

             
    }
    }

