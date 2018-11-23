using System;

namespace SlightLibs.Config.Abstractions
{
    public interface IConfigurationProvider : IDisposable
    {
        /// <summary>
        /// Loads the data
        /// </summary>
        void Load();

        /// <summary>
        /// Saves the data
        /// </summary>
        void Save();
    }
}