using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Aplicaciones.Servicios;
using Cooperativa.Infraestructura.Datos.Contextos;
using Cooperativa.Infraestructura.Datos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cooperativa.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        MovimientoServicio CrearServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            MovimientoRepositorio repo = new MovimientoRepositorio(db);
            MovimientoServicio servicio = new MovimientoServicio(repo);
            return servicio;
        }

        // GET: api/<MovimientoController>
        [HttpGet]
        public ActionResult<List<Movimiento>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public ActionResult<Movimiento> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public ActionResult Post([FromBody] Movimiento movimiento)
        {
            var servicio = CrearServicio();
            servicio.Agregar(movimiento);
            return Ok("Agregado satisfactoriamente!!!!!");
        }

    }
}
