//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de las Listas
//Alejandro García Cortés.
//17/09/2020.

using System;
using System.Collections.Generic;

namespace p19_Lista02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear una lista con elementos del tipo Pieza
            List<Pieza> mp = new List<Pieza>();

            //Agregar piezas a la lista
            mp.Add(new Pieza(1234, "Tuerca de rosca interior"));
            mp.Add(new Pieza(5678, "Tornillo de cabeza grande"));
            mp.Add(new Pieza(9012, "Martillo"));

            //Agregar un rango de piezas
            var proveedor = new List<Pieza>(){
                new Pieza(8888, "Tornillo de cabeza pequeña"),
                new Pieza(9999, "Cables de corriente"),
                new Pieza(6666, "Taquetes para madera")
            };
            mp.AddRange(proveedor);

            //Usar el método foreach integrado en la lista para imprimir su contenido
            mp.ForEach(p => Console.WriteLine(p.ToString()));

            //Eliminar el último elemento de la lista
            Console.WriteLine("\nEliminar el ultimo elemento de la lista:");
            mp.RemoveAt(mp.Count-1);
             //Imprimir lista
            mp.ForEach(p => Console.WriteLine(p.ToString()));

            //Insertar un nuevo elemento en la lista (en la segunda posición)
            Console.WriteLine("\nInsertar elemento en la posicion 2:");
            mp.Insert(1,new Pieza(2222, "Caja de 8 velocidades"));
            //Imprimir lista
            mp.ForEach(p => Console.WriteLine(p.ToString()));

            //Buscar todas las ocurrencias de la palabra 'Tornillo'
            Console.WriteLine("\nPiezas que contienen la palabra 'Tormillo':");
            var pzas = mp.FindAll(p => p.Nombre.Contains("Tornillo"));
            pzas.ForEach(p => Console.WriteLine(p.ToString()));

            //Buscar las piezas cuyo 'Id' es menor a 5000
            Console.WriteLine("\nPiezas con Id menor a 5000:");
            var pzas2 = mp.FindAll(p => p.Id<5000);
            pzas2.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
