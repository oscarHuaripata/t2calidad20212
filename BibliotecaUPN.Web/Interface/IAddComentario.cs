﻿using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interface
{
    public interface IAddComentario
    {
        void AddComentario(Comentario comentario,Usuario usuario);
    }
}
