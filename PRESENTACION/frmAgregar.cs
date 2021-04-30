using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEGOCIO;
using DOMINIO;

namespace PRESENTACION
{
    public partial class frmAgregar : Form
    {

        
        public frmAgregar()
        {
            InitializeComponent();
        }

      

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            //cargar cbxMarca y cbxCategoria
            cargarCombosBox();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
     
              agregar();
              
        }


        private void cargarCombosBox()
        {
            Categorias_neg aux = new Categorias_neg();
            List<Categoria> listaCategorias = aux.ListarCategorias();

            Marcas_neg aux2 = new Marcas_neg();
            List<Marca> listaMarcas = aux2.ListarMarcas();

            foreach(Categoria item in listaCategorias)
            {
                cbxCategoria.Items.Add(item);
            }

            foreach (Marca item in listaMarcas)
            {
                cbxMarca.Items.Add(item);
            }


        }


        // Creo un objeto de tipo "articulo" con el cual le voy a ir llenando su propiedades y se lo envio a la funcion 
        // "agregarNuevoArticulo()" que hace de puente con la funcion de la base de datos.
        private void agregar()
        {

            Articulos_neg art = new Articulos_neg();
          
            try
            {
                Articulo articulo = new Articulo
                {
                    Codigo = tbxCodigo.Text,
                    Nombre = tbxNombre.Text,
                    Descripcion = tbxDescripcion.Text,
                    Marca = (Marca)cbxMarca.SelectedItem,
                    Categoria = (Categoria)cbxCategoria.SelectedItem,
                    UrlImagen = tbxUrlImagen.Text,
                    Precio = Convert.ToDouble(tbxPrecio.Text)
                };

                if (art.agregarNuevoArticulo(articulo))
                {
                    MessageBox.Show("Articulo agregado!");
                    Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void tbxUrlImagen_TextChanged(object sender, EventArgs e)
        {

            try
            {
                pbxImagen.Load(tbxUrlImagen.Text);
            }

           catch(Exception ex)
            {
                
            }
        }

      


    }
}
