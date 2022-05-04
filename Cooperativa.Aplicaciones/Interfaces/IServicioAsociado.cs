using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Interfaces;

namespace Cooperativa.Aplicaciones.Interfaces
{
    public interface IServicioAsociado<TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>
    {
    }
}
