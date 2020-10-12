using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entidades
{
    public abstract class TipoIndumentaria
    {
        public string Origen;
        public double PorcentajeAlgodon;

        public TipoIndumentaria(string origen, double porcentaje)
        {
            this.Origen = origen;
            this.PorcentajeAlgodon = porcentaje;
        }

    }
}
