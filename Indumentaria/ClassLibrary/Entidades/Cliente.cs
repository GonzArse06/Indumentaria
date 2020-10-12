using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Cliente(int codigo, string nombre, string apellido)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
        public override string ToString()
        {
            return "Codigo Cliente: "+Codigo + " - Nombre: " + Apellido + ", " + Nombre;
        }
    }
}
