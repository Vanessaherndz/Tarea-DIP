using DiLifetimesDemo.Models;
using DiLifetimesDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 

namespace DiLifetimesDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticsController : ControllerBase
    {
        // Inyección de servicios en el constructor
        private readonly TransientService _transient1;
        private readonly ScopedService _scoped1;
        private readonly SingletonService _singleton1;

        public DiagnosticsController(
            TransientService transient1,
            ScopedService scoped1,
            SingletonService singleton1)
        {
            _transient1 = transient1;
            _scoped1 = scoped1;
            _singleton1 = singleton1;
        }

        [HttpGet("lifetimes")]
        public ActionResult GetLifetimes()
        {
            var identities = new List
            {
                // 1. Instancias inyectadas en el constructor:
                new() { Type = $"Controller {_transient1.GetIdentity().Type}", InstanceId = _transient1.GetIdentity().InstanceId },
                new() { Type = $"Controller {_scoped1.GetIdentity().Type}", InstanceId = _scoped1.GetIdentity().InstanceId },
                new() { Type = $"Controller {_singleton1.GetIdentity().Type}", InstanceId = _singleton1.GetIdentity().InstanceId },

                // 2. Instancia Transient solicitada manualmente DENTRO de la misma request:
                HttpContext.RequestServices.GetRequiredService<TransientService>().GetIdentity()
            };

            return Ok(identities);
        }
    }
}
