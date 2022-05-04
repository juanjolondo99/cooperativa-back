using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperativa.Dominio.Interfaces
{
    public interface IEliminar<TEntidadId>
    {
        void Eliminar(TEntidadId id);
    }
}
