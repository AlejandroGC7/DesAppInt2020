using System;

namespace p02_AreaCirculo
{
    class Program
    {
        static void Main(string[] args)
        {
            float radio = 0;
            double area = 0;

            Console.Clear();
            Console.WriteLine("Dame el radio del circulo: ");
            radio = float.Parse(Console.ReadLine());
            area = Math.PI * Math.Pow(radio,2);

            Console.WriteLine($"El area es {area}");

        }
    }
}
