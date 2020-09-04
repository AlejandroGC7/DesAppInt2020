//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Programa que multiplica el primer elemento de A con el último elemento de B y luego el segundo elemento de A por el
//diecinueveavo elemento de B y así sucesivamente y muestra los resultados
//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//03/09/2020

using System;

namespace p13_VectorMultiplica
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] A = {2,5,10,2,8,4,1,3,7,8};
           int[] B = {4,7,1,2,9,8,6,4,20,5};
           const int arreglo = 10;
           int[] C = new int[arreglo];

            // La siguiente línea invierte el arreglo:
            Array.Reverse(B);
            
            Console.WriteLine("\n================VECTOR MULTIPLICA================");
            Console.WriteLine("|\tA[] \t* \tB[] \t= \tC[] \t|");
            Console.WriteLine("=================================================");

            for(int i=0; i<arreglo; i++){
                C[i] = A[i] * B[i];
                Console.WriteLine($"|\t{A[i]} \tX \t{B[i]} \t= \t{C[i]} \t|");
            }
            Console.WriteLine("=================================================");
        }
    }
}
