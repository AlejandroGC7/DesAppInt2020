//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN
//Programa que permite pedir una pizza en base a la elección del usuario
//Desarrollo de Aplicaciones en Internet
//Alejandro García Cortés
//01/09/2020

using System;

namespace p06_Pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            //Variables para recibir los parámetros
            char tam, cub, don;
            string[] ings;

            //Variables para guardar la elección del usuario
            string tamaño, ingredientes="", cubierta, donde;

            Console.Clear();
            if(args.Length == 0){      //Revisar que existan parámetros en la línea de comando
                Menu();
                return 1;
            }

            //Elegir tamaño de la pizza
            tam = char.Parse(args[0].ToUpper());    //Tomar el primer parámetro
            if (tam=='P') tamaño="Pequeña";
            else if (tam=='M') tamaño="Mediana";
            else if (tam=='G') tamaño="Grande";
            else tamaño="NO VALIDO";

            //Elegir ingredientes de la pizza
            ings=args[1].Split("+");    //Separa los ingredientes en base al signo +
            foreach(string i in ings){
                switch(char.Parse(i.ToUpper())){
                    case 'E': ingredientes+="Extraqueso "; break;
                    case 'C': ingredientes+="Champiñones "; break;
                    case 'P': ingredientes+="Piña "; break;
                }
            }

            //Elegir el tipo de cubierta de la pizza
            cub = char.Parse(args[2].ToUpper());
            cubierta = cub=='D' ? "Delgada" : "Gruesa";

            //Elegir donde consumir la pizza
            don = char.Parse(args[3].ToUpper());
            donde = don=='A' ? "Aqui" : "LLevar";


            Console.WriteLine("\nLa pizza que pediste es la siguiente ");
            Console.WriteLine($"Tamaño: {tamaño}");
            Console.WriteLine($"Ingredientes: {ingredientes}");
            Console.WriteLine($"Cubierta: {cubierta}");
            Console.WriteLine($"Donde consumir: {donde}");

            return 0;
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("Elige las opciones segun la pizza que deseas");
            Console.WriteLine("Tamaño: (P)equeña, (M)ediana, (G)rande");
            Console.WriteLine("Especifique los ingredientes");
            Console.WriteLine("Ingredientes: (E)xtra queso, (C)hampiñones (P)iña -- (Unidos por +)");
            Console.WriteLine("Cubierta: (D)elgada, (G)ruesa");
            Console.WriteLine("Donde consumir: (A)qui, (L)levar");
        }
    }
}
