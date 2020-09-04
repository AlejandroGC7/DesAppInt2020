//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN

//Programa que calcula e imprime:
//-Elemento mayor
//-Elemento menor
//-La media de los números (promedio)
//-La varianza *
//-La desviación estándar *
//de un vector ingresado por el usuario

//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//03/09/2020

using System;

namespace p14_VectorEstadisticas
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arreglo = 10; 
            float[] A = new float[arreglo];

            //Ingresar Arreglo
            Console.WriteLine($"\n========ARREGLO===========");
            for(int i=0; i<arreglo; i++){
                Console.Write($"Ingresar A[{i}]: "); 
                A[i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine($"\n=========================");
            Console.WriteLine($"|      ESTADISTICAS     |");
            Console.WriteLine($"=========================");
            MayorMenor(arreglo,A);     //Llamar a la función MayorMenor e imprimir el resultado
            Mediana(arreglo,A);     //Llamar a la función Mediana e imprimir el resultado
            Varianza(arreglo,A);     //Llamar a la función Varianza e imprimir el resultado
            DesviacionE(arreglo,A);     //Llamar a la función DesviacionE e imprimir el resultado
            Console.WriteLine($"=========================");
        }

        public static void MayorMenor(int tamaño, float[] p3)
        {
            double mayor=p3[0], menor=p3[0];

            for(int i=0; i<tamaño; i++){
                if(p3[i] > mayor)
                    mayor = p3[i];
                
                else if (p3[i] < menor)
                    menor = p3[i];
            }
            Console.WriteLine($"| Mayor: \t{mayor} \t|");
            Console.WriteLine($"| Menor: \t{menor} \t|");
       }
        
        public static void Mediana(int tamaño, float[] p3)
        {
            double suma=0, promedio=0;

            for(int i=0; i<tamaño; i++)
                suma+=p3[i];
            
            promedio=suma/tamaño;

            Console.WriteLine($"| Mediana: \t{promedio} \t|");
       }

       public static void Varianza(int tamaño, float[] p4)
        {
            double r=0, t=0;

            for(int i=0; i<tamaño; i++)
                r+=Math.Pow(p4[i],2);
            
            t=((r/10)-1);

            Console.WriteLine($"| Varianza: \t{t} \t|");
            
        }

        public static void DesviacionE(int tamaño, float[] p5)
        {
            double r=0, t=0, h=0;

            for(int i=0; i<10; i++)
                r+=Math.Pow(p5[i],2);
            
            t=((r/10)-1);
            h=Math.Sqrt(t);

            Console.WriteLine($"| Desviacion Estandar: \t{h} \t|");            
        }
    }
}
