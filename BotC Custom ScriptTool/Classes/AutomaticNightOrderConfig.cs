using System.Collections.Generic;

namespace BotC_Custom_ScriptTool.Classes
{
    public class AutomaticNightOrderConfig
    {
        public List<string> FirstNight { get; set; } = new List<string>();
        public List<string> OtherNights { get; set; } = new List<string>();
    }
}
