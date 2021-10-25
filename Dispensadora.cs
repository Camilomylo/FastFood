using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood
{
    class Dispensadora
    {
        public List<Producto> Productos { get; set; }

        public string Pago { get; set; }

        public Dispensadora()
        {

            this.Productos = new List<Producto>();

            Producto cocacola = new Producto();
            cocacola.Codigo = "01";
            cocacola.Nombre = "Coca Cola";
            cocacola.Categoria = "B";
            cocacola.Cantidad = 10;
            cocacola.Valor = 2500;

            Producto salchipapa = new Producto();
            salchipapa.Codigo = "02";
            salchipapa.Nombre = "Salchipapa";
            salchipapa.Categoria = "P";
            salchipapa.Cantidad = 7;
            salchipapa.Valor = 4000;

            Producto hambuerguesa = new Producto();
            hambuerguesa.Codigo = "03";
            hambuerguesa.Nombre = "Hamburguesa";
            hambuerguesa.Categoria = "C";
            hambuerguesa.Cantidad = 5;
            hambuerguesa.Valor = 7000;

            this.Productos.Add(cocacola);
            this.Productos.Add(salchipapa);
            this.Productos.Add(hambuerguesa);

        }

        public int validaProducto(string codigo)
        {
            int encontro = -1;

            for (int i = 0; i < this.Productos.Count; i++)
            {
                if (this.Productos[i].Codigo == codigo)
                {
                    encontro = i;
                }
            }

            return encontro;
        }

        public bool agregarProducto(Producto producto)
        {
            int enc = this.validaProducto(producto.Codigo);

            if (enc >= 0)
            {
                this.Productos[enc].sumarCantidad(producto.Cantidad);
            }
            else
            {
                this.Productos.Add(producto);
            }

            return true;
        }

        public bool eliminarProducto(string codigo)
        {
            int enc = this.validaProducto(codigo);

            if (enc >= 0)
            {
                this.Productos.RemoveAt(enc);
                return true;
            }

            return false;
        }

        public double validarMonedas(string[] monedas)
        {
            double total = 0;
            foreach (string item in monedas)
            {
                try
                {

                    total += float.Parse(item);

                }
                catch (Exception e)
                {

                }
            }

            return total;
        }

        public Producto vender(string codigo)
        {
            int enc = this.validaProducto(codigo);

            if (enc >= 0)
            {
                if (this.Productos[enc].validarCantidad())
                {
                    string[] monedas = this.Pago.Split('-');

                    double total = this.validarMonedas(monedas);

                    if (this.Productos[enc].validarValor(total))
                    {
                        this.Productos[enc].restarProducto();

                        return this.Productos[enc];
                    }


                }
            }

            return null;
        }

        public string listarProducto()
        {
            string lista = "";
            foreach (Producto item in this.Productos)
            {

                lista += item.Codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";

            }

            return lista;
        }
    }
}
