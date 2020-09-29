//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso de Interfaces(2).
//Alejandro García Cortés.
//29/09/2020.

using System;

namespace p24_Interfaces2
{
    public class Organismo{
        public void Respiracion() => Console.WriteLine("Respiracion");
        public void Movimiento() => Console.WriteLine("Movimiento");
        public void Crecimiento() => Console.WriteLine("Crecimiento");
    }

    public interface IAnimales{
        void MultiCelular();
        void SangreCaliente();
    }

    public interface ICanino : IAnimales{
        void Correr();
        void CuatroPatas();
    }

    public interface IPajaro : IAnimales{
        void Volar();
        void DosPatas();
    }

    public class Perro : Organismo, ICanino{
        public void MultiCelular() => Console.WriteLine("Multicelular (perro)");
        public void SangreCaliente() => Console.WriteLine("Sangre Caliente (perro)");
        public void Correr() => Console.WriteLine("Correr (perro)");
        public void CuatroPatas() => Console.WriteLine("Cuatro Patas (perro)");
    }

    public class Perico : Organismo, IPajaro{
        public void MultiCelular() => Console.WriteLine("Multicelular (perico)");
        public void SangreCaliente() => Console.WriteLine("Sangre Caliente (perico)");
        public void Volar() => Console.WriteLine("Volar (perico)");
        public void DosPatas() => Console.WriteLine("Dos Patas (perico)");
    }
    
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("\nSegundo ejemplo de uso de interfaces:\n");

            Perro perro = new Perro();
            Console.WriteLine("\nCaracteristicas del Perro:\n");
            perro.Respiracion();
            perro.Movimiento();
            perro.Crecimiento();
            perro.MultiCelular();
            perro.SangreCaliente();
            perro.Correr();
            perro.CuatroPatas();

            Perico perico = new Perico();
            Console.WriteLine("\nCaracteristicas del Perico:\n");
            perico.Respiracion();
            perico.Movimiento();
            perico.Crecimiento();
            perico.MultiCelular();
            perico.SangreCaliente();
            perico.Volar();
            perico.DosPatas();
        }
    }
}
