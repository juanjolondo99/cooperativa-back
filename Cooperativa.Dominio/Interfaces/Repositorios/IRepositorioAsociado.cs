using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Interfaces;

namespace Cooperativa.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAsociado <TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>, ITransaccion
    {
    }
}
