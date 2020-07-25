using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EjerciciosPractica5.Clases;

namespace EjerciciosPractica5
{
    class Program
    {

        public static void Encabezado() {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("                     ==========================================================================");
            Console.WriteLine("                                     UNIVERSIDAD AUTONOMA DE SANTO DOMINGO      ");
            Console.WriteLine("                                                     UASD      ");
            Console.WriteLine("                                              FACULTAD DE CIENCIAS      ");
            Console.WriteLine("                                             ESCUELA DE INFORMATICA     ");

            Console.WriteLine("                                               PRACTICA NUMERO V      ");
            Console.WriteLine("                     ==========================================================================");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var empresa = new Empresa() { Nombre = "TECHSHYRA", Direccion = "SALOME UREÑA #12", RNC = "0018000124",Telefono = "829-773-8324"};
            var cliente = new Cliente() { Codigo = "00014",Nombre = "ROBERTO", Apellido = "MARTINEZ",Direccion = "DIRECCION DE ROBERTO"};
            var empleado = new Empleado() { Codigo = "00001", Nombre="ROSA",Apellido="HERRERA", Direccion = "DIRECCION DE ROSA", Puesto = "CAJERO"};

            var factura = new Factura(empresa,cliente,empleado);
            factura.Fecha = DateTime.Now;

            Encabezado();
            Console.WriteLine("                     ++++++++++++ FACTURA ++++++++++++");
            Console.WriteLine($"                    ++++++++++++ {empresa.Nombre} ++++++++++++");

            while (true)
            {
                var producto = new Producto();
                var detalleFactura = new DetalleFactura();

                Console.Write("                     INGRESE CODIGO PRODUCTO: ");
                producto.Codigo = Console.ReadLine();

                Console.Write("                     INGRESE NOMBRE PRODUCTO: ");
                producto.Descripcion = Console.ReadLine();

                Console.Write("                     INGRESE PRECIO PRODUCTO: ");
                decimal precio;
                if (decimal.TryParse(Console.ReadLine(),out precio) == false)
                {
                    break;
                }

                Console.Write("                            INGRESE CANTIDAD: ");
                decimal cantidad;
                if (decimal.TryParse(Console.ReadLine(), out cantidad) == false)
                {
                    break;
                }

                producto.Precio = precio;
                detalleFactura.AddLinea(producto,cantidad);

                factura.AddLineaFactura(detalleFactura);

                Console.WriteLine("                  ++++++++++++ MENU ++++++++++++");
                Console.WriteLine("                  [S] CANCELAR");
                Console.WriteLine("                  [C] CONTINUAR");
                Console.WriteLine("                  [I] IMPRIMIR FACTURA");
                Console.WriteLine("                  ++++++++++++++++++++++++++++++");
                Console.Write("                      SELECCIONE UNA OPCION: ");

                string op = Console.ReadLine();
                if (op == "I" || op == "i")
                {
                    factura.Imprimir();
                    break;
                }
                else if (op == "S" || op == "s")
                {
                    break;
                }
                else
                {
                    Encabezado();
                    Console.WriteLine("                ++++++++++++ FACTURA ++++++++++++");
                    Console.WriteLine($"               ++++++++++++ {empresa.Nombre} ++++++++++++");
                }
            }

            Console.ReadKey();
        }
    }
}
