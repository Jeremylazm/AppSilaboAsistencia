﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Recursos
    {
        // Definir los atributos o campos que tiene una matricula
        public string CodSemestre { get; set; }
        public byte[] PlantillaSilabo { get; set; }
        public byte[] PlantillaPlanSesiones { get; set; }
    }
}