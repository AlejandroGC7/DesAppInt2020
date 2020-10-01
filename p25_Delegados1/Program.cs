//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de un Delegado Simple(1).
//Alejandro García Cortés.
//01/10/2020.

using System;

namespace p25_Delegados1
{
    //Declaramos el delegado
    public delegate void MiDelegado(string msj);

    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d;   //Se instancia delagado
            
            Console.Clear();

            //Delegado invoca al método Mensaje1 de la clase Mensajes
            d = Mensajes.Mensaje1;
            d("Juan");

            //Delegado invoca al método Mensaje2 de la clase Mensajes
            d = Mensajes.Mensaje2;
            d("Jose");

            //Delegado invoca a una expresión lambada
            d = (string msj) => Console.WriteLine($"{msj} - paga todo, que no pare la fiesta");
            d("Alejandro");

            Console.WriteLine();
        }
    }

    public class Mensajes{
        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable, se cancela la fiesta");
    }
}
