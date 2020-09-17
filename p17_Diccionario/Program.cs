//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que emplea el uso de Diccionarios.
//Alejandro García Cortés.
//17/09/2020.

using System;
using System.Collections.Generic;

namespace p17_Diccionario
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definición del diccionario y reserva de espacio en memoria
            Dictionary<string,string> midic = new Dictionary<string, string>();

            //Diccionario ordenado en base a la llave
            //SortedDictionary<string,string> midic = new SortedDictionary<string, string>();
            
            //Agregar elementos al diccionario
            midic.Add("txt", "Archivo de texto");
            midic.Add("jpg", "Archivo de imagen");
            midic.Add("mp3", "Archivo de sonido");
            midic.Add("html", "Archivo de texto html");
            midic.Add("exe", "Archivo de ejecutable");
            midic.Add("lll", "Archivo de tipo desconocido");

            //Acceder elemento a través de la llave
            Console.WriteLine(midic["html"]);

            //Verificar si una llave existe en el diccionario, si no agregarla
            if(midic.ContainsKey("elf"))
                Console.WriteLine("La llave ya existe en el diccionario");
            else
                midic.Add("elf","Archivo ejecutable en linux");

            //Borrar una entrada al diccionario en base a la llave
            if(midic.ContainsKey("lll"))
                midic.Remove("lll");
            
            //Recorrer el diccionario e imprimir la llave y su valor
            foreach(KeyValuePair<string, string> val in midic){
                Console.WriteLine($"{val.Key} - {val.Value}");
            }

            //Imprimir las llaves del diccionario
            foreach(string key in midic.Keys){
                Console.WriteLine($"{key}");
            }

            //Imprimir solo las entradas del diccionario
            foreach(string val in midic.Values){
                Console.WriteLine($"{val}");
            }

            //Borrar todas las entradas al diccionario
            midic.Clear();

        }
    }
}
