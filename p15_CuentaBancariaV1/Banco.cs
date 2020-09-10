//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Banco.
//Alejandro García Cortés.
//10/09/2020.

using System;
using System.Collections.Generic;

namespace p15_CuentaBancariaV1
{
    class Banco{
        private string nombre;
        private string propietario;
        private List<Cliente> clientes;
        public Banco(string nombre, string propietario){
            this.nombre = nombre;
            this.propietario = propietario;
            clientes = new List<Cliente>();
        }
        public string Nombre{
            get{return nombre;}
            set{nombre = value;}
        }
        public string Propietario{
            get{return propietario;}
            set{propietario = value;}
        }
        public List<Cliente> Clientes{
            get{return clientes;}
        }
        public void AgregarCliente(Cliente cte){
            clientes.Add(cte);
        }
    }
}