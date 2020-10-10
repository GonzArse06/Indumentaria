using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entidades
{
    public class Venta
    {
        public List<VentaItem> Items { get; set; }
        public Cliente Cliente { get; set; }
        public int Estado { get; set; }
        public int Codigo { get; set; }

        public double GetTotalPedido()
        {
            double retorno = 0;
            return retorno;
        }

    }
}
