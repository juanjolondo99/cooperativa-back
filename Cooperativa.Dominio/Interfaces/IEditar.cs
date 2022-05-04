﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperativa.Dominio.Interfaces
{
    public interface IEditar<TEntidad>
    {
        void Editar(TEntidad entidad);
    }
}
