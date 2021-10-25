﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood
{
    class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public string Categoria { get; set; }
        public int Cantidad { get; set; }

        public double Valor { get; set; }

        public double Cambio { get; set; }


        public void sumarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;

        }

        public bool validarCantidad()
        {
            if (this.Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool validarValor(double valor)
        {

            if (this.Valor <= valor)
            {
                this.Cambio = this.Valor - valor;

                return true;
            }
            return false;
        }

        public void restarProducto()
        {
            this.Cantidad--;
        }
    }
}
