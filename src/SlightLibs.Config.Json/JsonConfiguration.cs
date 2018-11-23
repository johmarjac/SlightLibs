using Newtonsoft.Json;
using SlightLibs.Config.Abstractions;
using System.IO;

namespace SlightLibs.Config.Json
{
    public abstract class JsonConfiguration : ConfigurationProvider
    {
        [JsonIgnore]
        protected string ConfigFile { get; private set; } = "config.json";

        public sealed override void Load()
        {
            if (!Path.IsPathRooted(ConfigFile))
                ConfigFile = $".{Path.DirectorySeparatorChar + ConfigFile}";

            var dInfo = new DirectoryInfo(Path.GetDirectoryName(ConfigFile));
            if (!dInfo.Exists)
                dInfo.Create();

            var fInfo = new FileInfo(ConfigFile);
            if (!fInfo.Exists)
                Save();

            JsonConvert.PopulateObject(File.ReadAllText(ConfigFile), this);
        }

        public sealed override void Save()
        {
            if (!Path.IsPathRooted(ConfigFile))
                ConfigFile = $".{Path.DirectorySeparatorChar + ConfigFile}";

            var dInfo = new DirectoryInfo(Path.GetDirectoryName(ConfigFile));
            if (!dInfo.Exists)
                dInfo.Create();

            File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}