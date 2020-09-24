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
            mibanco.AgregarCliente(new Cliente("Obed Davila"));
            
            mibanco.Clientes[0].AgregarCuenta(new CuentaDeAhorro(500,0.10));
            mibanco.Clientes[0].AgregarCuenta(new CuentaDeCheques(1500,300));
            mibanco.Clientes[1].AgregarCuenta(new CuentaDeCheques(1500,200));
            mibanco.Clientes[2].AgregarCuenta(new CuentaDeAhorro(2500,0.08));
            mibanco.Clientes[2].AgregarCuenta(new CuentaDeCheques(500,30));
            mibanco.Clientes[3].AgregarCuenta(new CuentaDeAhorro(1500,0.9));
            mibanco.Clientes[3].AgregarCuenta(mibanco.Clientes[2].Cuentas[1]);

            mibanco.CalcularIntereses();

            Console.WriteLine("Reporte Bancario\n");
            Console.WriteLine($"{mibanco.Nombre} - {mibanco.Propietario}\n");
            Console.WriteLine($"Total de Clientes: {mibanco.Clientes.Count}\n");
            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"Cliente: {cte.Nombre} tiene {cte.Cuentas.Count} cuentas que son:\n");
                foreach(CuentaBancaria cta in cte.Cuentas){
                    Console.Write((cta is CuentaDeAhorro)?"Cuenta de Ahorro:":"Cuenta de Cheques:");
                    Console.WriteLine($"{cta.Saldo}");
                }
                Console.WriteLine();
            }
        }
    }
}
