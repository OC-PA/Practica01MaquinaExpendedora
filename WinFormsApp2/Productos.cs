using System;
using System.Collections.Generic;
using System.Text;

// Clase para representar un producto
namespace WinFormsApp2
{
    internal class Productos
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }

        public Productos(string codigo, string nombre, float precio, int cantidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public Productos()
        {

        }
    }
}
