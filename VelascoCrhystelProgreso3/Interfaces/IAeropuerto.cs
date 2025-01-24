﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelascoCrhystelProgreso3.Models;

namespace VelascoCrhystelProgreso3.Interfaces
{
    public interface IAeropuerto
    {
        Task<List<CVAeropuerto>> GetAeropuerto(string name);
    }
}
