//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Programa que muestra el cubo de 20 números almacenados aleatoriamente en un vector.
//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//03/09/2020

using System;

namespace p10_VectorCubo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleatorio = new Random();    //Crear un objeto aletorio
            const int arreglo = 20; 
            double[] A = new double[arreglo];
            double[] B = new double[arreglo];

            for(int i=0; i<arreglo; i++){
                A[i] = aleatorio.Next(0,10) + 1;
                B[i] = Math.Pow(A[i],3);
            }

            Console.WriteLine($"=============VECTORES============");
            Console.WriteLine($"|\tA[ ] \t| \tA[ ]^3  |");
            Console.WriteLine($"=================================");
            for(int i=0; i<arreglo; i++){
                Console.WriteLine($"\n|\t{A[i]} \t| \t{B[i]}  \t|");
            }
            Console.WriteLine($"=================================");
        }
    }
}
