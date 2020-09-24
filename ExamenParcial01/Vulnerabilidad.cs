//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Materia: Desarrollo de Aplicaciones en Internet.
//Docente: Carlos Héctor Castañeda Ramírez.
//Alumno: Alejandro García Cortés.
//Fecha de entrega: 24/09/2020.

//Clase Vulnerabilidad

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenParcial01
{
    class Vulnerabilidad{
        /*public string Clave {get; set;}
        public string Vendedor {get; set;}
        public string Descripcion {get; set;}
        public string Tipo {get; set;}
        public string Fecha {get; set;}
        public override string ToString() =>
            $"Clave:{Clave}, Vendedor:{Vendedor}, Descripcion:{Descripcion}, Tipo:{Tipo}, Fecha:{Fecha}";
        */
        private string clave;
        private string vendedor;
        private string descripcion;
        private string tipo;
        private DateTime fecha;
        public Vulnerabilidad(string clave, string vendedor, string descripcion, string tipo, DateTime fecha){
            this.clave = clave;
            this.vendedor = vendedor;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.fecha = fecha;
        }
        public string Clave{
            get{return clave;}
            set{clave = value;}
        }
        public string Vendedor{
            get{return vendedor;}
            set{vendedor = value;}
        }
        public string Descripcion{
            get{return descripcion;}
            set{descripcion = value;}
        }
        public string Tipo{
            get{return tipo;}
            set{tipo = value;}
        }
        public DateTime Fecha{
            get{return fecha;}
            set{fecha = value;}
        }
    }
}