using System.Xml.Serialization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        // Variables para almacenar la fila y columna seleccionadas
        int fila = 0, columna = 0;
        public Form1()
        {
            InitializeComponent();
            Operaciones.inicializarMatriz(); // Inicializar la matriz de productos al iniciar el formulario
        }
        private void btnMostrarMatriz_Click(object sender, EventArgs e) // Boton que muestra la matriz de inventarios
        {
            Operaciones.mostrarMatriz();
        }

        private void btnComprar_Click(object sender, EventArgs e) // Boton que realiza la compra de un producto
        {
            Operaciones.comprarProducto(fila, columna, int.Parse(txtbCantidad.Text), float.Parse(txtbMonto.Text));
            actualizarListBoxPila(); // Actualiza la lista de productos comprados
            actualizarListBoxCola(); // Actualiza la lista de productos con alerta
            actualizarEtiqueta(fila, columna); // Actualiza la etiqueta de cantidad disponible del producto seleccionado
        }

        private void btnAgregar_Click(object sender, EventArgs e) // Boton que aumenta la cantidad de productos al inventario
        {
            Operaciones.agregarProducto(fila, columna, int.Parse(txtbCantidad.Text));
            actualizarEtiqueta(fila, columna);
            actualizarListBoxCola();
        }

        private void btnReabastecerUltimaCompra_Click(object sender, EventArgs e) // Boton que reabastece la ultima compra realizada
        {
            Operaciones.reabastecerUltimaCompra();
            actualizarListBoxPila();
            actualizarListBoxCola();
            actualizarEtiqueta(fila, columna);
        }

        private void actualizarListBoxCola() // Actualiza la lista de productos con alerta (Cola)
        {
            lstbAlertas.Items.Clear();
            foreach (var producto in Operaciones.colaProductos)
            {
                lstbAlertas.Items.Add($"Codigo: {producto.codigo}, Nombre: {producto.nombre}, Cantidad disponible: {producto.cantidad}");
            }
        }

        private void actualizarListBoxPila() // Actualiza la lista de productos comprados (Pila)
        {
            lstbPila.Items.Clear();
            foreach (var producto in Operaciones.pilaProductos)
            {
                lstbPila.Items.Add($"Codigo: {producto.codigo}, Nombre: {producto.nombre}, Precio: {producto.precio}, Cantidad: {producto.cantidad}");
            }
        }

        private void btnConfirmarAlerta_Click(object sender, EventArgs e) // Boton que confirma la alerta de un producto con baja cantidad
        {
            Operaciones.confirmarAlerta();
            actualizarListBoxPila();
            actualizarListBoxCola();
        }

        private void actualizarEtiqueta(int fila, int columna) // Actualiza las etiquetas de codigo, precio, nombre y cantidad disponible del producto seleccionado
        {
            lblCodigo.Text = Operaciones.matrizProductos[fila, columna].codigo;
            lblPrecio.Text = Operaciones.matrizProductos[fila, columna].precio.ToString();
            lblProducto.Text = Operaciones.matrizProductos[fila, columna].nombre;
            lblCantidadDisponible.Text = Operaciones.matrizProductos[fila, columna].cantidad.ToString();
        }

        // Botones de la maquina expendedora
        private void btnP1_Click(object sender, EventArgs e)
        {
            fila = 0;
            columna = 0;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            fila = 0;
            columna = 1;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP3_Click(object sender, EventArgs e)
        {
            fila = 0;
            columna = 2;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP4_Click(object sender, EventArgs e)
        {
            fila = 1;
            columna = 0;
            actualizarEtiqueta(fila, columna);
        }


        private void btnP5_Click(object sender, EventArgs e)
        {
            fila = 1;
            columna = 1;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP6_Click(object sender, EventArgs e)
        {
            fila = 1;
            columna = 2;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP7_Click(object sender, EventArgs e)
        {
            fila = 2;
            columna = 0;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP8_Click(object sender, EventArgs e)
        {
            fila = 2;
            columna = 1;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP9_Click(object sender, EventArgs e)
        {
            fila = 2;
            columna = 2;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP10_Click(object sender, EventArgs e)
        {
            fila = 3;
            columna = 0;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP11_Click(object sender, EventArgs e)
        {
            fila = 3;
            columna = 1;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP12_Click(object sender, EventArgs e)
        {
            fila = 3;
            columna = 2;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP13_Click(object sender, EventArgs e)
        {
            fila = 4;
            columna = 0;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP14_Click(object sender, EventArgs e)
        {
            fila = 4;
            columna = 1;
            actualizarEtiqueta(fila, columna);
        }

        private void btnP15_Click(object sender, EventArgs e)
        {
            fila = 4;
            columna = 2;
            actualizarEtiqueta(fila, columna);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
