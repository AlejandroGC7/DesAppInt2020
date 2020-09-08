//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Programa que multiplica el primer elemento de A con el último elemento de B y luego el segundo elemento de A por el
//diecinueveavo elemento de B y así sucesivamente y muestra los resultados.
//Desarrollo de Aplicaciones en Internet.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p13_VectorMultiplicaClase
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arreglo = 10;
            double[] A = new double[arreglo];
            double[] B = new double[arreglo];
            double[] C = new double[arreglo];

            Console.WriteLine("\nDame los elementos de A[]"); LeerArreglo(A);
            Console.WriteLine("\nDame los elementos de B[]"); LeerArreglo(B);
            
            for(int i=0; i<arreglo; i++){
                C[i] = A[i] * B[(arreglo-1)-i];
            }

            Console.WriteLine("\nElementos A[]:"); ImpArreglo(A);
            Console.WriteLine("\nElementos B[]:"); ImpArreglo(B);
            Console.WriteLine("\nElementos C[]:"); ImpArreglo(C);
        }

        static void LeerArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"Elemento [{i}]:");
                v[i] = double.Parse(Console.ReadLine());
            }
        }
        static void ImpArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.WriteLine($"{v[i]} ");
            }
        }
    }
}
