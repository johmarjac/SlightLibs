using System;

namespace SlightLibs.Structural
{
    public abstract class Singleton<TClass> where TClass : class, new()
    {
        private static readonly Lazy<TClass> _instance = new Lazy<TClass>(() => new TClass());

        public static TClass Instance => _instance.Value;

        protected Singleton()
        {
        }
    }
}