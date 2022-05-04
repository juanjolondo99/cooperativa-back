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
    public class CoreController : ControllerBase
    {
        AsociadoServicio CrearAsociadoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            AsociadoRepositorio repo = new AsociadoRepositorio(db);
            AsociadoServicio servicio = new AsociadoServicio(repo);
            return servicio;
        }

        ProductoServicio CrearProductoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }

        MovimientoServicio CrearMovimientoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            MovimientoRepositorio repo = new MovimientoRepositorio(db);
            MovimientoServicio servicio = new MovimientoServicio(repo);
            return servicio;
        }

        // GET: api/<CoreController>
        [HttpGet]
        public ActionResult<List<Asociado>> Get()
        {
            var servicio = CrearAsociadoServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<CoreController>/5
        [HttpGet("{asociadoId}/productos")]
        public ActionResult<List<Producto>> Get(Guid asociadoId)
        {
            var servicio = CrearProductoServicio();
            return Ok(servicio.ListarPorAsociadoId(asociadoId));
        }

        [HttpGet("{asociadoId}/producto/{productoId}")]
        public ActionResult<List<Producto>> Get(Guid asociadoId, Guid productoId)
        {
            var servicio = CrearMovimientoServicio();
            return Ok(servicio.ListarPorAsociadoIdYProductoId(asociadoId, productoId));
        }

    }
}
