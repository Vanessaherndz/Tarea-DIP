// DiLifetimesDemo/Services/TransientService.cs
using DiLifetimesDemo.Models;

namespace DiLifetimesDemo.Services
{
    public class TransientService : ILifetimeService, IDisposable
    {
        private readonly Guid _instanceId;

        public TransientService()
        {
            _instanceId = Guid.NewGuid();
            Console.WriteLine($"TransientService creado: {_instanceId}");
        }

        public LifetimeIdentity GetIdentity() => new() { Type = "Transient", InstanceId = _instanceId };

        // El contenedor llama a Dispose() automáticamente al final del ámbito (scope)
        public void Dispose()
        {
            Console.WriteLine($"TransientService eliminado: {_instanceId}");
        }
    }
}
