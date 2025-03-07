using BotC_Custom_ScriptTool.Enums;

namespace BotC_Custom_ScriptTool.Classes
{
    public class CharacterRole
    {
        public string EnglishOriginalRoleName { get; set; }
        public string RoleName { get; set; }
        public string RoleIconURL { get; set; }
        public string RoleAbilityText { get; set; }
        public string FirstNight { get; set; }
        public string OtherNights { get; set; }

        public ERoleType RoleType { get; set; }

        public override string ToString()
        {
            return $"{RoleName.PadRight(25)} ({RoleType})";
        }
    }
}
