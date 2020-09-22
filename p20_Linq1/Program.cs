//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso del lenguaje LINQ.
//Alejandro García Cortés.
//22/09/2020.

using System;
using System.Collections.Generic;
using System.Linq;

namespace p20_Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fuente de datos
            int[] numeros = new int[] {10,25,-1,10,0,320,22,65,800,-4,20,20,1000,2000,-233};

            //Crear la consulta (búsqueda de números pares)
            IEnumerable<int> qrypares =
                from num in numeros
                where (num%2)==0
                select num;

            //Ejecutar consulta
            Console.WriteLine($"\nNumeros Pares: {qrypares.Count()}");
            //Mostrar consulta
            foreach(int n in qrypares)
                Console.Write($"{n} ");
            
            //Crear la consulta (búsqueda de números impares)
            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();   //En un arreglo

            //Ejecutar consulta
            Console.WriteLine($"\nNumeros Impares: {qryimpares.Count()}");
            //Mostrar consulta
            for(int i=0; i<qryimpares.Count(); i++)
                Console.Write($"{qryimpares[i]} ");                

            //Crear consulta para sacar los números mayores a 100 y ponerlos en una lista
            var mayores = (from num in numeros where num>=100 select num).ToList();  //En una lista
            //Ejecutar consulta
            Console.WriteLine($"\nNumeros Mayores que 100: {mayores.Count()}");
            //Mostrar consulta
            mayores.ForEach(n => Console.Write($"{n} "));
        }
    }
}
