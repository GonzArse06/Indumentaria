using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Excepciones
{
    public class CodigoInexistenteException:Exception
    {
        public CodigoInexistenteException(string mensaje) : base(mensaje)
        { }
    }
}
