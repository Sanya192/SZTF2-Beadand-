using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
namespace SZTF2_Beadandó
{
    class InputHandler
    {
        HttpListenerContext context;
        HttpListener client;
        bool listen;
        VizesBlokk[] fareferencia;
        Graphic rajzol;
        public InputHandler()
        {
            context = null;
            client = new HttpListener();
            listen = true;
            
        }
        public InputHandler(VizesBlokk[] faref,Graphic rajzol)
        {
            context = null;
            client = new HttpListener();
            listen = true;
            fareferencia = faref;
            this.rajzol = rajzol;
        }

        public void Response(string file)
        {
            file = file.Remove(0, 1);
            if (file=="")
            {
                file = "index.html";
            }
            var pagebuff = File.ReadAllBytes(file);
            context.Response.ContentLength64 = pagebuff.Length;
            context.Response.OutputStream.Write(pagebuff, 0, pagebuff.Length);
            context.Response.Close();
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
                    (fareferencia[int.Parse(command.Parameters["index"])] as Locsolo)
                        .Kivezetesmenny[int.Parse(command.Parameters["csap"])]
                        = int.Parse(command.Parameters["mennyi"]);
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

