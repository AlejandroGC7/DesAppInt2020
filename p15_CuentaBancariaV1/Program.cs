//UNIVERSIDAD AUTÓNOMA DE ZACATECAS - INGENIERÍA EN COMPUTACIÓN.
//Desarrollo de Aplicaciones en Internet.
//Programa Cuenta Bancaria.
//Alejandro García Cortés.
//10/09/2020.

using System;

namespace p15_CuentaBancariaV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco =  new Banco("AGC Bank", "Alejandro García Cortés");
            mibanco.AgregarCliente(new Cliente("Carlos Castaneda"));
            mibanco.AgregarCliente(new Cliente("Celina Reyes"));
            mibanco.AgregarCliente(new Cliente("Diana Escareño"));
            mibanco.AgregarCliente(new Cliente("Abraham Davila"));
            
            mibanco.Clientes[0].Cuenta = new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta = new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta = new CuentaBancaria(300);
            mibanco.Clientes[3].Cuenta = new CuentaBancaria(0);
            //Retirar $100 a la cuenta del cliente 2
            mibanco.Clientes[2].Cuenta.Retira(100);
            //Depositar $50 a la cuenta del cliente 3
            mibanco.Clientes[3].Cuenta.Deposita(50);

            Console.WriteLine("Reporte General \n");
            Console.WriteLine($"Banco {mibanco.Nombre} propiedad de {mibanco.Propietario}\n");

            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"El cliente de nombre {cte.Nombre}");
                Console.WriteLine($"Tiene una cuenta con un saldo de ${cte.Cuenta.Saldo}\n");
            }
        }
    }
}
