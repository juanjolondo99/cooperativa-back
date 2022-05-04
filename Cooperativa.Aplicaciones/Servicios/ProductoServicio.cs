using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Aplicaciones.Interfaces;

namespace Cooperativa.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioProducto<Producto, Guid>
    {

        private readonly IRepositorioProducto<Producto, Guid> repo;

        public ProductoServicio(IRepositorioProducto<Producto, Guid> _repo)
        {
            repo = _repo;
        }

        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El asociado es requerido");

            var result = repo.Agregar(entidad);
            repo.GuardarTodosLosCambios();
            return result;
        }

        public List<Producto> Listar()
        {
            return repo.Listar();
        }

        public List<Producto> ListarPorAsociadoId(Guid asociadoId)
        {
            return repo.ListarPorAsociadoId(asociadoId);
        }

        public Producto SeleccionarPorId(Guid id)
        {
            return repo.SeleccionarPorId(id);
        }
    }
}
