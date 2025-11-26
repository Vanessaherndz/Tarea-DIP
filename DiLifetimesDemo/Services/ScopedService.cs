// DiLifetimesDemo/Services/ScopedService.cs
using DiLifetimesDemo.Models;

namespace DiLifetimesDemo.Services
{
    public class ScopedService : ILifetimeService
    {
        private readonly Guid _instanceId;

        public ScopedService()
        {
            _instanceId = Guid.NewGuid();
            Console.WriteLine($"ScopedService creado: {_instanceId}");
        }

        public LifetimeIdentity GetIdentity() => new() { Type = "Scoped", InstanceId = _instanceId };
    }
}
