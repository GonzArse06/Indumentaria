using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Pantalon: Indumentaria
    {
        public string Material { get; set; }
        public bool TieneBolsillos { get; set; }

        public override string GetDetalle()
        {
            string retorno = "";
            return retorno;
        }
    }
}
