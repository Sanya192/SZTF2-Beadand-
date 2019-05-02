using System;
using System.IO;
using System.Net;
namespace SZTF2_Beadandó
{
    class InputHandler
    {
        HttpListenerContext context;
        HttpListener client;
        bool listen;

        public InputHandler()
        {
            context = null;
            client = new HttpListener();
            listen = true;
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
                }
                catch (Exception)
                {

                    listen = false;
                    client.Close();
                }
                var request = context.Request;
                string text;
                using (var reader=new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                }
                //frissit
                context.Response.StatusCode = 205;
                context.Response.Close();

            }
        }
        private void HandleCommand(Command command)
        {
            switch (command.Type)
            {
                case commandTypes.set:
                    
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

