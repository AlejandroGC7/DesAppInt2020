//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de Interfaces(1).
//Alejandro García Cortés.
//29/09/2020.

using System;

namespace p23_Interfaces1
{
    class Program
    {
        public interface IAnimal{
            string Nombre {get; set;}
            void Llorar();
        }

        class Perro : IAnimal{
            public Perro(string nombre) => Nombre = nombre;
            public string Nombre {get; set;}
            public void Llorar() => Console.WriteLine("Woff Woff");
        }

        class Gato : IAnimal{
            public Gato(string nombre) => Nombre = nombre;
            public string Nombre {get; set;}
            public void Llorar() => Console.WriteLine("Miaw Miaw");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nPrimer ejemplo de uso de interfaces:\n");
            
            Perro perro = new Perro("Sabueso");
            Console.WriteLine($"El perro {perro.Nombre}");
            perro.Llorar();

            Gato gato =new Gato("Misifous");
            Console.WriteLine($"El gato {gato.Nombre}");
            gato.Llorar();
        }
    }
}
