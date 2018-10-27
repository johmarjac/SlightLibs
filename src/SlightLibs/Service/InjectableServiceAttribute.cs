using System;

namespace SlightLibs.Service
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class InjectableServiceAttribute : Attribute
    {
    }
}