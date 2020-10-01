//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Delegados.
//Alejandro García Cortés.
//01/10/2020.

using System;

namespace p26_Delegados2
{
    class Mensajes{
        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable, se cancela la fiesta");
    }
}