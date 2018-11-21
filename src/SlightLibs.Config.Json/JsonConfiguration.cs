using Newtonsoft.Json;
using SlightLibs.Config.Abstractions;
using System.IO;

namespace SlightLibs.Config.Json
{
    public abstract class JsonConfiguration : ConfigurationProvider
    {
        [JsonIgnore]
        protected string ConfigFile { get; } = "config.json";

        public sealed override void Load()
        {
            var fInfo = new FileInfo(ConfigFile);
            if (!fInfo.Exists)
                Save();

            JsonConvert.PopulateObject(File.ReadAllText(ConfigFile), this);
        }

        public sealed override void Save()
        {
            File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}