// DiLifetimesDemo/Services/SingletonService.cs
using DiLifetimesDemo.Models;

namespace DiLifetimesDemo.Services
{
    public class SingletonService : ILifetimeService
    {
        private readonly Guid _instanceId;

        public SingletonService()
        {
            // Esto solo se ejecuta la primera vez que se solicita el servicio
            _instanceId = Guid.NewGuid();
            Console.WriteLine($"SingletonService creado: {_instanceId}");
        }

        public LifetimeIdentity GetIdentity() => new() { Type = "Singleton", InstanceId = _instanceId };
    }
}
