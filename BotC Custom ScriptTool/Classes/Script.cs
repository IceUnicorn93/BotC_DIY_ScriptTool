﻿using System.Collections.Generic;

namespace BotC_Custom_ScriptTool.Classes
{
    public class Script
    {
        public List<string> Roles { get; set; }
        public NightOrder NightOrder { get; set; }

        public string ScriptName { get; set; }
        public string ScriptAuthor { get; set; }
    }
}
