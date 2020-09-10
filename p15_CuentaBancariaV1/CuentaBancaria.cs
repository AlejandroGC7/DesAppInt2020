//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cuenta Bancaria.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class CuentaBancaria{
        private double saldo;
        
        public CuentaBancaria(double saldo){
            this.saldo = saldo;
        }

        public double Saldo{
            get{return saldo;}
        }

        public void Deposita(double cant){
            saldo+=cant;
        }

        public bool Retira(double cant){
            if(saldo>=cant){
                saldo-=cant;
                return true;
            } else return false;
        }
    }

}
