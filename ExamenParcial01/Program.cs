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
            //Ingresar >> Datos generales de la red (Empresa, Propietario, Domicilio)
            Red mired =  new Red("Red Patito S.A. de C.V.", "Mr. Pato Macdonald", "Av. Princeton 123, Orlando Florida");
            
            //Agregar nodos a la red (Ip, Tipo (servidor, equipoactivo, computadora), Puertos, Saltos, SO (windows, linux, ios, otro))
            mired.AgregarNodo(new Nodo("192.168.0.10","servidor",5,10,"linux"));
            mired.AgregarNodo(new Nodo("192.168.0.12","equipoactivo",2,12,"ios"));
            mired.AgregarNodo(new Nodo("192.168.0.20","computadora",8,5,"windows"));
            mired.AgregarNodo(new Nodo("192.168.0.15","servidor",10,22,"linux"));

            //Agregar vulnerabilidades a cada nodo (Clave, Vendedor, Descripcion, Tipo (local, remota), Fecha)
            mired.Nodos[0].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2015-1635","microsoft","HTTP.sys permite a atacantes remotos ejecutar código arbitrario",
                "remota",new DateTime(2015,04,14)));
            mired.Nodos[0].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2017-0004","microsoft","El servicio LSASS permite causar una denegación de servicio",
                "local",new DateTime(2017,01,10)));
            mired.Nodos[1].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2017-3847","cisco","Cisco Firepower Management Center XSS",
                "remota",new DateTime(2017,02,21)));
            mired.Nodos[2].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2009-2504","microsoft"," Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1",
                "local",new DateTime(2009,11,13)));
            mired.Nodos[2].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2016-7271","microsoft","Elevación de privilegios Kernel Segura en Windows 10 Gold",
                "local",new DateTime(2016,12,20)));
            mired.Nodos[2].AgregarVulnerabilidad(new Vulnerabilidad("CVE-2017-2996","adobe","Adobe Flash Player 24.0.0.194 corrupción de memoria explotable",
                "remota",new DateTime(2017,02,15)));

            //Mostrar >> Datos generales de la red
            Console.WriteLine("\n>> Datos generales de la red:\n");
            Console.WriteLine($"Empresa \t: {mired.Empresa}");
            Console.WriteLine($"Propietario \t: {mired.Propietario}");
            Console.WriteLine($"Domicilio \t: {mired.Domicilio}");
            
            //Total de nodos de la red
            Console.WriteLine("\nTotal nodos red: {0}", mired.Nodos.Count());
            //Total de vulnerabilidades
            Console.WriteLine($"Total vulnerabilidades: {mired.Nodos.Sum(nod => nod.Vulnerabilidades.Count())}");
            
            //Mostrar >> Datos generales de los nodos y el cálculo de vilnerabilidades en cada nodo
            Console.WriteLine("\n>> Datos generales de los nodos:\n");
            foreach(Nodo nod in mired.Nodos){
                Console.WriteLine($"Ip: {nod.Ip}, Tipo: {nod.Tipo}, Puertos: {nod.Puertos}, Saltos: {nod.Saltos}, SO: {nod.SO}, TotVul: {nod.Vulnerabilidades.Count()}");
            }

            //Filtrar el mayor número de saltos
            var mayor = (from sal in mired.Nodos
                select sal.Saltos).Max();
            Console.WriteLine($"\nMayor numero de saltos: {mayor}");
            //Filtrar el menor número de saltos
            var menor = (from sal in mired.Nodos
                select sal.Saltos).Min();
            Console.WriteLine($"Menor numero de saltos: {menor}");

            //Mostrar >> Vulnerabilidades por nodo
            Console.WriteLine("\n>> Vulnerabilidades por nodo:");  //Mostrar las vulnerabilidades por nodo
            foreach(Nodo nod in mired.Nodos){
                Console.WriteLine($"\n> Ip: {nod.Ip}, Tipo: {nod.Tipo}");      //Mostrar el Ip y Tipo de nodo
                Console.WriteLine((nod.Vulnerabilidades.Count()!=0)? "\nVulnerabilidades:":"\nNo tiene vulnerabilidades...");   //Verificar si el nodo actual tiene vulnerabilidades o no
                foreach(Vulnerabilidad vul in nod.Vulnerabilidades){
                    double antiguedad = ((DateTime.Now - vul.Fecha).TotalDays)/365;     //Calcular la antiguedad de cada vulnerabilidad (fecha actual - fecha vulnerabilidad (años))
                    //Imprimir los datos generales de las vulnerabilidades por cada nodo
                    Console.WriteLine($"\nClave: {vul.Clave}, Vendedor: {vul.Vendedor}, Descripcion: {vul.Descripcion}, Tipo: {vul.Tipo}, Fecha: {vul.Fecha}, Antiguedad: {(int)antiguedad}");
                }
                Console.WriteLine();
            }
        }
    }
}
