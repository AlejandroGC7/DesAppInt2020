//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Desarrollo de Aplicaciones en Internet
//Programa que imprime el vector resultante de la suma (elemento A[1]+B[1], y asi sucesivamente) de otros dos 
//vectores (A y B) con 15 números aleatorios
//Alejandro García Cortés
//03/09/2020

using System;

namespace p09_VectorAleatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleatorio = new Random();    //Crear un objeto aletorio
            const int arreglo = 15; 
            int[] A = new int[arreglo];
            int[] B = new int[arreglo];
            int[] C = new int[arreglo];

            for(int i=0; i<arreglo; i++){
                A[i] = aleatorio.Next(0,10) + 1;
                B[i] = aleatorio.Next(0,10) + 1;
                C[i] = A[i] + B[i];
            }

            Console.WriteLine($"==================VECTORES=====================");
            Console.WriteLine($"\tA[ ] \t+ \tB[ ] \t+ \tC[ ]");
            for(int i=0; i<arreglo; i++){
                Console.WriteLine($"\n\t{A[i]} \t+ \t{B[i]} \t= \t{C[i]}");
            }
        }
    }
}
