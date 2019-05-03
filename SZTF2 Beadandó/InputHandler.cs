using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
namespace SZTF2_Beadandó
{
    class RosszInput : Exception
    {
        public override string Message => "A bemenet hibás 0-100-ig kell megadni";
    }
    class WrongURL : Exception
    {
        public override string Message => "Valami olyan bemenet jött amire nem számítottam";

    }

    class InputHandler
    {
        HttpListenerContext context;
        HttpListener client;
        bool listen;
        LocsoloFa fareferencia;
        Graphic rajzol;
        AI ai;
        public InputHandler()
        {
            context = null;
            client = new HttpListener();
            listen = true;
            
        }
        public InputHandler(LocsoloFa faref,Graphic rajzol)
        {
            context = null;
            client = new HttpListener();
            listen = true;
            fareferencia = faref;
            this.rajzol = rajzol;
            ai = new AI(faref.Vektor);
        }

        public void Response(string file)
        {
            try
            {
                file = file.Remove(0, 1);
                if (file == "")
                {
                    file = "index.html";
                }
                var pagebuff = File.ReadAllBytes(file);
                context.Response.ContentLength64 = pagebuff.Length;
                context.Response.OutputStream.Write(pagebuff, 0, pagebuff.Length);
                context.Response.Close();
            }
            catch (Exception e)
            {
                //néha a böngésző meghülyül??? 21:03 és most kezdte el?? 
                Console.WriteLine(e.Message);
            }
           
        }
        public void StartListening()
        {
            client.Prefixes.Add("http://localhost:80/");
            client.Start();
            while (listen)
            {
                try
                {
                    context = client.GetContext();
                    var request = context.Request;
                    string text;
                    Console.WriteLine(context.Request.RawUrl);

                    if (context.Request.RawUrl!="/")
                    {
                        throw new WrongURL();
                    }
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        text = reader.ReadToEnd();
                    }
                    //frissit
                    HandleCommand(new Command(text));
                    rajzol.xDraw();
                    //context.Response.StatusCode = 205;
                    //context.Response.RedirectLocation="index.html";
                    //"<meta http-equiv='refresh' content='0'>"
                    //var header = new WebHeaderCollection();
                    //header.Add(WaitForChangedResult);
                    //context.Response.Headers = header;
                    Response(context.Request.RawUrl);
                    for (int i = 0; i < 3; i++)
                    {
                        context = client.GetContext();
                        Console.WriteLine(context.Request.RawUrl);
                        Response(context.Request.RawUrl);
                    }

                }
                catch (WrongURL e)
                {
                    Console.WriteLine(e.Message);
                    Response("/");
                    for (int i = 0; i < 3; i++)
                    {
                        context = client.GetContext();
                        Console.WriteLine(context.Request.RawUrl);
                        Response(context.Request.RawUrl);
                    }
                }
                catch (RosszInput e)
                {
                    Console.WriteLine(e.Message);
                    try
                    {
                        //A hiba nem a szerverbe volt
                        rajzol.xDraw();
                        Response(context.Request.RawUrl);
                        for (int i = 0; i < 3; i++)
                        {
                            context = client.GetContext();
                            Console.WriteLine(context.Request.RawUrl);
                            Response(context.Request.RawUrl);
                        }
                    }
                    catch (Exception ex)
                    {
                        //biztos ami biztos
                        Console.WriteLine(ex.Message);
                        listen = false;
                        client.Close();
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    listen = false;
                    client.Close();
                }
                
            }
        }
        private void HandleCommand(Command command)
        {
            switch (command.Type)
            {
                case commandTypes.set:
                    //{index=1&csap=1&mennyi=86}
                    var temp =command.Parameters.Keys;
                    if (int.Parse(command.Parameters["mennyi"])>100||int.Parse(command.Parameters["mennyi"])<0)
                    {
                        throw new RosszInput();
                    }
                    (fareferencia.Vektor[int.Parse(command.Parameters["index"])] as Locsolo)
                        .Kivezetesmenny[int.Parse(command.Parameters["csap"])]
                        = int.Parse(command.Parameters["mennyi"]);
                    (fareferencia.Vektor[int.Parse(command.Parameters["index"])] as Locsolo).Vizfrissites();
                    fareferencia.CalculateScore(Turn.player);
                    //var ai = new AI(fareferencia.FogasLista);
                    ai.Szamolj(fareferencia.Vektor);
                    (fareferencia.Vektor[0] as Locsolo).Vizfrissites();
                    Console.WriteLine(ai.legutobbiindex);
                    fareferencia.CalculateScore(Turn.comp);
                    if (fareferencia.PlayerScore>1000||fareferencia.ComScore>1000)
                    {
                        Console.WriteLine($" NYERT:{(fareferencia.PlayerScore>fareferencia.ComScore?"Játékos":"Gép")}");
                        if (GlobalSettings.R.Next(0,100)>50)
                        {
                            fareferencia = new LocsoloFa(new Locsolo(10000, ++GlobalSettings.Szintek, 0));
                             rajzol = new Graphic(fareferencia, "bemenet.html", "index.html");
                            ai = new AI(fareferencia.Vektor);
                        }
                        else
                        {
                            GlobalSettings.Gyari_csapkivezetesek++;
                            fareferencia = new LocsoloFa(new Locsolo(10000, GlobalSettings.Szintek, 0));
                             rajzol = new Graphic(fareferencia, "bemenet.html", "index.html");
                            ai = new AI(fareferencia.Vektor);

                        }

                    }       
                    break;
                case commandTypes.exit:
                    listen = false;
                    break;
                default:
                    break;
            }
        }
        /* private string ParsePost(string unformatted)
         {
             var temp = unformatted.Split('&').Select(p=>p.Split('=')).ToArray();


         }*/
    }


}

