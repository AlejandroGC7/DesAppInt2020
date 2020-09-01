//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Desarrollo de Aplicaciones en Internet
//Programa que imprime la secuenncia de números seleccionada
//Alejandro García Cortés
//01/09/2020

using System;

namespace p05_Ciclos
{
    class Program
    {
        static int Main(string[] args)
        {
            int op, c=0, suma=0;
            Console.Clear();
            if(args.Length == 0){   //Verifica que se hayan pasado argumentos de línea de comando
                Menu();
                return 1;
            }
            op = int.Parse(args[0]);    //Tomo el primer argumento de la línea de comando
            
            switch(op){
                case 1: {   //Números del 1 al 100 con while
                    c=1; suma=0;
                    while(c <= 100){
                        Console.Write($"{c} ");
                        suma+=c;
                        c++;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
                case 2: {      //Números del 100 al 1 con do-while
                    c=100; suma=0;
                    do{
                        Console.Write($"{c} ");
                        suma+=c;
                        c--;
                    } while(c>=1);
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
                case 3: {   //Números del 50 al 200 con for
                    suma=0;
                    for (int i=50; i<=200; i++){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
                case 4: {   //Números del 2 al 100 (pares) con for
                    suma=0;
                    for (int i=2; i<=100; i+=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;  //Números del 99 al 1 (impares) con for
                case 5: {
                    suma=0;
                    for (int i=99; i>=1; i-=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
                case 6: {      //Números del 272 al 40 (decrementos de 4) con while
                    c=272; suma=0;
                    while(c>=40){
                        Console.Write($"{c} ");
                        suma+=c;
                        c-=4;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
            }
            return 0;
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("===========USO DE CICLOS EN EL LENGUAJE C#===========");
            Console.WriteLine("|             [1] Números del 1 al 100              |");
            Console.WriteLine("|             [2] Números del 100 al 1              |");
            Console.WriteLine("|             [3] Números del 50 al 200             |");
            Console.WriteLine("|      [4] Números del 2 al 100 solo los pares      |");
            Console.WriteLine("|      [5] Números del 99 al 1 solo los impares     |");
            Console.WriteLine("|   [6] Números del 272 al 40 en decrementos de 4   |");
            Console.WriteLine("=====================================================");
        }
    }
}
