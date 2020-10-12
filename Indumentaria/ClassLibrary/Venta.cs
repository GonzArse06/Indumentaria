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

        public Venta(int codigo, Cliente cliente)
        {
            this.Codigo = codigo;
            this.Cliente = cliente;
            this.Estado = (int)EstadoVenta.Iniciada;
            this.Items = new List<VentaItem>();
        }
        public double GetTotalPedido()
        {
            double retorno = 0;
            foreach (VentaItem a in Items)
                retorno += a.GetTotal();

            return retorno;
        }
        public int GetCantidadTotal()
        {
            int retorno = 0;
            foreach (VentaItem a in Items)
                retorno += a.Cantidad;
            return retorno;
        }
        public override string ToString()
        {   
            return "Numero Pedido: "+ Codigo + " - Cliente: " + Cliente.Apellido + "," + Cliente.Nombre + "\tCantidad de Prendas: " + GetCantidadTotal() + " - Importe Total: " + GetTotalPedido()+" - Estado: "+Enum.GetName(typeof(EstadoVenta),Estado);
        }

    }
}
