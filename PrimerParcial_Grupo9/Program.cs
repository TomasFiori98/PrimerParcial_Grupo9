using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial_Grupo9
{
    class Program
    {
        static void Main(string[] args)
        {

            int opc;
            char opc2 = 'N';
            int cant_c = 0;
            float p_unitario = 1000.00f;
            float pt_sin_descuento = 0.00f;
            float descuento = 0.00f;
            float precio_final = 0.00f;

            Program p = new Program();

            do
            {
                Console.WriteLine("Camisas PRADBIT – Ventas minoristas y mayoristas");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("MENU PRINCIPAL: ");
                Console.WriteLine("1- Añadir camisa al carro de compras.");
                Console.WriteLine("2- Eliminar camisa del carro de compras.");
                Console.WriteLine("3- Mostrar carro de compras.");
                Console.WriteLine("4- SALIR.");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Ingrese una opcion del menu: ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        p.agregarCamisa(ref cant_c, ref pt_sin_descuento, p_unitario);
                        p.calcularPrecioFinal(cant_c, pt_sin_descuento, ref descuento, ref precio_final);
                        Console.WriteLine("\n-- Precione una tecla para continuar --");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        p.quitarCamisa(ref cant_c, ref pt_sin_descuento, p_unitario);
                        p.calcularPrecioFinal(cant_c, pt_sin_descuento, ref descuento, ref precio_final);
                        Console.WriteLine("\n-- Precione una tecla para continuar --");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        p.mostrarCarrito(cant_c, p_unitario, pt_sin_descuento, descuento, precio_final);
                        Console.WriteLine("\n-- Precione una tecla para continuar --");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n¿Seguro que desea salir? (S para si/N para no)");
                        opc2 = Convert.ToChar(Console.ReadLine());
                        if ( opc2 == 'S')
                        {
                            Console.WriteLine("\n- - - - - SALIENDO DEL PROGRAMA - - - - ");
                        } else
                        {
                            Console.WriteLine(" - - - - VOLVIENDO AL MENU - - - - ");
                            Console.WriteLine("\n-- Precione una tecla para continuar --");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine("\n La opcion ingresada no es valida.");
                        Console.WriteLine("Por favor digite una opcion correcta.");
                        break;
                }

            } while (opc2 != 'S');

            Console.ReadKey();
        }
        public void calcularPrecioFinal(int cant, float pt_sin_desc, ref float desc, ref float precio_final)
        {
            if (cant < 3)
            {
                precio_final = pt_sin_desc;
            } else if (cant>=3 && cant <= 5)
            {
                desc = 10.0f;
                precio_final = pt_sin_desc - (pt_sin_desc * desc / 100);
            } else
            {
                desc = 20.0f;
                precio_final = pt_sin_desc - (pt_sin_desc * desc / 100);
            }
        }

        public void agregarCamisa(ref int cant, ref float pt_sin_desc, float p_unitario)
        {
            int opc;

            do
            {
                cant += 1;
                pt_sin_desc += p_unitario;

                Console.Clear();

                Console.WriteLine("\nSe ha agregado 1 camisa al carrito correctamente!");
                Console.WriteLine(" Cantidad de camisas en el carro: {0}", cant);

                Console.WriteLine("\nDesea seguir agregando camisas? (1-SI, 2-NO)");
                opc = Convert.ToInt32(Console.ReadLine());

                if (opc != 1 && opc != 2)
                {
                    Console.WriteLine("\nERROR - Volviendo al menu.\n");
                }

            } while (opc == 1);
            
        }
        public void quitarCamisa(ref int cant, ref float pt_sin_desc, float p_unitario)
        {
            int opc;

            do
            {
                if (cant <= 0)
                {
                    Console.WriteLine("\nEl carrito no tiene ninguna camisa.");
                    opc = 2;
                }
                else
                {
                    cant -= 1;
                    pt_sin_desc -= p_unitario;
                    Console.Clear();

                    Console.WriteLine("\nSe ha quitado 1 camisa del carrito correctamente.");
                    Console.WriteLine(" Cantidad de camisas en el carro: {0}", cant);

                    Console.WriteLine("\nDesea seguir eliminando camisas? (1-SI, 2-NO)");
                    opc = Convert.ToInt32(Console.ReadLine());

                    if (opc != 1 && opc != 2)
                    {
                        Console.WriteLine("\nERROR - Volviendo al menu.\n");
                    }
                }
            } while (opc == 1 || opc != 2);
        }
        public void mostrarCarrito(int cant, float p_unitario, float pt_sin_descuento, float descuento, float precio_final)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Cantidad de camisas en el carro: {0}", cant);
            Console.WriteLine(" Precio unitario: {0}", p_unitario);
            Console.WriteLine(" Precio total sin descuento: {0}", pt_sin_descuento);
            Console.WriteLine(" Tipo de descuento aplicado: {0}%", descuento);
            Console.WriteLine(" Precio final con descuento: {0}", precio_final);
            Console.WriteLine("------------------------------------------------");
        }

    }
}
