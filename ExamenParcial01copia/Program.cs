//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Materia: Desarrollo de Aplicaciones en Internet.
//Docente: Carlos Héctor Castañeda Ramírez.
//Alumno: Alejandro García Cortés.
//Fecha de entrega: 24/09/2020.

//-------------------------------------PRIMER EXAMEN PARCIAL------------------------------------------
//La empresa de Seguridad en Redes requiere de un sistema para almacenar los resultados de las pruebas
//de seguridad efectuadas a diferentes Nodos de una Red, que le permite generar un reporte de las 
//Vulnerabilidades encontradas y plantear una posible solución.
//----------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenParcial01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ingresar >> Datos generales de la red
            Red mired =  new Red("Red PAtito S.A. de C.V.", "Mr. Pato Macdonald", "Av. Princeton 123, Orlando Florida");
            //Lista de nodos
            List<Nodo> nodos = new List<Nodo>(){
                new Nodo{Ip="192.168.0.10", Tipo="servidor", Puertos=5, Saltos=10, SO="linux", TotVul=2},
                new Nodo{Ip="192.168.0.12", Tipo="equipoactivo", Puertos=2, Saltos=12, SO="ios", TotVul=1},
                new Nodo{Ip="192.168.0.20", Tipo="computadora", Puertos=8, Saltos=5, SO="windows", TotVul=3},
                new Nodo{Ip="192.168.0.15", Tipo="servidor", Puertos=10, Saltos=22, SO="linux", TotVul=0}
            };
            //Lista de vulnerabilidades
            //List<Vulnerabilidad> vulnerabilidades = new List<Vulnerabilidad>(){};
            //mired.Nodos[0].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2015-1635"," microsoft","HTTP.sys permite a atacantes remotos ejecutar código arbitrario",
            //    "remota"," 04/14/2015"));
            //mired.Nodos[1].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2017-0004,"," microsoft","El servicio LSASS permite causar una denegación de servicio",
            //    "local"," 01/10/2001"));

            //Mostrar >> Datos generales de la red
            Console.WriteLine("\n>> Datos generales de la red:\n");
            Console.WriteLine($"Empresa \t: {mired.Empresa}");
            Console.WriteLine($"Propietario \t: {mired.Propietario}");
            Console.WriteLine($"Domicilio \t: {mired.Domicilio}");
            
            //Total de nodos de la red
            Console.WriteLine("\nTotal nodos red: {0}", nodos.Count());
            //Total de vulnerabilidades
            Console.WriteLine($"Total vulnerabilidades: {nodos.Sum(vul => vul.TotVul)}");
            //Console.WriteLine("\nTotal vulnerabilidades: {0}", vulnerabilidades.Count());
            
            //Mostrar >> Datos generales de los nodos
            Console.WriteLine("\n>> Datos generales de los nodos:\n");
            nodos.ForEach(nod => Console.WriteLine(nod.ToString()));

            //Filtrar el mayor número de saltos
            var mayor = (from sal in nodos
                select sal.Saltos).Max();
            Console.WriteLine($"\nMayor numero de saltos: {mayor}");
            //Filtrar el menor número de saltos
            var menor = (from sal in nodos
                select sal.Saltos).Min();
            Console.WriteLine($"Menor numero de saltos: {menor}");

            //Mostrar >> Vulnerabilidades por nodo
            Console.WriteLine("\n>> Vulnerabilidades por nodo:\n");
            foreach(Nodo nod in nodos){
                Console.WriteLine($"> Ip: {nod.Ip}, Tipo: {nod.Tipo}\n");
                foreach(Vulnerabilidad vul in nod.Vulnerabilidades){
                    Console.WriteLine($"Clave: {vul.Clave}");
                }
                Console.WriteLine();
            }
        }
    }
}
