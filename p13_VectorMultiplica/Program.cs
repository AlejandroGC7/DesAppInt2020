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
            const int arreglo = 10;
            double[] A = new double[arreglo];
            double[] B = new double[arreglo];
            double[] C = new double[arreglo];

            Console.WriteLine("\nIngresa los elementos A[]"); LeerArreglo(A);
            Console.WriteLine("\nIngresa los elementos B[]"); LeerArreglo(B);
            
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
        static void LeerArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"Elemento [{i}]:");
                v[i] = double.Parse(Console.ReadLine());
            }
        }
    }
}
