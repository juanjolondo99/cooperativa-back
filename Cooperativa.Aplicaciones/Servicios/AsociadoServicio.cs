using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo;
using Cooperativa.Dominio.Interfaces.Repositorios;
using Cooperativa.Aplicaciones.Interfaces;

namespace Cooperativa.Aplicaciones.Servicios
{
    public class AsociadoServicio : IServicioAsociado<Asociado, Guid>
    {

        private readonly IRepositorioAsociado<Asociado, Guid> repositorio;

        public AsociadoServicio(IRepositorioAsociado<Asociado, Guid> _repo)
        {
            repositorio = _repo;
        }

        public Asociado Agregar(Asociado entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El asociado es requerido");
            
            var result = repositorio.Agregar(entidad);
            repositorio.GuardarTodosLosCambios();
            return result;
        }

        public void Editar(Asociado entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El asociado es requerido");

            repositorio.Editar(entidad);
            repositorio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid id)
        {
            repositorio.Eliminar(id);
            repositorio.GuardarTodosLosCambios();
        }

        public List<Asociado> Listar()
        {
            return repositorio.Listar();
        }

        public Asociado SeleccionarPorId(Guid id)
        {
            return repositorio.SeleccionarPorId(id);
        }
    }
}
