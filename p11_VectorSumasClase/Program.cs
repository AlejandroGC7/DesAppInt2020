//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Programa que imprime cuantos números son ceros, cuantos son negativos, cuantos positivos, la suma de los negativos
//y la suma de los positivos de un vector de 30 elementos aleatorios.
//Desarrollo de Aplicaciones en Internet.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p11_VectorSumasClase
{
    class Program
    {
        static void Main(string[] args)
        {
            int cer=0, pos=0, neg=0;
            double spos=0, sneg=0;

            const int arreglo = 30; 
            double[] A = new double[arreglo];
            Random rnd = new Random();    //Crear un objeto aletorio

            Console.WriteLine($"Vector A[]: ");

            for(int i=0; i<A.Length; i++){
                A[i] = rnd.Next(-10,100);
                Console.Write($"{A[i]} ");
                if(A[i]>0){
                    pos++;
                    spos+=A[i];
                }
                else if(A[i]<0){
                    neg++;
                    sneg+=A[i];
                }
                else
                    cer++;
            }
            Console.WriteLine($"\nNumero de Ceros: {cer}");
            Console.WriteLine($"Numero Positivos: {pos} Suma: {spos}");
            Console.WriteLine($"Numero Negativos: {neg} Suma: {sneg}");
        }
    }
}
