using ClassLibrary.Entidades;
using ClassLibrary.Excepciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TiendaRopa
    {
        List<Indumentaria> _invetario;
        List<Venta> _ventas;
        int _ultimoCodigo;
        int _primerCodigo;
        int _ultimoCodigoVenta;
        int _primerCodigoVenta;

        List<Cliente> _clientes;
        int _ultimoCodigoCliente;
        int _primerCodigoCliente;

        public int PrimerCodigoVenta
        { get { return _primerCodigoVenta; } }
        public int PrimerCodigo
        { get { return _primerCodigo; } }
        public int PrimerCodigoCliente
        { get { return _primerCodigoCliente; } }
        public int UltimoCodigoCliente 
        { get { return _ultimoCodigoCliente; }}
        public int GetProximoNumeroCliente()
        {
            return _ultimoCodigoCliente += 1;
        }
        public void CargaInicialClientes(string nombre, string apellido)
        {
            this._clientes.Add(new Cliente(GetProximoNumeroCliente(), nombre, apellido));
        }
        public TiendaRopa()
        {
            _invetario = new List<Indumentaria>();
            _ventas = new List<Venta>();
            _ultimoCodigo = 0;
            _primerCodigo = _ultimoCodigo+1;
            _ultimoCodigoVenta = 1999;
            _primerCodigoVenta = _ultimoCodigoVenta + 1;
            _clientes = new List<Cliente>();
            _ultimoCodigoCliente = 999;
            _primerCodigoCliente = _ultimoCodigoCliente+1;
        }
        public int UltimoCodigo
        {
            get { return this._ultimoCodigo; }
        }
        public int UltimoCodigoVenta
        {
            get { return this._ultimoCodigoVenta; }
        }
        private int GetProximoCodigo()
        {            
            return this._ultimoCodigo+=1;
        }
        private int GetProximoCodigoVenta()
        {
            return this._ultimoCodigoVenta += 1;
        }
        public void Agregar(Indumentaria a)
        {
            this._invetario.Add(a);        
            
            //throw new NotImplementedException();//excepcion de no implementado.
        }

        public void Agregar(int tipoIndu, int clase, string talle, double precio, string texto, bool booleano, string origen, double porcentaje)
        {
            Indumentaria auxiliar = null;
            switch (clase)
            {
                case 1:
                    auxiliar = new Camisa(FactoryTipoIndumentaria.GetTipoIndumentaria(tipoIndu,origen,porcentaje), GetProximoCodigo(), talle, precio, texto, booleano);
                    break;
                case 2:
                    auxiliar = new Pantalon(FactoryTipoIndumentaria.GetTipoIndumentaria(tipoIndu, origen, porcentaje), GetProximoCodigo(), talle, precio, texto, booleano);
                    break;
                default:
                    break;
            }
            this.Agregar(auxiliar);
        }

        public void Modificar(Indumentaria a)
        {
            Indumentaria modificacion = null;
            foreach (Indumentaria aux in _invetario)
            {
                if (aux.Equals(a))
                    modificacion = aux;
            }
            if (modificacion == null)
                throw new CodigoInexistenteException("El codigo no existe.");
            else
            {
                modificacion = a;
                /* Esto deberia funcionar
                this._invetario.Remove(modificacion);
                this._invetario.Add(a);*/
            }
        }
        public void Quitar(Indumentaria a)
        {
            this._invetario.Remove(a);
            /*
            Indumentaria eliminar = this._invetario.SingleOrDefault(x => x.Codigo == a.Codigo);
            if(eliminar == null)
                throw new CodigoInexistenteException("El codigo no existe.");
            else
            {
                this._invetario.Remove(eliminar);
                
            }*/
        }
        public void Ingresar(Indumentaria a)
        {

        }
        public bool IngresarConfirmacion(int codigo)
        {
            Venta auxiliar = this._ventas.SingleOrDefault(x=>x.Codigo == codigo);
            if (auxiliar == null)
            { 
                throw new CodigoInexistenteException("El pedido no existe.");
                return false;
            }
            else
            {
                auxiliar.Estado = (int)EstadoVenta.Procesada;
                return true;
            }
        }

        public void Ingresar(int codigoPedido,Indumentaria a, int cantidad)
        {
            Venta auxVenta = null;
            Indumentaria auxIndumentaria = null;
            foreach (Venta aux in _ventas)
            {
                if (aux.Codigo == codigoPedido)
                    auxVenta = aux;
            }
            if (auxVenta == null)
            {
                throw new CodigoInexistenteException("No existe el pedido.");
            }
            else
            {
                foreach (Indumentaria indumentaria in _invetario)
                {
                    if (indumentaria.Equals(a))
                        auxIndumentaria = indumentaria;
                }
                if (auxIndumentaria == null)
                    throw new CodigoInexistenteException("No existe la prenda.");
                else
                {
                    if (auxIndumentaria.Stock < cantidad)
                        throw new SinStockException("No hay stock del producto. Stock disponible: " + auxIndumentaria.Stock);
                    else
                    {
                        auxIndumentaria.Stock -= cantidad;
                        auxVenta.Items.Add(new VentaItem(a, cantidad));
                    }
                }
            }
            
        }
        public int Ingresar(int codigoCliente)
        {
            int nuevoPedido=0;
            Cliente cliente = this._clientes.SingleOrDefault(x => x.Codigo == codigoCliente);
            if (cliente == null)
                throw new CodigoInexistenteException("El Cliente no existe");
            else
            {
                nuevoPedido = GetProximoCodigoVenta();
                this._ventas.Add(new Venta(nuevoPedido, cliente));
            }
            return nuevoPedido;
        }
        public void DevolverOrden(int codigo)
        {
            Venta auxVenta = this._ventas.SingleOrDefault(x => x.Codigo == codigo);
            if (auxVenta == null)
                throw new CodigoInexistenteException("El pedido no existe");
            else
            {
                if (auxVenta.Estado == (int)EstadoVenta.Iniciada)
                    throw new PedidoNOProcesadoException("El pedido no fue confirmado.");
                else if (auxVenta.Estado == (int)EstadoVenta.Devuelto)
                    throw new PedidoNOProcesadoException("El pedido ya se encuentra devuelto.");
                else
                {
                    foreach (VentaItem ventaItem in auxVenta.Items)
                    {
                        foreach (Indumentaria indumentaria in _invetario)
                        {
                            if (indumentaria.Codigo == ventaItem.Prenda.Codigo)
                            {
                                indumentaria.Stock += ventaItem.Cantidad;
                            }
                        }
                    }
                    auxVenta.Estado = (int)EstadoVenta.Devuelto;
                }
            }
        }
        public List<Indumentaria> Lista()
        {
            return this._invetario;
        }
        public List<Venta> ListarOrden()
        {
            return this._ventas;
        }
        public List<Cliente> ListarClientes()
        {
            return this._clientes;
        }

    }
}
