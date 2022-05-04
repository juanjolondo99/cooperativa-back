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
    public class AsociadoController : ControllerBase
    {

        AsociadoServicio CrearServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            AsociadoRepositorio repo = new AsociadoRepositorio(db);
            AsociadoServicio servicio = new AsociadoServicio(repo);
            return servicio;
        }

        // GET: api/<AsociadoController>
        [HttpGet]
        public ActionResult<List<Asociado>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar()); 
        }

        // GET api/<AsociadoController>/5
        [HttpGet("{id}")]
        public ActionResult<Asociado> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<AsociadoController>
        [HttpPost]
        public ActionResult Post([FromBody] Asociado asociado)
        {
            var servicio = CrearServicio();
            servicio.Agregar(asociado);
            return Ok("Agregado satisfactoriamente!!!!!");
        }

        // PUT api/<AsociadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Asociado asociado)
        {
            var servicio = CrearServicio();
            asociado.Id = id;
            servicio.Editar(asociado);
            return Ok("Editado debidamente!!!!!!!!!");
        }

        // DELETE api/<AsociadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente!!!!!");
        }
    }
}
