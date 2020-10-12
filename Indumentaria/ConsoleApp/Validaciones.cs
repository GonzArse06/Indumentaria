using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Validaciones
    {
        public static string Texto(string mensaje)
        {
            string retorno = "";
            do
            {
                Console.Write("Ingresar " + mensaje + ": ");
                retorno = Console.ReadLine();
                if (string.IsNullOrEmpty(retorno))
                    Console.WriteLine("Error. Reingrese " + mensaje + ".");
            } while (string.IsNullOrEmpty(retorno));
            return retorno;
        }

        public static int Entero(string mensaje, int min, int max)
        {
            int retorno;
            do
            {
                Console.Write("Ingresar " + mensaje + ": ");
                if (!int.TryParse(Console.ReadLine(), out retorno))
                    Console.WriteLine("Error. Reingrese " + mensaje + ".");
                else if (retorno < min || retorno > max)
                    Console.WriteLine("Error. El numero debe estar entre " + min + " y " + max + ".");
            } while (retorno < min || retorno > max);

            return retorno;
        }
        public static double Importe(string mensaje, double min, double max)
        {
            double retorno;
            do
            {
                Console.Write("Ingresar " + mensaje + ": ");
                if (!double.TryParse(Console.ReadLine(), out retorno))
                    Console.WriteLine("Error. Reingrese " + mensaje + ".");
                if (retorno < min || retorno > max)
                    Console.WriteLine("Error. El numero debe estar entre " + min + " y " + max + ".");
            } while (retorno < min || retorno > max);

            return retorno;
        }

    }
}
