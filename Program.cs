using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto_No._1_Intro.Programacion
{
    internal class Program
    {
        static int a, b, cantidad_productos, puntos_acumulados;
        static double total_producto;
        static void Main(string[] args)
        {
            string e_mail, nombre_cliente, codigo_producto, respuesta, numero_factura, listado_producto, listado_productos = "", pago = "", listado_productos_final = "";
            int opcion, NIT, opcion2, opcion3, facturas_realizadas = 0, cantidad_productos_final = 0, puntos_acumulados_final = 0;
            double total_productos = 0, impuesto_ISR, impuesto_IVA, total_impuestos, total_contado = 0, total_credito = 0, total_facturas = 0, total_productos_final = 0;

        Menu_Principal:
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                     Supermercado PublicMart");
            Console.WriteLine("1. Facturación");
            Console.WriteLine("2. Reportes de Facturación");
            Console.WriteLine("3. Cerrar programa");
            Console.Write("\n" + "Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                Factura:
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("Facturación");
                    Console.Write("\n" + "Ingrese su nombre: ");
                    nombre_cliente = Console.ReadLine();
                    Console.Write("Ingrese su número de NIT (sin guion): ");
                    NIT = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingrese su e-mail (correo): ");
                    e_mail = Console.ReadLine();

                    Tabla_de_productos:
                    Console.WriteLine("\n" + "___________________________________________________________");
                    Console.WriteLine("| Código del producto |         Producto         | Precio |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("|        001          |        Pan frances       |  Q1.10 |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("|        002          |        Libra Azucar      |  Q5.00 |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("|        003          |      Caja de galletas    |  Q7.30 |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("|        004          |      Caja de granola     | Q32.50 |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("|        005          | Litro de jugo de naranja | Q17.95 |");
                    Console.WriteLine("-----------------------------------------------------------");

                    Console.Write("\n" + "Ingrese el código del producto: ");
                    codigo_producto = Console.ReadLine();
                    Tabla_Producto(codigo_producto);
                    listado_producto = Listado_Productos(codigo_producto);
                    cantidad_productos = cantidad_productos + b;
                    total_productos = total_productos + total_producto;
                    listado_productos = listado_productos + "\n" + listado_producto;
                    listado_productos_final = listado_productos_final + "\n" + listado_producto;
                    total_productos_final = total_productos_final + total_producto;

                    Console.WriteLine("\n" + "¿Desea agregar otro producto? (s/n): ");
                    respuesta = Console.ReadLine();

                    if (respuesta == "s")
                    {
                        goto Tabla_de_productos;
                    }
                    else if (respuesta == "n")
                    {
                        goto Continuar_Factura;
                    }
                    else
                    {
                        Console.WriteLine("Error. Debe responder con 's' o 'n'.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }

                    Continuar_Factura:
                    impuesto_ISR = Math.Round((total_productos * 5) / 100, 2);
                    impuesto_IVA = Math.Round((total_productos * 12) / 100, 2);
                    total_impuestos = total_productos + (impuesto_ISR + impuesto_IVA);

                    Console.WriteLine("-------------------------------------------------------------------------------");

                    Metodo_Pago:
                    Console.WriteLine("\n" + "Método de pago que desea realizar");
                    Console.WriteLine("1. Efectivo");
                    Console.WriteLine("2. Tarjeta de Crédito");
                    Console.Write("\n" + "Seleccione una opción: ");
                    opcion2 = Convert.ToInt32(Console.ReadLine());

                    double cantidad;
                    int puntos1, puntos2, puntos3;

                    switch (opcion2)
                    {
                        case 1:
                            puntos_acumulados = 0;
                            break;

                        case 2:
                            if (total_impuestos < 10)
                            {
                                puntos_acumulados = 0;
                            }
                            else if (total_impuestos >= 10 && total_impuestos < 50)
                            {
                                cantidad = (total_impuestos - (total_impuestos % 10)) / 10;
                                puntos1 = Convert.ToInt32(cantidad);
                                puntos_acumulados = puntos1;
                            }
                            else if (total_impuestos >= 50 && total_impuestos < 150)
                            {
                                cantidad = (total_impuestos - (total_impuestos % 10)) / 10;
                                puntos2 = Convert.ToInt32(cantidad);
                                puntos_acumulados = puntos2 * 2;
                            }
                            else if (total_impuestos >= 150)
                            {
                                cantidad = (total_impuestos - (total_impuestos % 10)) / 15;
                                puntos3 = Convert.ToInt32(cantidad);
                                puntos_acumulados = puntos3 * 3;
                            }
                            break;

                        default:
                            Console.WriteLine("Error. Seleccione una opción válida.");
                            Console.ReadKey();
                            goto Metodo_Pago;
                    }

                    numero_factura = Numero_de_Factura();
                    DateTime fecha_factura = DateTime.Now;
                    if (opcion2 == 1)
                    {
                        pago = "Efectivo";
                        total_contado = total_contado + total_impuestos;
                    }
                    else if (opcion2 == 2)
                    {
                        pago = "Tarjeta de Crédito";
                        total_credito = total_credito + total_impuestos;
                    }

                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("                         Supermercado PublicMart");
                    Console.WriteLine("                           " + fecha_factura.ToString());
                    Console.WriteLine("               Número de factura: " + numero_factura);
                    Console.WriteLine("               NIT: " + NIT);
                    Console.WriteLine("               Nombre: " + nombre_cliente);
                    Console.WriteLine("\n" + "           Producto      Cantidad      Precio Unitario       Total");
                    Console.WriteLine(listado_productos);
                    Console.WriteLine("\n" + "               Cantidad de productos: " + cantidad_productos);
                    Console.WriteLine("                                                            _________");
                    Console.WriteLine("                                                   Subtotal: Q" + total_productos);
                    Console.WriteLine("                                               Impuesto ISR: Q" + impuesto_ISR);
                    Console.WriteLine("                                               Impuesto IVA: Q" + impuesto_IVA);
                    Console.WriteLine("                                                            _________");
                    Console.WriteLine("                                                      Total: Q" + total_impuestos);
                    Console.WriteLine("               Método de pago: " + pago);
                    Console.WriteLine("               Puntos acumulados: " + puntos_acumulados);
                    Console.WriteLine("-------------------------------------------------------------------------------");

                    Console.WriteLine("\n" + "Una copia de la factura se enviará al correo: " + e_mail);
                    Console.ReadKey();
                    Console.Clear();

                    facturas_realizadas = facturas_realizadas + 1;
                    cantidad_productos_final = cantidad_productos_final + cantidad_productos;
                    puntos_acumulados_final = puntos_acumulados_final + puntos_acumulados;
                    total_facturas = total_facturas + total_impuestos;

                    Opciones:
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("1. Ingresar una nueva factura");
                    Console.WriteLine("2. Volver al menú principal");
                    Console.Write("\n" + "Seleccione una opción: ");
                    opcion3 = Convert.ToInt32(Console.ReadLine());

                    switch (opcion3)
                    {
                        case 1:
                            listado_productos = String.Empty;
                            total_productos = 0;
                            impuesto_ISR = 0;
                            impuesto_IVA = 0;
                            total_impuestos = 0;
                            cantidad_productos = 0;
                            puntos_acumulados = 0;
                            goto Factura;

                        case 2:
                            Console.WriteLine("");
                            goto Menu_Principal;

                        default:
                            Console.WriteLine("Error. Ingrese una opción válida.");
                            goto Opciones;
                    }

                case 2:
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("Reporte de Facturación");
                    Console.WriteLine("\n" + "Total de facturas realizadas: " + facturas_realizadas);
                    Console.WriteLine("Total de productos vendidos: " + cantidad_productos_final);
                    Console.WriteLine("\n" + "           Producto      Cantidad      Precio Unitario       Total");
                    Console.WriteLine(listado_productos_final);
                    Console.WriteLine("\n" + "Total de venta de los productos (sin impuesto): Q" + total_productos_final);
                    Console.WriteLine("Total de puntos generados: " + puntos_acumulados_final);
                    Console.WriteLine("Total de ventas al contado: Q" + total_contado);
                    Console.WriteLine("Total de ventas al crédito: Q" + total_credito);
                    Console.WriteLine("Total de las ventas: Q" +  total_facturas);
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.ReadKey();
                    Console.Clear();
                    goto Menu_Principal;

                case 3:
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("\n" + "Error. Ingrese una opción válida");
                    Console.ReadKey();
                    Console.Clear();
                    goto Menu_Principal;
            }
        }

        static void Tabla_Producto(string z)
        {
            switch (z)
            {
                case "001":
                    Cantidad_Producto();
                    total_producto = b * 1.10;
                    break;

                case "002":
                    Cantidad_Producto();
                    total_producto = b * 5.00;
                    break;

                case "003":
                    Cantidad_Producto();
                    total_producto = b * 7.30;
                    break;

                case "004":
                    Cantidad_Producto();
                    total_producto = b * 32.50;
                    break;

                case "005":
                    Cantidad_Producto();
                    total_producto = b * 17.95;
                    break;

                default:
                    Console.WriteLine("Error. El código del producto es incorrecto.");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
            }
        }

        static void Cantidad_Producto()
        {
            Console.Write("¿Cuántos productos desea adquirir?: ");
            a = Convert.ToInt32(Console.ReadLine());

            if (a > 0)
            {
                b = a;
            }
            else
            {
                Console.WriteLine("\n" + "Error. La cantidad admitida de productos debe ser mayor a cero.");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        static string Numero_de_Factura()
        {
            string numero_factura;
            int x, p, n, factura2;
            double factura;

            Random random = new Random();
            x = random.Next(1, 1001);
            p = puntos_acumulados;
            n = cantidad_productos;

            factura = (((2 * x) + Math.Pow(p, 2)) + (2021 * n)) % 10000;
            factura2 = Convert.ToInt32(factura);
            numero_factura = Convert.ToString(factura2);

            if (numero_factura.Length < 4)
            {
                numero_factura = numero_factura.PadLeft(4, '0');
                return numero_factura;
            }
            else
            {
                return numero_factura;
            }
        }

        static string Listado_Productos(string z)
        {
            string q;
            switch (z)
            {
                case "001":
                    q = ("         Pan frances        X" + b + "              Q1.10       =    Q" + total_producto);
                    return q;

                case "002":
                    q = ("         Libra Azucar       X" + b + "              Q5.00       =    Q" + total_producto);
                    return q;

                case "003":
                    q =("       Caja de galletas     X" + b + "              Q7.30       =    Q" + total_producto);
                    return q;

                case "004":
                    q = ("       Caja de granola      X" + b + "              Q32.50      =    Q" + total_producto);
                    return q;

                case "005":
                    q = ("  Litro de jugo de naranja  X" + b + "              Q17.95      =    Q" + total_producto);
                    return q;
                default:
                    q = "";
                    return q;
            }
        }
    }
}
