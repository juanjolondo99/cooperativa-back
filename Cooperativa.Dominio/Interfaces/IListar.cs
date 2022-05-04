using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperativa.Dominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadId>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorId(TEntidadId id);
    }
}
