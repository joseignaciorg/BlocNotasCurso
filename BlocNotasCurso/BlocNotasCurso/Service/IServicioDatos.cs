using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotasCurso.Model;

namespace BlocNotasCurso.Service
{
    public interface IServicioDatos
    {
        #region Usuario
        /* todas las operaciones en mobile son asyncronas (asi lo hizo microsoft) por lo tanto lo creamos con Task*/
        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us, String id);
        Task DeleteUsuario(String id);

        #endregion

    }
}
