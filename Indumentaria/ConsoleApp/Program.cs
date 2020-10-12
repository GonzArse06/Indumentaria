using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Threading;
using ClassLibrary.Entidades;
using ClassLibrary.Excepciones;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minMenu=1;
            const int maxMenu=8;
            string menu = "******************** INDUMENTARIA ********************"
                + "\n1. Listar Indumentaria\n2. Agregar indumentaria\n3. Modificar indumentaria\n4. Eliminar indumentaria" +
                "\n5. Listar Ordenes\n6. Ingresar Orden\n7. Devolver Orden\n8. Salir";
            int opcion;

            TiendaRopa tiendaRopa = new TiendaRopa();
            CargasIniciales(tiendaRopa);

            do
            {
                Console.Clear();
                Console.WriteLine(menu);
                opcion = Validaciones.Entero("opcion", minMenu, maxMenu);
                switch (opcion)
                {
                    case 1:
                        ListarIndumentaria(tiendaRopa);
                        break;
                    case 2:
                        AgregarIndumentaria(tiendaRopa);
                        break;
                    case 3:
                        ModificarIndumentaria(tiendaRopa);
                        break;
                    case 4:
                        EliminarIndumentaria(tiendaRopa);
                        break;
                    case 5:
                        ListarOrdenes(tiendaRopa);
                        break;
                    case 6:
                        IngresarOrden(tiendaRopa);
                        break;
                    case 7:
                        DevolverOrden(tiendaRopa);
                        break;
                    case 8:

                        break;
                }
                if (opcion != 8)
                {
                    Console.WriteLine("\n\nEnter para continuar.....");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\n\n************** Gracias por usar el programa **************");
                    Thread.Sleep(5000);
                }
            } while (opcion != 8);

        }

        static void ListarIndumentaria(TiendaRopa tiendaRopa) 
        {
            List<Indumentaria> aux = tiendaRopa.Lista();
            if (aux.Count == 0)
                Console.WriteLine("No hay articulos cargados");
            else
            {
                foreach (Indumentaria a in aux)
                {
                    Console.WriteLine(a.ToString());
                }
            }        

        }
        static void AgregarIndumentaria(TiendaRopa tiendaRopa)
        {
            Console.WriteLine("\n\n******************** AGREGAR INDUMENTARIA ********************");

            string texto;
            int booleanoNumero;
            bool booleano;

            int tipoIndumentaria = Validaciones.Entero("tipo de indumentaria (1-Casual | 2-Deportiva | 3-Formal)", 1, 3);
            int claseIndumentaria = Validaciones.Entero("1-Camisa | 2-Pantalon",1,2);
            string talle = Validaciones.Texto("talle").ToUpper();
            double precio = Validaciones.Importe("precio", 1, 999999);
            if (claseIndumentaria == 1)
            {
                 texto = Validaciones.Texto("tipo de manga");
                booleanoNumero = Validaciones.Entero("tiene estampado? (1-SI | 2-NO)", 1, 2);
            }
            else
            {
                 texto = Validaciones.Texto("material");
                booleanoNumero = Validaciones.Entero("tiene bolsillos? (1-SI | 2-NO)", 1, 2);
            }
            if (booleanoNumero == 1)
                booleano = true;
            else
                booleano = false;

            string origen = Validaciones.Texto("origen");
            double porcentaje = Validaciones.Importe("porcentaje", 1, 100);

            try
            {
                tiendaRopa.Agregar(tipoIndumentaria, claseIndumentaria, talle, precio, texto, booleano,origen,porcentaje);
                Console.WriteLine("El producto se agrego con exito!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);                
            }
            
        }
        static void ModificarIndumentaria(TiendaRopa tiendaRopa)
        {
            Console.WriteLine("\n\n******************** MODIFICAR INDUMENTARIA ********************");

            List<Indumentaria> aux = tiendaRopa.Lista();
            Indumentaria auxiliar=null;
            int respuesta;
            int booleanoNumero=0;

            if (aux.Count == 0)
                Console.WriteLine("No hay articulos cargados");
            else
            {
                foreach (Indumentaria a in aux)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            int codigo = Validaciones.Entero("codigo de producto a modificar", 1, tiendaRopa.UltimoCodigo);
            foreach (Indumentaria a in aux)
            {
                if (a.Codigo == codigo)
                    auxiliar = a;
            }
            if (auxiliar == null)
            {
                Console.WriteLine("No hay productos con ese codigo");
            }
            else
            {
                respuesta = Validaciones.Entero("Desea modificar el Talle? (1-SI | 2-NO)", 1, 2);
                if (respuesta == 1)
                    auxiliar.Talle = Validaciones.Texto("nuevo talle").ToUpper();                   

                respuesta = Validaciones.Entero("Desea modificar el Precio? (1-SI | 2-NO)", 1, 2);                
                if (respuesta == 1)
                    auxiliar.Precio = Validaciones.Importe("nuevo precio",1,999999);

                if (auxiliar is Camisa)
                {
                    respuesta = Validaciones.Entero("Desea modificar el Tipo de Manga?  (1-SI | 2-NO)", 1, 2);
                    if (respuesta == 1)
                        ((Camisa)auxiliar).TipoManga = Validaciones.Texto("nuevo Tipo de Manga");

                    respuesta = Validaciones.Entero("Desea modificar Si tiene Estampado?  (1-SI | 2-NO)", 1, 2); ;
                    if (respuesta == 1)
                        booleanoNumero = Validaciones.Entero("tiene estampado? (1-SI | 2-NO)", 1, 2);

                    if (booleanoNumero == 1)
                        ((Camisa)auxiliar).TieneEstampado = true;
                    else if(booleanoNumero ==2)
                        ((Camisa)auxiliar).TieneEstampado = false;
                }
                else if (auxiliar is Pantalon)
                {
                    respuesta = Validaciones.Entero("Desea modificar el Material?  (1-SI | 2-NO)", 1, 2);
                    if (respuesta == 1)
                        ((Pantalon)auxiliar).Material = Validaciones.Texto("nuevo Tipo de Material");

                    respuesta = Validaciones.Entero("Desea modificar Si tiene Bolsillos?  (1-SI | 2-NO)", 1, 2); ;
                    if (respuesta == 1)
                        booleanoNumero = Validaciones.Entero("tiene bolsillos? (1-SI | 2-NO)", 1, 2);

                    if (booleanoNumero == 1)
                        ((Pantalon)auxiliar).TieneBolsillos = true;
                    else if (booleanoNumero == 2)
                        ((Pantalon)auxiliar).TieneBolsillos = false;
                }

                try
                {
                    tiendaRopa.Modificar(auxiliar);
                    Console.WriteLine("El producto se actualizo con exito!");
                }
                catch (CodigoInexistenteException e)
                {
                    Console.WriteLine("Error - " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error - " + e.Message);
                }

            }

        }
        static void EliminarIndumentaria(TiendaRopa tiendaRopa)
        {
            Console.WriteLine("\n\n******************** ELIMINAR INDUMENTARIA ********************");
            List<Indumentaria> aux = tiendaRopa.Lista();
            Indumentaria auxiliar = null;

            if (aux.Count == 0)
                Console.WriteLine("No hay articulos cargados");
            else
            {
                foreach (Indumentaria a in aux)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            int codigo = Validaciones.Entero("codigo de producto a eliminar", 1, tiendaRopa.UltimoCodigo);
            foreach (Indumentaria a in aux)
            {
                if (a.Codigo == codigo)
                    auxiliar = a;
            }
            if (auxiliar == null)
            {
                Console.WriteLine("No hay productos con ese codigo");
            }
            else
            {
                try
                {
                    tiendaRopa.Quitar(auxiliar);
                    Console.WriteLine("El producto se elimino con exito!");
                }
                catch (CodigoInexistenteException e)
                {
                    Console.WriteLine("Error - " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error - " + e.Message);
                }
            }
        }
        static void ListarOrdenes(TiendaRopa tiendaRopa)
        {
            Console.WriteLine("\n\n******************** LISTADO DE ORDENES ********************");
            List<Venta> venta = tiendaRopa.ListarOrden();
            if (venta.Count == 0)
                Console.WriteLine("No hay pedidos ingresados");
            else
            {
                foreach (Venta a in venta)
                    Console.WriteLine(a.ToString());
            }

        }
        static void DevolverOrden(TiendaRopa tiendaRopa)
        {
            Console.WriteLine("\n\n******************** DEVOLUCION DE ORDEN ********************");
            List<Venta> venta = tiendaRopa.ListarOrden();
            if (venta.Count == 0)
                Console.WriteLine("No hay pedidos ingresados");
            else
            {
                foreach (Venta a in venta)
                    Console.WriteLine(a.ToString());
            }
            int codigo = Validaciones.Entero("codigo de pedido a devolver", tiendaRopa.PrimerCodigoVenta, tiendaRopa.UltimoCodigoVenta);
            try
            {
                tiendaRopa.DevolverOrden(codigo);
                Console.WriteLine("Devolucion exitosa.");
            }            
            catch (PedidoNOProcesadoException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (CodigoInexistenteException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (SinStockException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }

        }
        static void IngresarOrden(TiendaRopa tiendaRopa)
        {
            int numeroPedido;
            Console.WriteLine("\n\n******************** INGRESAR ORDEN ********************");
            List<Cliente> clientes = tiendaRopa.ListarClientes();
            foreach (Cliente a in clientes)
                Console.WriteLine(a.ToString());
            int codigoCliente = Validaciones.Entero("codigo de cliente", tiendaRopa.PrimerCodigoCliente, tiendaRopa.UltimoCodigoCliente);

            try
            {
                numeroPedido = tiendaRopa.Ingresar(codigoCliente);
                IngresarItems(numeroPedido, tiendaRopa);             

            }
            catch (CodigoInexistenteException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (SinStockException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
        }
        static int IngresarItems(int numeroPedido,TiendaRopa tiendaRopa)
        {
            int respuesta = 0;
            int pos = 0;
            List<Indumentaria> listIndumentaria = tiendaRopa.Lista();
            Indumentaria auxIndumentaria;
            try { 
            if (listIndumentaria.Count == 0)
                Console.WriteLine("No hay productos cargados.");
            else
            {
                foreach (Indumentaria a in listIndumentaria)
                    Console.WriteLine(a.ToString());                
                do
                {
                    pos++;
                    Console.WriteLine("Articulo Nro: " + pos);
                    int codigo = Validaciones.Entero("codigo de producto", tiendaRopa.PrimerCodigo, tiendaRopa.UltimoCodigo);
                    int cantidad = Validaciones.Entero("cantidad", 1, 9999);
                    auxIndumentaria = listIndumentaria.SingleOrDefault(x => x.Codigo == codigo);
                    if (auxIndumentaria == null)
                    {
                        throw new CodigoInexistenteException("No existe el producto.");
                    }
                    else
                    { 
                        tiendaRopa.Ingresar(numeroPedido, auxIndumentaria, cantidad);
                            Console.WriteLine("Articulo agregado exitosamente.");
                        respuesta = Validaciones.Entero("Desea agregar otro articulo? (1-SI | 2-NO)", 1, 2);
                    }
                } while (respuesta != 2);
                    if (tiendaRopa.IngresarConfirmacion(numeroPedido))
                        Console.WriteLine("Pedido "+numeroPedido+" confirmado.");
            }
            }

            catch (CodigoInexistenteException e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            catch (SinStockException e)
            {
                Console.WriteLine("Error - " + e.Message);
                IngresarItems(numeroPedido, tiendaRopa);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            return respuesta;
        }

        static void CargasIniciales(TiendaRopa tiendaRopa)
        {
            tiendaRopa.CargaInicialClientes("Gonzalo", "Carranza");
            tiendaRopa.CargaInicialClientes("Sofia", "Carranza");
            tiendaRopa.CargaInicialClientes("Andrea", "Amatrudo");
            tiendaRopa.CargaInicialClientes("Roberto", "Sanchez");

            tiendaRopa.Agregar(1, 1, "S", 200, "Corta", true, "Argentina", 90);
            tiendaRopa.Agregar(3, 1, "M", 1000, "Larga", false, "Chile", 70);
            tiendaRopa.Agregar(1, 2, "S", 500, "Algodon", false, "Indonesia", 90);
            tiendaRopa.Agregar(2, 2, "M", 600, "Tela Avion", false, "Indonesia", 70);
            tiendaRopa.Agregar(3, 2, "L", 800, "Laycra", true, "Costa Rica", 50);
            tiendaRopa.Agregar(3, 2, "S", 800, "Laycra", true, "Costa Rica", 50);

        }
    }
}
