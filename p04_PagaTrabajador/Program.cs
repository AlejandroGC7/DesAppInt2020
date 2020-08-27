using System;

// Programa que calcula la paga de un trabajador dado, nombre, horas, paga y tasa de impuestos
// Alejandro García Cortés

namespace p04_PagaTrabajador
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int horas;
            float paga, tasa=0.10f;
            float impuesto, pagabruta, paganeta;

            Console.WriteLine("Calculando la paga del trabajador");
            Console.WriteLine("Dame el nombre"); nombre = Console.ReadLine();
            Console.WriteLine("Dame el horas"); horas = int.Parse(Console.ReadLine());
            Console.WriteLine("Dame la paga"); paga = float.Parse(Console.ReadLine());

            pagabruta = horas * paga;
            impuesto = pagabruta * tasa;
            paganeta = pagabruta - impuesto;

            Console.WriteLine($"El trabajador de nombre {nombre}");
            Console.WriteLine($"Trabajo {horas} horas");
            Console.WriteLine($"Con una paga de {paga} pesos");
            Console.WriteLine($"Por lo cual recibe una paga bruta de {pagabruta} pesos");
            Console.WriteLine($"Esto genera un impuesto de {impuesto} pesos");
            Console.WriteLine($"Al final llega a su casa con la miserable cantidad de {paganeta} pesos");

        }
    }
}
