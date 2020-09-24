//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Materia: Desarrollo de Aplicaciones en Internet.
//Docente: Carlos Héctor Castañeda Ramírez.
//Alumno: Alejandro García Cortés.
//Fecha de entrega: 24/09/2020.

//Clase Nodo

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenParcial01
{
    class Nodo{
        public string Ip {get; set;}
        public string Tipo {get; set;}
        public int Puertos {get; set;}
        public int Saltos {get; set;}
        public string SO {get; set;}
        public int TotVul {get; set;}
        public List<Vulnerabilidad> vulnerabilidades;
        public override string ToString() =>
            $"Ip:{Ip}, Tipo:{Tipo}, Puertos:{Puertos}, Saltos:{Saltos}, SO:{SO}, TotVul:{TotVul}";

        public List<Vulnerabilidad> Vulnerabilidades{
            get{return vulnerabilidades;}
        }
        public void AgregarVulnerabilidad(Vulnerabilidad vul){
            vulnerabilidades.Add(vul);
        }
    }
}