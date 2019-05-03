using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace SZTF2_Beadandó
{

    class Program
    {
        static void Main(string[] args) {
            GlobalSettings.Init();
            var temp = new LocsoloFa(new Locsolo(10000,GlobalSettings.Szintek,0));
            var rajzol = new Graphic(temp, "bemenet.html", "index.html");
          //  rajzol.Draw();
            rajzol.xDraw();
            var clientinput = new InputHandler(temp, rajzol);
            System.Diagnostics.Process.Start("index.html");

            clientinput.StartListening();

            Console.ReadLine();

        }

    }
    enum commandTypes
    {
        set,
        exit,
        gameon
    }


}

