//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Programa que muestra el cubo de 20 números almacenados aleatoriamente en un vector.
//Desarrollo de Aplicaciones en Internet.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p10_VectorCuboClase
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arreglo = 20; 
            double[] A = new double[arreglo];
            double[] B = new double[arreglo];
            Random rnd = new Random();    //Crear un objeto aletorio

            for(int i=0; i<arreglo; i++){
                A[i] = rnd.Next(-10,50);
                B[i] = Math.Pow(A[i],3);
            }

            Console.WriteLine("\nElementos de A[]:"); ImpArreglo(A);
            Console.WriteLine("\nElementos de B[]:"); ImpArreglo(B);

        }
        static void ImpArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"{v[i]} ");
            }
        }
    }
}
