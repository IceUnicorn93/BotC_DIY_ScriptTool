using System.Collections.Generic;

namespace BotC_Custom_ScriptTool.Classes
{
    public class NightOrder
    {
        public List<NightInfo> FirstNight { get; set; } = new List<NightInfo>();
        public List<NightInfo> OtherNights { get; set; } = new List<NightInfo>();
    }

    public class NightInfo
    {
        public string Rolename { get; set; }
        public string NightInformation { get; set; }

        public override string ToString()
        {
            return Rolename.ToString();
        }
    }
}
