//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Clase Cuenta De Cheques.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class CuentaDeCheques : CuentaBancaria{
        private double proteccionsobregiro;
        public CuentaDeCheques(double saldo, double proteccionsobregiro) : base(saldo){
            this.proteccionsobregiro = proteccionsobregiro;
        }
        public override bool Retira(double cantidad){   //Sobrecarga el método retira
            bool resultado = true;
            double proteccionrequerida = cantidad-saldo;
            if(proteccionsobregiro<proteccionrequerida){
                return false;
            }
            else{
                saldo = 0.0;
                proteccionsobregiro-=proteccionrequerida;
            }
            return resultado;
        }
    }
}