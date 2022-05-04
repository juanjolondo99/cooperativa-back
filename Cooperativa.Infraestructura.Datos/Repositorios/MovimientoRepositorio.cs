using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Infraestructura.Datos.Contextos;

namespace Cooperativa.Infraestructura.Datos.Repositorios
{
    public class MovimientoRepositorio : IRepositorioMovimiento<Movimiento, Guid>
    {

        private CooperativaContexto db;

        public MovimientoRepositorio(CooperativaContexto _db)
        {
            db = _db;
        }

        public Movimiento Agregar(Movimiento entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Movimientos.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Movimiento> Listar()
        {
            return db.Movimientos.ToList();
        }

        public List<Movimiento> ListarPorAsociadoIdYProductoId(Guid asociadoId, Guid productoId)
        {
            var seleccionados = db.Movimientos.Where(m => m.asociadoId == asociadoId).Where(m => m.productoId == productoId).ToList();
            return seleccionados;
        }

        public Movimiento SeleccionarPorId(Guid id)
        {
            var seleccionado = db.Movimientos.Where(m => m.Id == id).FirstOrDefault();
            return seleccionado;
        }
    }
}
