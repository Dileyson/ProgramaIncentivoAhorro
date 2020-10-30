using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_incentivo_ahorro
{
    class Program
    {
        private static int valorIncentivo;
        private static int valorParcial;
        private static int valorTotalPagar;
        private static List<int> listaIncentivo = new List<int>();
        private static List<int> listaValorParcial = new List<int>();
        private static List<int> listaValorTotalPagar = new List<int>();


        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente{Cedula = "3145", Estrato = 3, MetaAhorro = 150, ConsumoActual = 180},
                new Cliente{Cedula = "8947", Estrato = 3, MetaAhorro = 190, ConsumoActual = 187},
                new Cliente{Cedula = "3145", Estrato = 4, MetaAhorro = 260, ConsumoActual = 320}
            };
            string op = "";
            do
            {
                Console.WriteLine("Ejecutar primero la opcion 1. \n1:Mostrar valor total a pagar por cliente" +
                    "\n2: Mostrar el promedio de consumo. \n3: mostrar valor total que se dio por descuentos" +
                    "\n4: Mostrar porcentaje de ahorro por estratos \n5: Mostrar numero de clientes que tuvo cobro adicional \nPresione 's' para salir");
                op = Console.ReadLine();
                switch (op[0])
                {
                    case '1':
                        ValorTotal(clientes);
                        Console.WriteLine("");
                        break;
                    case '2':
                        Console.WriteLine("El valor de consumo promedio de los clientes es: " + PromedioConsumo(clientes));
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                    case '3':
                        Console.WriteLine(" El valor total que se le dio a los clientes por concepto de descuentos es: " + ValorTotalDescuento(clientes));                        
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                    case '4':
                        PorcentajeDescuentosEstratos(clientes);
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                    case '5':
                        Console.WriteLine(" El numero de clientes que tuvo cobro adicial es: " + NumeroClientesCobroAdicional(clientes));
                        Console.WriteLine("");
                        Console.ReadLine();
                        break;
                    default:
                        op = "s";
                        break;

                }

            } while (op[0] != 's');
            Console.Read();                           
            
        }

        private static void ValorTotalCliente(Cliente cliente)
        {
            valorParcial = cliente.ConsumoActual * 500;
            valorIncentivo = (cliente.MetaAhorro - cliente.ConsumoActual) * 500;
            valorTotalPagar = valorParcial - valorIncentivo;
            listaIncentivo.Add(valorIncentivo);
            listaValorParcial.Add(valorParcial);
            listaValorTotalPagar.Add(valorTotalPagar);          
        }

        private static void ValorTotal(List<Cliente> clientes)
        {
            int i = 0;
            foreach (Cliente cliente in clientes)
            {
                ValorTotalCliente(cliente);
                Console.WriteLine("El valor total a pagar del cliente " + cliente.Cedula + " es " + listaValorTotalPagar[i]);
                i++;
            }
            
        }

        private static float PromedioConsumo(List<Cliente> clientes)
        {
            int sumatoria = 0;
            foreach (Cliente cliente in clientes)
            {
                sumatoria += cliente.ConsumoActual;

            }

            float promedio = sumatoria / clientes.Count;

            return promedio;
        }

        private static int ValorTotalDescuento(List<Cliente> clientes)
        {
            int sumatoriaDescuentos = 0;
            int i = 0;
            foreach (int incentivo in listaIncentivo)

            {
                if (incentivo > 0)
                {
                    sumatoriaDescuentos += listaIncentivo[i];
                }
                i++;
                
            }

            return sumatoriaDescuentos;

            
        }

        private static void PorcentajeDescuentosEstratos(List<Cliente> clientes)
        {

            int sumatoriaIncentivoEstratos3 = 0;
            int sumatoriaParcialesEstratos3 = 0;
            int sumatoriaIncentivoEstratos4 = 0;
            int sumatoriaParcialesEstratos4 = 0;
            
            int i = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Estrato == 3)
                {
                    if (listaIncentivo[i] > 0)
                    {
                        sumatoriaIncentivoEstratos3 += listaIncentivo[i];
                        sumatoriaParcialesEstratos3 += listaValorParcial[i];

                    }


                }
                else 
                {
                    if (listaIncentivo[i] > 0)
                    {
                        sumatoriaIncentivoEstratos4 += listaIncentivo[i];
                        sumatoriaParcialesEstratos4 += listaValorParcial[i];
                        
                    }
                    

                }
                i++;
            }
            if (sumatoriaParcialesEstratos3 != 0)
            {
                double porcentajeEstrato3 = (sumatoriaIncentivoEstratos3 * 100) / sumatoriaParcialesEstratos3;
                Console.WriteLine(" El porcentaje de ahorro del estrato 3 es {0:0.00}", porcentajeEstrato3 + " %. ");
            }
            else
            {
                Console.WriteLine(" El porcentaje de ahorro del estrato 3 es: "+ 0 +" %. ");
            }
            if(sumatoriaParcialesEstratos4 != 0)
            {
                double porcentajeEstrato4 = (sumatoriaIncentivoEstratos4 * 100) / sumatoriaParcialesEstratos4;
                Console.WriteLine(" El porcentaje de ahorro del estrato 4 es: {0:0.00}"+ porcentajeEstrato4 + " %. ");
            }
            else
            {
                Console.WriteLine(" El porcentaje de ahorro del estrato 4 es: " + 0 + " %. ");
            }
            
        }

        private static int NumeroClientesCobroAdicional(List<Cliente> clientes)
        {
            int numeroClientesCobroAdicional = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.ConsumoActual > cliente.MetaAhorro)
                {
                    numeroClientesCobroAdicional += 1;
                }
            }
            return numeroClientesCobroAdicional;

        }
    }
    }