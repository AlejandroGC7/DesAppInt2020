//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que calcula e imprime el promedio de un vector de valores constantes.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p08_VectorPromedioClase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vector con 50 valores constantes
            int[] vector = {10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100};
            
            int suma=0, nmp=0;
            float prom;
            int[] v2;
            v2 = new int[50];
            
            for(int i=0; i<vector.Length; i++){
                Console.Write($"{vector[i]} ");
                suma+=vector[i];
            }
            
            prom = suma/vector.Length;
            Console.WriteLine($"\n\nEl promedio es: {prom}");
            
            Console.WriteLine($"\nLista de valores mayores al promedio: {prom}");
            foreach(int v in vector){
                if(v>prom){
                    Console.Write($"{v} ");
                    nmp++;
                }
            }
            Console.WriteLine($"\n\nElementos mayores al promedio: {nmp}\n");

        }
    }
}
