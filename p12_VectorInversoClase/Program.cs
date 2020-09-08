//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Programa que imprime el vector inverso de un vector de 15 elementos aleatorios.
//Desarrollo de Aplicaciones en Internet.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p12_VectorInversoClase
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arreglo = 15; 
            double[] A = new double[arreglo];
            double[] B = new double[arreglo];
            Random rnd = new Random();    //Crear un objeto aletorio
            
            for(int i=0; i<arreglo; i++){
                A[i] = rnd.Next(1, 100);
                B[(A.Length-1)-i] = A[i];
            }
            Console.WriteLine("\nElementos A[]:"); ImpArreglo(A);
            Console.WriteLine("\nElementos B[]:"); ImpArreglo(B);

            Array.Sort(A);
            Console.WriteLine("\nElementos A[] (ordenado):"); ImpArreglo(A);
        }

         static void ImpArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"{v[i]} ");
            }
        }
    }
}
