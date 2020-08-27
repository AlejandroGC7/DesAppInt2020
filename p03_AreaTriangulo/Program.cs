using System;

namespace p03_AreaTriangulo
{
    class Program
    {
        //Este programa permite calcular el área del triángulo
        //Alejandro García Cortés
        static void Main(string[] args)
        {
            float baseT, alturaT, areaT;
            
            Console.WriteLine("Dame la base:"); baseT = float.Parse(Console.ReadLine());
            Console.WriteLine("Dame la altura:"); alturaT = float.Parse(Console.ReadLine());

            areaT = baseT * alturaT / 2;
            Console.WriteLine($"Un triangulo de base {baseT} y altura {alturaT} tiene un area de {areaT}");
        }
    }
}
