using System;
using System.Web;
using System.Collections.Specialized;
namespace SZTF2_Beadandó
{
    class Command
    {
        commandTypes type;
        NameValueCollection parameters;
        internal commandTypes Type { get => type; set => type = value; }
        public NameValueCollection Parameters { get => parameters; set => parameters = value; }

        public Command(string unformatted)
        {
            NameValueCollection parsed = HttpUtility.ParseQueryString(unformatted);
            type =(commandTypes)Enum.Parse(typeof(commandTypes),parsed["command"]);
            parsed.Remove("command");
            parameters = parsed;

        }

    }


}

