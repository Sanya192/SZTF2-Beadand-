using System.Collections.Generic;
using System;
using System.IO;

namespace SZTF2_Beadandó
{
    class Graphic {
        LocsoloFa kirajzolando;
        string input;
        string output;
        public Graphic(LocsoloFa rajzold,string file,string output){
            kirajzolando = rajzold;
            input = file;
            this.output = output;
            
        }
       public  void xDraw()
        {
            kirajzolando.CalculateScore(Turn.nobody);
            
            var htmlin = File.ReadAllText(input);
            string masterpiece = "<div class=\"tree\">\n";
            for (int i = 0; i < kirajzolando.FogasLista.Length-1; i++)
            {
                //masterpiece += "<ul>";
                masterpiece += "<div class=\"item\">";
                foreach (var item in kirajzolando.FogasLista[i])
                {
                    masterpiece += $"<a href=\"#\" onclick=select({item.index})  id={item.index} name=\"Locsolo\"" +
                        $" data-vizhozam={item.Vizhozam}" +
                        $" data-parentid={item.parentid}" +
                        $" data-kivmenny={(item as Locsolo).Kivezetesmenny.Length}>" +
                        $"{(item as Locsolo).Kivezetesmenny.ToString(" | ")} V:{item.Vizhozam}</a>\n";
                }
                masterpiece += "</div>";
                masterpiece += "<br>";
            }
            masterpiece += "<div class=\"item\">";
            foreach (var item in kirajzolando.FogasLista[kirajzolando.FogasLista.Length-1])
            {
                masterpiece += $"<a href=\"#\" id={item.index} name=\"Palanta\"" +
                    $" data-vizhozam={item.Vizhozam}" +
                    $" data-owner={(item as Palánta).Tulajdonos}" +
                    $" data-parentid={item.parentid}>" +
                    $"V:{item.Vizhozam}&#09;</a>\n";
            }
            masterpiece += "</div>";
            masterpiece += "<br>";
            masterpiece += "</div>";
            string script = "<script>";
            for (int i = 1; i < kirajzolando.FogasLista.Length; i++)
            {
                foreach (var item in kirajzolando.FogasLista[i])
                {
                    script += $"var myLine = new LeaderLine( " +
                        $"document.getElementById('{item.parentid}')," +
                        $"document.getElementById('{item.index}')" +
                        $"	); \n";
                }
            }
            script += $"document.getElementById('COM').innerHTML={kirajzolando.ComScore}\n" +
                $"document.getElementById('P1').innerHTML={kirajzolando.PlayerScore}\n" +
                $"document.getElementById('win').innerHTML='{(kirajzolando.ComScore > kirajzolando.PlayerScore ? "Számítógép" : kirajzolando.ComScore < kirajzolando.PlayerScore ? "Játékos" : "döntetlen")}'\n" +
                $"document.getElementById('diff').innerHTML={Math.Abs(kirajzolando.ComScore-kirajzolando.PlayerScore)}\n";

            script += "</script>";
            htmlin = InsertSanyi(htmlin, "<?sanyi graf>", masterpiece);
            htmlin = InsertSanyi(htmlin, "<?sanyi script>", script);
            File.WriteAllText(output,htmlin);
        }
        string InsertSanyi( string bemenet,string searched,string insert)
        {
            var place = bemenet.IndexOf(searched);
            bemenet = bemenet.Remove(place, searched.Length);
            bemenet = bemenet.Insert(place, insert);

            return bemenet;
        }
        public void Draw()
        {
            foreach (var collection in kirajzolando.FogasLista)
            {
                string s = "";
                foreach (var item in collection)
                {
                    s += $"{item.index}\t";
                }
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                
            }
        }
    }
  
}

