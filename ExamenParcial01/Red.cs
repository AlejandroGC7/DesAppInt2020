//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Materia: Desarrollo de Aplicaciones en Internet.
//Docente: Carlos Héctor Castañeda Ramírez.
//Alumno: Alejandro García Cortés.
//Fecha de entrega: 24/09/2020.

//Clase Red

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenParcial01
{
    class Red{
       /* public string Empresa {get; set;}
        public string Propietario {get; set;}
        public string Domicilio {get; set;}
        public List<float> Nodos;
        public override string ToString() =>
            $"Empresa:{Empresa}, Propietario:{Propietario}, Domicilio:{Domicilio}, Nodos:{string.Join(",",Nodos)}";*/
        private string empresa;
        private string propietario;
        private string domicilio;
        private List<Nodo> nodos;
        public Red(string empresa, string propietario, string domicilio){
            this.empresa = empresa;
            this.propietario = propietario;
            this.domicilio = domicilio;
            nodos = new List<Nodo>();
        }
        public string Empresa{
            get{return empresa;}
            set{empresa = value;}
        }
        public string Propietario{
            get{return propietario;}
            set{propietario = value;}
        }
        public string Domicilio{
            get{return domicilio;}
            set{domicilio = value;}
        }
        public List<Nodo> Nodos{
            get{return nodos;}
        }
        public void AgregarNodo(Nodo nod){
            nodos.Add(nod);
        }
    }
}