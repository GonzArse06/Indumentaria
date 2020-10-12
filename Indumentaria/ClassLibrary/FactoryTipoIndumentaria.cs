using ClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class FactoryTipoIndumentaria
    {
        public static TipoIndumentaria GetTipoIndumentaria(int tipo,string origen, double porcentaje)
        {
            TipoIndumentaria tipoIndumentaria=null;

            switch (tipo)
            {
                case 1:
                    tipoIndumentaria = new IndumentariaCasual(origen, porcentaje);
                    break;
                case 2:
                    tipoIndumentaria = new IndumentariaDeportiva(origen, porcentaje);
                    break;
                case 3:
                    tipoIndumentaria = new IndumentariaFormal(origen, porcentaje);
                    break;
                default:
                    break;
            }
            return tipoIndumentaria;
        }
    }
}
