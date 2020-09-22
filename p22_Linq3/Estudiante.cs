//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Estudiante.
//Alejandro García Cortés.
//22/09/2020.

using System;
using System.Collections.Generic;
using System.Linq;

namespace p22_Linq3
{
    class Estudiante{
        public int Matricula {get; set;}
        public string Nombre {get; set;}
        public string Domicilio {get; set;}
        public List<float> Califs;
        public override string ToString() =>
            $"Matricula:{Matricula}, Nombre:{Nombre}, Domicilio:{Domicilio}, Calificaciones:{string.Join(",",Califs)}";
    }
}