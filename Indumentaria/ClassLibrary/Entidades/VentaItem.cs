using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class VentaItem
    {
        public Indumentaria Prenda { get; set; }
        public int Cantidad { get; set; }

        public double GetTotal()
        {
            double retorno=0;
            return retorno;
        }
    }
}
