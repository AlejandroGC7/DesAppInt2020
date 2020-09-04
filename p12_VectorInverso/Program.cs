//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Programa que imprime el vector inverso de un vector de 15 elementos aleatorios.
//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//03/09/2020

using System;

namespace p12_VectorInverso
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleatorio = new Random();    //Crear un objeto aletorio
            const int arreglo = 15; 
            int[] A = new int[arreglo];
            //int[] B = new int[arreglo];

            for(int i=0; i<arreglo; i++){
                A[i] = aleatorio.Next(-20, 20) + 1;
            }
            Console.WriteLine("========Arreglo ANTES de invertir========");
            foreach(int B in A){
                Console.Write($"{B} ");
            }
            // La siguiente línea invierte el arreglo:
            Array.Reverse(A);
            Console.WriteLine("\n\n========Arreglo DESPUÉS de invertir========");
            foreach(int B in A){
                Console.Write($"{B} ");
            }
        }
    }
}
