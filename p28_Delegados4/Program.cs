//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de un Delegado Genérico(4).
//Alejandro García Cortés.
//01/10/2020.

using System;

namespace p28_Delegados4
{
    //Declarar delegado genérico
    public delegate T Suma<T>(T p1, T p2);

    class Program
    {
        static void Main(string[] args)
        {
            Suma<int> d1 = Sumar;   //Delegado a método Sumar de tipo int con parámetros (int, int)
            Console.WriteLine($"La suma es: {d1(20,30)}");

            Suma<string> d2 = Concatenar;   //Delegado a m+etodo Concatenar de tipo string con parámetros (string, string)
            Console.WriteLine($"La cadena es: {d2("Hola mundo"," cruel")}");

            //Suma<string> d3 = NoSePuede; <---Esto no se puede (diferentes tipos de parámetros})
            Console.WriteLine($"Diferentes tipos de parametro: {NoSePuede("Parametro A",100)}");    //Hacer invocación directa

            Console.WriteLine();
        }

        public static int Sumar(int a, int b) => a + b;
        public static string Concatenar(string a, string b) => a + b;
        public static string NoSePuede(string a, int b) => $"{a} - {b.ToString()}";
    }
}
