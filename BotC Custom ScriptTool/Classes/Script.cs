using System.Collections.Generic;

namespace BotC_Custom_ScriptTool.Classes
{
    public class Script
    {
        public List<Jinx> Jinxes { get; set; }
        public List<string> Roles { get; set; }
        public List<string> NightOrder { get; set; }

        public string ScriptName { get; set; }
        public string ScriptAuthor { get; set; }
    }
}
