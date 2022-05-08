using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Infraestructura.API.SBPublisher.Interfaces;
using Cooperativa.Infraestructura.ServiceBus.Eventos;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cooperativa.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController : ControllerBase
    {

        private IEventPublisher _publisher;

        public CoreController(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        // GET: api/<CoreController>
        [HttpGet]
        public async Task<ActionResult<List<Asociado>>> Get()
        {
            var newVerAsociados = new EventoCola
            {
                tipo = "VerAsociados"
            };

            var VerAsociados = _publisher.PublicarEvento(newVerAsociados).GetAwaiter().GetResult();

            if (VerAsociados == null)
                throw new ArgumentNullException("Controller: No se recibió respuesta");

            return Ok(VerAsociados.asociados);
        }

        // GET api/<CoreController>/5
        [HttpGet("{asociadoId}/productos")]
        public async Task<ActionResult<List<Producto>>> Get(Guid asociadoId)
        {
            var newVerSaldos = new EventoCola
            {
                tipo = "VerSaldos",
                asociadoId = asociadoId
            };

            var VerSaldos = _publisher.PublicarEvento(newVerSaldos).GetAwaiter().GetResult();

            if (VerSaldos == null)
                throw new ArgumentNullException("Controller: No se recibió respuesta");

            return Ok(VerSaldos.saldos);
        }

        [HttpGet("{asociadoId}/producto/{productoId}")]
        public async Task<ActionResult<List<Movimiento>>> Get(Guid asociadoId, Guid productoId)
        {
            var newVerMovimientos = new EventoCola
            {
                tipo = "VerMovimientos",
                asociadoId = asociadoId,
                productoId = productoId
            };

            var VerMovimientos = _publisher.PublicarEvento(newVerMovimientos).GetAwaiter().GetResult();

            if (VerMovimientos == null)
                throw new ArgumentNullException("Controller: No se recibió respuesta");

            return Ok(VerMovimientos.movimientos);
        }

    }
}
