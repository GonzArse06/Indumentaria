using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TiendaRopa
    {
        List<Indumentaria> _invetario;
        List<Venta> _Ventas;
        int _ultimoCodigo;

        private int GetProximoCodigo()
        {            
            return this._ultimoCodigo+=1;
        }
        public void Agregar(Indumentaria a)
        {
        }
        public void Modificar(Indumentaria a)
        {
        }
        public void Quitar(Indumentaria a)
        {
        }
        public void Ingresar(Indumentaria a)
        {
        }
        public List<Indumentaria> Lista()
        {
            return this._invetario;
        }
        public List<Venta> ListarOrden()
        {
            return this._Ventas;
        }
        public void DevolverOrden(Venta a)
        { }

    }
}
