//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cuenta De Ahorro.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class CuentaDeAhorro : CuentaBancaria{
        private double tasainteres;
        public CuentaDeAhorro(double saldo, double tasainteres) : base(saldo){  //Llamada explícita al constructor base
            this.tasainteres = tasainteres;
        }
        public void CalcularInteres(){
            saldo+=(saldo*tasainteres);
        }
    }
}