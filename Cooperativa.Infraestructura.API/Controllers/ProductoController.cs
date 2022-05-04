﻿using Microsoft.AspNetCore.Mvc;
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
    public class ProductoController : ControllerBase
    {

        ProductoServicio CrearServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("Agregado satisfactoriamente!!!!!");
        }

    }
}
