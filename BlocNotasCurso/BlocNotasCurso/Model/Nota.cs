using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasCurso.Model
{
    public class Nota
    {
        public String Id { get; set; }
        public String IdBloc { get; set; }
        public String Titulo { get; set; }
        public String Contenido { get; set; }
        public String Icono { get; set; }
    }
}
