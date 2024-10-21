using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BotC_Custom_ScriptTool.Classes;

namespace BotC_Custom_ScriptTool.FileAccess
{
    internal class FileAccessor
    {
        public static void WriteRoles(List<CharacterRole> roles, string Path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(roles, options);

            File.WriteAllText(Path, json);
        }

        public static List<CharacterRole> ReadRoles(string Path)
        {
            var list = JsonSerializer.Deserialize<List<CharacterRole>>(File.ReadAllText(Path));

            return list;
        }

        public static void WriteScript(Script script, string Path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(script, options);

            File.WriteAllText(Path, json);
        }

        public static Script ReadScript(string Path)
        {
            var list = JsonSerializer.Deserialize<Script>(File.ReadAllText(Path));

            return list;
        }
    }
}
