using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Interfaces;

namespace Cooperativa.Aplicaciones.Interfaces
{
    public interface IServicioProducto<TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>
    {
        List<TEntidad> ListarPorAsociadoId(Guid asociadoId);
    }
}
