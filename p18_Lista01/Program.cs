//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace el uso de Listas.
//Alejandro García Cortés.
//17/09/2020.

using System;
using System.Collections.Generic;

namespace p18_Lista01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definir la lista con algunos valores iniciales
            List<string> mats = new List<string>() {
                "Calculo I",
                "Redaccion Avanzada",
                "Introduccion a la Ingenieria"
            };

            //Agregar elementos a la lista
            mats.Add("Matematicas Discretas");
            mats.Add("Compiladores e Interpretes");
            Imprime(mats);

            //Agregar un rango de materias
            string[] mopt = {
                "Seguridad en Redes y Sistemas (OP)",
                "Topicos Selectos de Redes (OP)",
                "Criptografia Avanzada (OP)"
            };
            mats.AddRange(mopt);
            Imprime(mats);

            //Ordenar la lista
            mats.Sort();
            Imprime(mats);

            //Invertir los elementos de la lista
            mats.Reverse();
            Imprime(mats);

            //Buscar un elemento en la lista en base a una condición
            Console.WriteLine("Materias que tengan la palabra 'Discretas'");
            string mat = mats.Find(x => x.Contains("Discretas"));
            Console.WriteLine(mat);

            //Buscar todas la materias optativas en la lista
            Console.WriteLine("\nMaterias optativas");
            var mo = mats.FindAll(x => x.Contains("(OP)"));
            Imprime(mo);
        }
        static void Imprime(List<string> lista){
            //foreach(string m in lista){ Console.WriteLine(m);}
            lista.ForEach(m => Console.WriteLine(m));
            Console.WriteLine();
        }
    }
}
