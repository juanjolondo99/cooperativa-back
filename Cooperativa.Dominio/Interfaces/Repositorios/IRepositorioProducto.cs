using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Interfaces;

namespace Cooperativa.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProducto<TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>, ITransaccion
    {
        List<TEntidad> ListarPorAsociadoId(Guid asociadoId);
    }
}
