//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa que hace uso del lenguaje LINQ.
//Alejandro García Cortés.
//22/09/2020.

using System;
using System.Collections.Generic;
using System.Linq;

namespace p22_Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>(){
                new Estudiante{Matricula=111, Nombre="Juan Perez", Domicilio="Monterrey 123, Zacatecas", 
                Califs = new List<float>{97,92,81,60}},
                new Estudiante{Matricula=111, Nombre="Maria Lopez", Domicilio="Principal 126, Fresnillo", 
                Califs = new List<float>{75,84,91,39}},
                new Estudiante{Matricula=444, Nombre="Rodrigo Mata", Domicilio="Luis Moya 31, Rio Grande", 
                Califs = new List<float>{88,94,65,91}},
                new Estudiante{Matricula=444, Nombre="Juan Perez", Domicilio="Juan de Tolosa 22, Zacatecas", 
                Califs = new List<float>{70,90,60,40}}
            };
            estudiantes.Add(new Estudiante{Matricula=111, Nombre="Alejandro Garcia", Domicilio="Jardin Juarez 25, Zacatecas", 
                Califs = new List<float>{70,90,60,40}});
            
            //Todos los registros sin consulta ni filtro
            Console.WriteLine("\nTodos los estudiantes: {0}", estudiantes.Count());
            estudiantes.ForEach(est => Console.WriteLine(est.ToString()));

            //Filtrar los estudiantes que son de Zacatecas
            var estzac = (from est in estudiantes where est.Domicilio.Contains("Zacatecas") select est).ToList();
            Console.WriteLine("\nEstudiantes de Zacatecas: {0}", estzac.Count());
            estzac.ForEach(est => Console.WriteLine(est.ToString()));

            //Filtrar los estudiantes con promedio de 70, y mostrar ordenados por nombre descendente
            var otros = (from est in estudiantes 
            where est.Califs.Average()>=70 
            orderby est.Nombre descending
            select est).ToList();

            Console.WriteLine("\nEstudiantes con promedio de 70 (orden descendente por nombre): {0}", otros.Count());
            otros.ForEach(est => Console.WriteLine(est.ToString()));

            //Consulta con datos agrupados
            //Agrupar los estudiantes con matrículas 111 y 444
            var gpoest = from est in estudiantes group est by est.Matricula;
            foreach(var gpo in gpoest){
                Console.WriteLine($"\nEstudiantes con matricula: {gpo.Key}");
                foreach(Estudiante est in gpo)
                Console.WriteLine(est.ToString());
            }

            //Estudiantes y sus promedios [Nombre - Promedio]
            var proms = (from est in estudiantes
                select $"Nombre: {est.Nombre} \t- \tPromedio: {est.Califs.Average()}").ToList();
            Console.WriteLine("\n================ Promedio de Estudiantes ===============");
            proms.ForEach(p => Console.WriteLine(p));
        }
    }
}
