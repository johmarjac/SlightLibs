using SlightLibs.Service;
using System;

namespace SlightLibs.Config.Abstractions
{
    [InjectableService]
    public abstract class ConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// Loads the data
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Saves the data
        /// </summary>
        public abstract void Save();

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}