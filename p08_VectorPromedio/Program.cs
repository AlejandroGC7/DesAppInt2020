//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Desarrollo de Aplicaciones en Internet
//Programa que imprime el promedio de 50 valores constantes almacenados en un arreglo, el 
//número de datos mayores que el promedio y una lista de esos valores que son mayores que el promedio.
//Alejandro García Cortés
//03/09/2020

using System;

namespace p08_VectorPromedio
{
    class Program
    {
        static void Main(string[] args)
        {
            int suma=0, mayor=0, promedio;
            //Vector con 50 valores constantes
            int[] v = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50};
            int[] v2;
            v2 = new int[50];
            
            for(int i=0; i<v.Length; i++){
                suma+=v[i];
            }
            
            promedio = suma/50;

            for(int i=0; i<v.Length; i++){
                if(v[i]>promedio){
                    v2[i] = v[i];
                    mayor++;
                }
            }

            Console.WriteLine($"La suma de los 50 valores del arreglo es {suma}");
            Console.WriteLine($"El promedio de los 50 valores del arreglo es {promedio}");
            Console.WriteLine($"El numero de datos mayores al promedio {promedio} es {mayor}");
            Console.WriteLine($"\nLa lista de valores mayores al promedio es la siguiente...");

            for(int i=0; i<v.Length; i++)
                if(v2[i]!=0)
                    Console.Write($"{v2[i]} ");
        }
    }
}
