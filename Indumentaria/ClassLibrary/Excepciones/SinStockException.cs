﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SinStockException:Exception
    {
        public SinStockException(string mensaje) : base(mensaje)
        { }
    }
}
