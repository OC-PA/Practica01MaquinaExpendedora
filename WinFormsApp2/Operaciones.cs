using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    internal class Operaciones
    {
        // Definicion de la matriz de productos
        public static Productos[,] matrizProductos = new Productos[5, 3];
        // Definicion de la pila de productos
        public static Stack<Productos> pilaProductos = new Stack<Productos>();
        // Definicion de la cola de productos
        public static Queue<Productos> colaProductos = new Queue<Productos>();

        // Metodo para inicializar la matriz de productos
        public static void inicializarMatriz()
        {
            matrizProductos[0, 0] = new Productos { codigo = "01", nombre = "Papas", precio = 1500.00f, cantidad = 10 };
            matrizProductos[0, 1] = new Productos { codigo = "02", nombre = "Galletas", precio = 1200.00f, cantidad = 10 };
            matrizProductos[0, 2] = new Productos { codigo = "03", nombre = "Chocolates", precio = 2000.00f, cantidad = 10 };

            matrizProductos[1, 0] = new Productos { codigo = "04", nombre = "Refresco", precio = 2500.00f, cantidad = 10 };
            matrizProductos[1, 1] = new Productos { codigo = "05", nombre = "Agua", precio = 1000.00f, cantidad = 10 };
            matrizProductos[1, 2] = new Productos { codigo = "06", nombre = "Jugo", precio = 3000.00f, cantidad = 10 };

            matrizProductos[2, 0] = new Productos { codigo = "07", nombre = "Cerveza", precio = 4000.00f, cantidad = 10 };
            matrizProductos[2, 1] = new Productos { codigo = "08", nombre = "Vino", precio = 8000.00f, cantidad = 10 };
            matrizProductos[2, 2] = new Productos { codigo = "09", nombre = "Whisky", precio = 15000.00f, cantidad = 10 };

            matrizProductos[3, 0] = new Productos { codigo = "10", nombre = "Cigarros", precio = 5000.00f, cantidad = 10 };
            matrizProductos[3, 1] = new Productos { codigo = "11", nombre = "Chicles", precio = 800.00f, cantidad = 10 };
            matrizProductos[3, 2] = new Productos { codigo = "12", nombre = "Caramelos", precio = 600.00f, cantidad = 10 };

            matrizProductos[4, 0] = new Productos { codigo = "13", nombre = "Pan", precio = 2000.00f, cantidad = 10 };
            matrizProductos[4, 1] = new Productos { codigo = "14", nombre = "Queso", precio = 5000.00f, cantidad = 10 };
            matrizProductos[4, 2] = new Productos { codigo = "15", nombre = "Jamón", precio = 7000.00f, cantidad = 10 };
        }

        // Metodo para mostrar la matriz de productos
        public static void mostrarMatriz()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sb.AppendLine($"Indice: [{i},{j}] Codigo: {matrizProductos[i, j].codigo} , Nombre: {matrizProductos[i, j].nombre} , Precio: {matrizProductos[i, j].precio} , Cantidad: {matrizProductos[i, j].cantidad}");
                }
            }
            MessageBox.Show(sb.ToString());
        }

        // Metodo para comprar un producto
        public static void comprarProducto(int fila, int columna, int cantidad, float monto)
        {
            if (cantidad <= matrizProductos[fila, columna].cantidad && monto >= matrizProductos[fila, columna].precio * cantidad)
            {
                matrizProductos[fila, columna].cantidad -= cantidad;
                MessageBox.Show($"Compra exitosa. Producto: {matrizProductos[fila, columna].nombre}, Cantidad comprada: {cantidad}, Precio total: {matrizProductos[fila, columna].precio * cantidad}, Su vuelto es: {monto - (matrizProductos[fila, columna].precio * cantidad)}");

                // Si la compra es exitosa, agregar el producto comprado a la pila de productos
                pilaProductos.Push(new Productos
                {
                    codigo = matrizProductos[fila, columna].codigo,
                    nombre = matrizProductos[fila, columna].nombre,
                    precio = matrizProductos[fila, columna].precio,
                    cantidad = cantidad
                });

                // Si la cantidad del producto es menor o igual a 5, agregarlo a la cola de productos para indicar que hay poco inventario
                if (matrizProductos[fila, columna].cantidad <= 5)
                {
                    colaProductos.Enqueue(new Productos
                    {
                        codigo = matrizProductos[fila, columna].codigo,
                        nombre = matrizProductos[fila, columna].nombre,
                        precio = matrizProductos[fila, columna].precio,
                        cantidad = matrizProductos[fila, columna].cantidad
                    });
                }
            }
            else
            {
                MessageBox.Show("No hay suficientes productos disponibles o el monto es insuficiente.");
            }
        }

        // Metodo para aumentar la cantidad de productos a la matriz
        public static void agregarProducto(int fila, int columna, int cantidad)
        {
            matrizProductos[fila, columna].cantidad += cantidad;
            MessageBox.Show($"Se han agregado {cantidad} unidades del producto {matrizProductos[fila, columna].nombre}. Nueva cantidad disponible: {matrizProductos[fila, columna].cantidad}");
        }

        // Metodo para reabastecer la ultima compra realizada por medio de la pila de productos
        public static void reabastecerUltimaCompra()
        {
            if (pilaProductos.Count > 0)
            {
                switch (pilaProductos.Peek().codigo)
                {
                    case "01":
                        matrizProductos[0, 0].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "02":
                        matrizProductos[0, 1].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "03":
                        matrizProductos[0, 2].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "04":
                        matrizProductos[1, 0].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "05":
                        matrizProductos[1, 1].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "06":
                        matrizProductos[1, 2].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "07":
                        matrizProductos[2, 0].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "08":
                        matrizProductos[2, 1].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "09":
                        matrizProductos[2, 2].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "10":
                        matrizProductos[3, 0].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "11":
                        matrizProductos[3, 1].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "12":
                        matrizProductos[3, 2].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "13":
                        matrizProductos[4, 0].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "14":
                        matrizProductos[4, 1].cantidad += pilaProductos.Pop().cantidad;
                        break;
                    case "15":
                        matrizProductos[4, 2].cantidad += pilaProductos.Pop().cantidad;
                        break;
                }
            }
        }

        // Metodo para confirmar el mensaje de alerta de poco inventario y eliminar el producto de la cola
        public static void confirmarAlerta()
        {
            if (colaProductos.Count > 0)
            {
                colaProductos.Dequeue();
            }
        }
    }
}
