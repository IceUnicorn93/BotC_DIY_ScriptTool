namespace BotC_Custom_ScriptTool.Classes
{
    public class Jinx
    {
        public string RoleA { get; set; }
        public string RoleB { get; set; }
        public string JinxText { get; set; }

        public override string ToString()
        {
            return $"{RoleA} -> {RoleB}";
        }
    }
}
