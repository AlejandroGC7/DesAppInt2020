//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de un Delegado como Parámetro(5).
//Alejandro García Cortés.
//01/10/2020.

using System;

namespace p29_Delegados5
{
    //Declarar el delegado
    public delegate void MiDelegado(string msj);

    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1, d2, d3;     //Se crea instancia de MiDelegado
            Console.Clear();

            d1 = ClaseA.MetodoA;
            d1("Forma Tradicional A"); //Se invoca al delegado de forma tradicional
            InvocaDelegado(d1);    //Se invoca al delegado como parámetro
            Console.WriteLine();

            d2 = ClaseB.MetodoB;
            d2("Forma Tradicional B"); //Se invoca al delegado de forma tradicional
            InvocaDelegado(d2);    //Se invoca al delegado como parámetro
            Console.WriteLine();

            d3 = (string msj) => Console.WriteLine($"LLamando metodo como expresion Lambada: {msj}");
            d3("Forma Tradicional Lambada"); //Se invoca al delegado de forma tradicional
            InvocaDelegado(d3);    //Se invoca al delegado como parámetro
            Console.WriteLine();
        }

        //Este método recibe como parámetro un delegado
        static void InvocaDelegado(MiDelegado del){
            del("Hola desde el invocador");  //Se invoca al delegado
        }
    }

    class ClaseA{
        public static void MetodoA(string msj) => Console.WriteLine($"LLamando al MetodoA de ClaseA: {msj}");
    }

    class ClaseB{
        public static void MetodoB(string msj) => Console.WriteLine($"LLamando al MetodoB de ClaseB: {msj}");
    }
}
