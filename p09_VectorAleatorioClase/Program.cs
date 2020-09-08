//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Desarrollo de Aplicaciones en Internet
//Programa que imprime el vector resultante de la suma (elemento A[1]+B[1], y asi sucesivamente) de otros dos 
//vectores (A y B) con 15 números aleatorios
//Alejandro García Cortés
//08/09/2020

using System;

namespace p09_VectorAleatorioClase
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arreglo = 15; 
            int[] A = new int[arreglo];
            int[] B = new int[arreglo];
            int[] C = new int[arreglo];

            Random rnd = new Random();    //Crear un objeto aletorio

            for(int i=0; i<A.Length; i++){
                A[i] = rnd.Next(1,100);
                B[i] = rnd.Next(1,100);
                C[i] = A[i] + B[i];
            }
            
            Console.WriteLine("Elementos del vector A[]:"); ImpArreglo(A);
            Console.WriteLine("Elementos del vector B[]:"); ImpArreglo(B);
            Console.WriteLine("Elementos del vector C[]:"); ImpArreglo(C);
        }
        static void ImpArreglo(int[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"{v[i]} ");
            }
        }
    }
}
