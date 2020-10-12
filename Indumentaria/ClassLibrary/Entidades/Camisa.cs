using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Camisa:Indumentaria
    {
        public bool TieneEstampado { get; set; }
        public string TipoManga { get; set; }

        public Camisa(TipoIndumentaria tipo, int codigo, string talle, double precio, string tipomanga, bool tieneestampado)
    : base(tipo, codigo, talle, precio)
        {
            this.TieneEstampado = tieneestampado;
            this.TipoManga = tipomanga;
        }
        
        public override string GetDetalle()
        {
            string retorno = "";
            retorno = "Codigo: " + Codigo + " - Camisa\tTalle: " + Talle + " - Precio: " + Precio.ToString() + " - Stock: " + Stock + " - Tipo de Manga: " + TipoManga;
            if (TieneEstampado)
                retorno += " - Con Estampado";
            else
                retorno += " - Sin Estampado";

            return retorno;

        }
    }
}
