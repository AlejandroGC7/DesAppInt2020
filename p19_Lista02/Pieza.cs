//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Pieza
//Alejandro García Cortés.
//17/09/2020.

using System;

namespace p19_Lista02
{
    class Pieza{
        public Pieza(int id, string nombre) => (Id, Nombre) = (id, nombre);
        public int Id{get; set;}
        public string Nombre{get; set;}

        //Sobrecargamos el método ToString()
        public override string ToString() => $"{Id} - {Nombre}";
    }
}