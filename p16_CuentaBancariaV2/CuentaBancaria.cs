//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cuenta Bancaria.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class CuentaBancaria{
        protected double saldo; //Para que pueda ser accedido por las clases que lo hereden
        
        public CuentaBancaria(double saldo){
            this.saldo = saldo;
        }

        public double Saldo{
            get{return saldo;}
        }

        public void Deposita(double cant){
            saldo+=cant;
        }

        public virtual bool Retira(double cant){    //Permite sobrecargar este método
            if(saldo>=cant){
                saldo-=cant;
                return true;
            } else return false;
        }
    }

}
