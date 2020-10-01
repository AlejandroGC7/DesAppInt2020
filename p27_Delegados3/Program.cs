//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de un Delegado Multicast con Parámetros(3).
//Alejandro García Cortés.
//01/10/2020.

using System;

namespace p27_Delegados3
{
    //Declarar el delegado
    public delegate int MiDelegado(int a, int b);
    
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1 = A.MetodoA;
            MiDelegado d2 = B.MetodoB;

            //Invocar delegados de forma separada
            Console.WriteLine($"La suma es: {d1(10,20)}");
            Console.WriteLine($"La multiplicación es: {d2(10,20)}");
            Console.WriteLine();

            //Delegado multicast que une los 2 métodos
            MiDelegado d = d1 + d2;
            Console.WriteLine($"El resultado es: {d(5,2)}");    //Regresa el resultado del último método invocado
            Console.WriteLine();

            Console.WriteLine();
        }
    }

    public class A{
        public static int MetodoA(int a, int b) => a + b;
    }

    public class B{
        public static int MetodoB(int a, int b) => a * b;
    }
}
