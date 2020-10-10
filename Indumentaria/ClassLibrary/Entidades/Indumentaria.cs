﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entidades
{
    public abstract class Indumentaria
    {
        public TipoIndumentaria Tipo { get; set; }
        public int Codigo { get; set; }
        public int Stock { get; set; }
        public string Talle { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return GetDetalle();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Indumentaria))
                return false;
            return this.Codigo == ((Indumentaria)obj).Codigo;
        }
        public abstract string GetDetalle();


    }
}
