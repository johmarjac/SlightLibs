using Microsoft.Extensions.DependencyInjection;
using SlightLibs.Structural;
using System.Linq;

namespace SlightLibs.Service
{
    public sealed class ServiceProvider : Singleton<ServiceProvider>
    {
        private readonly IServiceCollection _services;

        public ServiceProvider()
        {
            _services = new ServiceCollection();
        }

        public TService AddService<TService>(TService service)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(TService), service);

            _services.Add(serviceDescriptor);

            return service;
        }

        public TService GetService<TService>()
        {
            return _services
                .OfType<TService>()
                .FirstOrDefault();
        }
    }
}