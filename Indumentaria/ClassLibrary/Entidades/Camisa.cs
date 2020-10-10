using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Camisa:Indumentaria
    {
        public bool TieneEstampado { get; set; }
        public string TipoManga { get; set; }
        public override string GetDetalle()
        {
            string retorno="";
            return retorno;
        }
    }
}
