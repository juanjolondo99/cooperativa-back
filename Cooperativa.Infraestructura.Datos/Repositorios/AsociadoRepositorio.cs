using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Infraestructura.Datos.Contextos;

namespace Cooperativa.Infraestructura.Datos.Repositorios
{
    public class AsociadoRepositorio : IRepositorioAsociado<Asociado, Guid>
    {

        private CooperativaContexto db;

        public AsociadoRepositorio(CooperativaContexto _db)
        {
            db = _db;
        }

        public Asociado Agregar(Asociado entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Asociados.Add(entidad);
            return entidad;
        }

        public void Editar(Asociado entidad)
        {
            var seleccionado = db.Asociados.Where(a => a.Id == entidad.Id).FirstOrDefault();
            if(seleccionado != null)
            {
                seleccionado.cedula = entidad.cedula;
                seleccionado.nombre = entidad.nombre;
                seleccionado.apellido = entidad.apellido;
                seleccionado.telefono = entidad.telefono;

                db.Entry(seleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid id)
        {
            var seleccionado = db.Asociados.Where(a => a.Id == id).FirstOrDefault();
            if(seleccionado != null)
            {
                db.Asociados.Remove(seleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Asociado> Listar()
        {
            return db.Asociados.ToList();
        }

        public Asociado SeleccionarPorId(Guid id)
        {
            var seleccionado = db.Asociados.Where(a => a.Id == id).FirstOrDefault();
            return seleccionado;
        }
    }
}
