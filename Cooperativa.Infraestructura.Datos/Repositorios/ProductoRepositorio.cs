using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Infraestructura.Datos.Contextos;

namespace Cooperativa.Infraestructura.Datos.Repositorios
{
    public class ProductoRepositorio : IRepositorioProducto<Producto, Guid>
    {
        private CooperativaContexto db;

        public ProductoRepositorio(CooperativaContexto _db)
        {
            db = _db;
        }

        public Producto Agregar(Producto entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Productos.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public List<Producto> ListarPorAsociadoId(Guid asociadoId)
        {
            var seleccionados = db.Productos.Where(p => p.asociadoId == asociadoId).ToList();
            return seleccionados;
        }

        public Producto SeleccionarPorId(Guid id)
        {
            var seleccionado = db.Productos.Where(p => p.Id == id).FirstOrDefault();
            return seleccionado;
        }
    }
}
