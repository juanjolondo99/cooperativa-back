using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Aplicaciones.Interfaces;

namespace Cooperativa.Aplicaciones.Servicios
{
    public class MovimientoServicio : IServicioMovimiento<Movimiento, Guid>
    {

        private readonly IRepositorioMovimiento<Movimiento, Guid> repo;

        public MovimientoServicio(IRepositorioMovimiento<Movimiento, Guid> _repo)
        {
            repo = _repo;
        }

        public Movimiento Agregar(Movimiento entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El asociado es requerido");

            var result = repo.Agregar(entidad);
            repo.GuardarTodosLosCambios();
            return result;

        }

        public List<Movimiento> Listar()
        {
            return repo.Listar();
        }

        public List<Movimiento> ListarPorAsociadoIdYProductoId(Guid asociadoId, Guid productoId)
        {
            return repo.ListarPorAsociadoIdYProductoId(asociadoId, productoId);
        }

        public Movimiento SeleccionarPorId(Guid id)
        {
            return repo.SeleccionarPorId(id);
        }
    }
}
