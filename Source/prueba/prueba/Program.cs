using System;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidad;
            string[,] clientes;

            //Empieza programa
            Console.WriteLine("\tHELADERIA DON GATO");
            // Solicitud de ingreso de clientes
            try
            {
                Console.WriteLine("Ingrese la cantidad de clientes");
                cantidad = Convert.ToInt16(Console.ReadLine());
                clientes = new string[cantidad, 10];
                // Menu de heladeria don gato
                Console.WriteLine("\n\tMenu para sabor del helado \n 0 -> chocolate, 1-> blueberry, 2->napolitano");
                Console.WriteLine("Tamaño de cono \n 0 -> pequeño, 1 -> mediano, 2 -> grande");
                Console.WriteLine("Tipo de cono \n 0 -> waffle, 1 -> chocolate, 2 -> vainilla");
                Console.WriteLine("Menu para el topping \n 0 -> nueces , 1 -> salsa de chocolate , 2 -> crema de malvaviscos");
                for (int i = 0; i < cantidad; i++) // 
                {
                    Console.WriteLine("\ningrese nombre del cliente");
                    clientes[i, 0] = Console.ReadLine();
                    Console.WriteLine("Ingrese numero de sabor del helado:");
                    int a = Convert.ToInt16(Console.ReadLine());
                    clientes[i, 1] = Convert.ToString(a);
                    Console.WriteLine("Ingrese numero tipo de cono:");
                    int b = Convert.ToInt16(Console.ReadLine());
                    clientes[i, 2] = Convert.ToString(b);
                    Console.WriteLine("Ingrese numero de tamaño:");
                    int c = Convert.ToInt16(Console.ReadLine());
                    clientes[i, 3] = Convert.ToString(c);
                    Console.WriteLine("Ingrese numero de topping");
                    int d = Convert.ToInt16(Console.ReadLine());
                    clientes[i, 4] = Convert.ToString(d);
                    if (a == 0)
                    {
                        clientes[i, 5] = Convert.ToString("1.50");
                    }
                    if (a == 1)
                    {
                        clientes[i, 5] = Convert.ToString("2.50");
                    }
                    if (a == 2)
                    {
                        clientes[i, 5] = Convert.ToString("3.50");
                    }
                    if (b == 0)
                    {
                        clientes[i, 6] = Convert.ToString("2.00");
                    }
                    if (b == 1)
                    {
                        clientes[i, 6] = Convert.ToString("4.00");
                    }
                    if (b == 2)
                    {
                        clientes[i, 6] = Convert.ToString("6.00");
                    }
                    if (c == 0)
                    {
                        clientes[i, 7] = Convert.ToString("1.50");
                    }
                    if (c == 1)
                    {
                        clientes[i, 7] = Convert.ToString("1.50");
                    }
                    if (c == 2)
                    {
                        clientes[i, 7] = Convert.ToString("2.50");
                    }
                    if (d == 0)
                    {
                        clientes[i, 8] = Convert.ToString("1.00");
                    }
                    if (d == 1)
                    {
                        clientes[i, 8] = Convert.ToString("2.00");
                    }
                    if (d == 2)
                    {
                        clientes[i, 8] = Convert.ToString("3.00");
                    }
                    // Asignar valor final a pagar
                    double pagar;
                    pagar = Convert.ToDouble(clientes[i, 5]) + Convert.ToDouble(clientes[i, 6]) + Convert.ToDouble(clientes[i, 7]) + Convert.ToDouble(clientes[i, 8]);
                    clientes[i, 9] = Convert.ToString(pagar);                    
                }

                Console.WriteLine("\n\tFactura");
                foreach (string item in clientes)
                {
                  Console.WriteLine(item);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
