using System;
using System.Collections.Generic;

namespace BlocNotasCurso.Util
{
    public class Session
    {
        private static Dictionary<String,Object> _session=new Dictionary<string, object>();
        
        public Object this[String index]//indexor se usa para guardar sesiones en memoria (es decir guardar datos en memorea usuarios, configuraciones etc..)
        {
            get { return _session[index]; }

            set { _session[index] = value; }
        }
    }
}