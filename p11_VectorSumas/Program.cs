//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Programa que imprime cuantos números son ceros, cuantos son negativos, cuantos positivos, la suma de los negativos
//y la suma de los positivos de un vector de 30 elementos aleatorios.
//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//03/09/2020

using System;

namespace p11_VectorSumas
{
    class Program
    {
        static void Main(string[] args)
        {
            int ceros=0, positivos=0, negativos=0;
            int sp=0, sn=0;
            Random aleatorio = new Random();    //Crear un objeto aletorio
            const int arreglo = 30; 
            int[] A = new int[arreglo];

            Console.WriteLine($"Vector: ");

            for(int i=0; i<arreglo; i++){
                A[i] = aleatorio.Next(-10,10) + 1;
                ceros += A[i]==0 ? 1 : 0;
                if(A[i]>=0){
                    positivos++;
                    sp+=A[i];
                }
                else{
                    negativos++;
                    sn+=A[i];
                }
                Console.Write($"{A[i]} ");
            }

            Console.WriteLine($"\nNumero Ceros: {ceros}");
            Console.WriteLine($"Numero Positivos: {positivos}");
            Console.WriteLine($"Numero Negativos: {negativos}");
            Console.WriteLine($"La suma de los numeros positivos es {sp} y los negativos {sn}");
        }
    }
}
