using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pantalon : Indumentaria
    {
        public string Material { get; set; }
        public bool TieneBolsillos { get; set; }

        public Pantalon(TipoIndumentaria tipo, int codigo, string talle, double precio, string material, bool tieneBolsillos)
            : base(tipo, codigo, talle, precio)
        {
            this.Material = material;
            this.TieneBolsillos = tieneBolsillos;
        }

        public override string GetDetalle()
        {
            string retorno = "";
            retorno = "Codigo: " + Codigo + " - Pantalon\tTalle: " + Talle + " - Precio: "+Precio.ToString() + " - Stock: " + Stock + " - Material: " +Material;
            if (TieneBolsillos)
                retorno += " - Con Bolsillos";
            else
                retorno += " - Sin Bolsillos";

            return retorno;
        }
    }
}
