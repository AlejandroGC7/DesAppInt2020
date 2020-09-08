//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.

//Programa que calcula e imprime:
//-Elemento mayor.
//-Elemento menor.
//-La media de los números (promedio).
//-La varianza. *
//-La desviación estándar. *
//de un vector ingresado por el usuario.

//Desarrollo de Aplicaciones en Internet.
//Alejandro García Cortés.
//08/09/2020.

using System;

namespace p14_VectorEstadisticasClase
{
    class Program
    {
        static void Main(string[] args)
        {
            int arreglo=0;
            double lamedia=0, lavarianza=0;
            Console.WriteLine("¿Cuantos elementos desea?"); arreglo = int.Parse(Console.ReadLine());
            double[] A = new double[arreglo];

            Console.WriteLine("\nDame los elementos del arreglo: "); LeerArreglo(A);
            Console.WriteLine($"\n=========================");
            Console.WriteLine($"|      ESTADISTICAS     |");
            Console.WriteLine($"=========================");
            Console.WriteLine($"| Mayor: \t{Mayor(A)} \t|");
            Console.WriteLine($"| Menor: \t{Menor(A)} \t|");
            lamedia = Mediana(A);
            Console.WriteLine($"| Mediana: \t{Mediana(A)} \t|");
            lavarianza = Varianza(A,lamedia);
            Console.WriteLine($"| Varianza: \t{lavarianza} \t|");
            Console.WriteLine($"| Desviacion Estandar: \t{DesviacionE(lavarianza)} \t|");
        }
        static void LeerArreglo(double[] v){
            for(int i=0; i<v.Length; i++){
                Console.Write($"Elemento A[{i}]:");
                v[i] = double.Parse(Console.ReadLine());
            }
        }
        static double Mayor(double[] v){
            double m=v[0];
            for(int i=0; i<v.Length; i++)
                if(v[i]>m) m=v[i];
            return m;
        }
        static double Menor(double[] v){
            double m=v[0];
            for(int i=0; i<v.Length; i++)
                if(v[i]<m) m=v[i];
            return m;
        }
        static double Mediana(double[] v){
            double suma=0;
            for(int i=0; i<v.Length; i++)
               suma+=v[i];
            return suma/v.Length;
        }
        static double Varianza(double[] v,double m){
            double suma=0;   
            for(int i=0; i<v.Length; i++)
                suma += Math.Pow((v[i] - m), 2);
            return suma/v.Length - 1;
        }
        static double DesviacionE(double var){
            return Math.Sqrt(var);
        }
    }
}
