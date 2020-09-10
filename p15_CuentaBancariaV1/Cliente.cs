//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cliente.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class Cliente{
        private string nombre;
        private CuentaBancaria cuenta;
        public Cliente(){}
        public Cliente(string nombre){
            this.nombre = nombre;
        }
        public string Nombre{
            get{return nombre;}
            set{nombre = value;}
        }
        public CuentaBancaria Cuenta{
            get{return cuenta;}
            set{cuenta = value;}
        }
    }
}