//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cliente.
//Alejandro García Cortés.
//10/09/2020.

using System;
using System.Collections.Generic;

namespace p15_CuentaBancariaV1
{
    class Cliente{
        private string nombre;
        private List<CuentaBancaria> cuentas;
        public Cliente(){}
        public Cliente(string nombre){
            this.nombre = nombre;
            cuentas = new List<CuentaBancaria>();
        }
        public string Nombre{
            get{return nombre;}
            set{nombre = value;}
        }
        public List<CuentaBancaria> Cuentas{
            get{return cuentas;}
        }
        public void AgregarCuenta(CuentaBancaria cta){
            cuentas.Add(cta);
        }
    }

}