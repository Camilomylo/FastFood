using System;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            //

            Dispensadora dispensador = new Dispensadora();

            Console.WriteLine("Bienvenido al Salchipapero");

            while (true)
            {


                Console.WriteLine(dispensador.listarProducto());

                Console.WriteLine("1. Agragar Producto");
                Console.WriteLine("2. Modificar Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Comprar Producto");
                string options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        Producto producto = new Producto();
                        Console.WriteLine("Codigo: ");
                        producto.Codigo = Console.ReadLine();


                        Console.WriteLine("Nombre: ");
                        producto.Nombre = Console.ReadLine();

                        Console.WriteLine("Categoria: ");
                        producto.Categoria = Console.ReadLine();

                        Console.WriteLine("Cantidad: ");
                        producto.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Valor: ");
                        producto.Valor = double.Parse(Console.ReadLine());

                        dispensador.agregarProducto(producto);

                        break;

                    case "2":



                        break;

                    case "3":

                        Console.WriteLine("Codigo: ");
                        string codigo = Console.ReadLine();

                        dispensador.eliminarProducto(codigo);

                        break;

                    case "4":

                        Console.WriteLine("Codigo: ");
                        string codigo_venta = Console.ReadLine();

                        Console.WriteLine("Solo aceptamos pagos con billetes de (20000-5000-2000-1000) ");
                        dispensador.Pago = Console.ReadLine();

                        Producto pcomprado = dispensador.vender(codigo_venta);

                        if (pcomprado == null)
                        {
                            Console.WriteLine("Error de Pago");

                        }
                        else
                        {

                            Console.WriteLine("Su producto es {0} y la devuelta es {1}", pcomprado.Codigo, pcomprado.Cambio);

                        }

                        break;


                }

                Console.WriteLine("Desea continuar? Y/N");

                if (Console.ReadLine() == "N")
                {

                    break;
                }

            }

        }
    }
}
