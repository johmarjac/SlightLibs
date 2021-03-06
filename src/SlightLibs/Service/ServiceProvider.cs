﻿using SlightLibs.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SlightLibs.Service
{
    public sealed class ServiceProvider : Singleton<ServiceProvider>
    {
        private readonly List<object> _services;

        public ServiceProvider()
        {
            _services = new List<object>();
        }

        public void InjectServices()
        {
            var classes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes().Where(w => w.GetTypeInfo().GetCustomAttribute(typeof(InjectableServiceAttribute)) != null));

            foreach (var serviceClass in classes)
            {
                if(!serviceClass.IsAbstract)
                    AddService(Activator.CreateInstance(serviceClass));
            }
        }

        public void AddService<TService>(TService service)
        {
            _services.Add(service);
        }

        public TService GetService<TService>(Func<TService, bool> predicate = null)
        {
            if (predicate == null)
                return _services
                    .OfType<TService>()
                    .FirstOrDefault();
            
            return _services
                .OfType<TService>()
                .FirstOrDefault(predicate);
        }
    }
}