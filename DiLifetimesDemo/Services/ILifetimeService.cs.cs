// DiLifetimesDemo/Services/ILifetimeService.cs
using DiLifetimesDemo.Models;

namespace DiLifetimesDemo.Services
{
    public interface ILifetimeService
    {
        LifetimeIdentity GetIdentity();
    }
}
