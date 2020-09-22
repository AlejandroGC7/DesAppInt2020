//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso del lenguaje LINQ.
//Alejandro García Cortés.
//22/09/2020.

using System;
using System.Collections.Generic;
using System.Linq;

namespace p21_Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frutas = new string[]{"pera", "melon", "sandia", "durazno", "manzana", "platano", "kiwi", "naranja"};

            //Crear búsqueda (frutas que empiezen con 'm')
            var mfrutas = from f in frutas where f.StartsWith('m') select f;
            Console.WriteLine($"\nFutas que inician con la letra 'm': {mfrutas.Count()}");
            //Mostrar búsqueda
            foreach(var f in mfrutas) Console.WriteLine($"{f} ");

            //Crear búsqueda (frutas que llevan 'an')
            var xfrutas = (from f in frutas where f.Contains("an") select f).ToArray(); //En un arreglo
            Console.WriteLine($"\nFutas que contienen las letras 'an': {xfrutas.Count()}");
            //Mostrar búsqueda
            foreach(var f in xfrutas) Console.WriteLine($"{f} ");

            //Crear búsqueda (frutas que terminan con 'a')
            var yfrutas = (from f in frutas where f.EndsWith('a') select f).ToList(); //En un arreglo
            Console.WriteLine($"\nFutas que terminan con la letra 'a': {yfrutas.Count()}");
            //Mostrar búsqueda
            yfrutas.ForEach(f => Console.WriteLine($"{f} "));
        }
    }
}
