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
    public partial class frmArticulo : Form
    {

        private readonly Articulo Articulo = null;
        public frmArticulo()
        {
            InitializeComponent();
        }

      public frmArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.Articulo = articulo;
            Text = "Modificar Artículo";
        }
        private void frmAgregar_Load(object sender, EventArgs e)
        {
         
            //cargar cbxMarca y cbxCategoria
            try
            {
                
                cargarCombosBox();



                if (Articulo != null)
                {
                    Categorias_neg aux = new Categorias_neg();
                    List<Categoria> listaCategorias = aux.ListarCategorias();

                    Marcas_neg aux2 = new Marcas_neg();
                    List<Marca> listaMarcas = aux2.ListarMarcas();

                    foreach (Categoria item in listaCategorias)
                    {
                        if(Articulo.Categoria.Nombre==item.Nombre)
                        {
                            cbxCategoria.Text = item.Nombre;
                        }
                    }

                    foreach (Marca item in listaMarcas)
                    {
                        if (Articulo.Marca.Nombre == item.Nombre)
                        {
                            cbxMarca.Text = item.Nombre;
                        }

                    }

                    tbxNombre.Text = Articulo.Nombre;
                    tbxCodigo.Text = Articulo.Codigo;
                    tbxPrecio.Text = Convert.ToString(Articulo.Precio);
                    tbxDescripcion.Text = Articulo.Descripcion;
                    tbxUrlImagen.Text = Articulo.UrlImagen;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validarCampos()
        {
            bool validar = true;
            if(tbxCodigo.Text=="")
            {
                validar = false;
                Error.SetError(tbxCodigo,"Ingresar un código.");
            }
            if (tbxNombre.Text == "")
            {
                validar = false;
                Error.SetError(tbxNombre, "Ingresar un nombre.");
            }
            if (tbxPrecio.Text == "")
            {
                validar = false;
                Error.SetError(tbxPrecio, "Ingresar un precio.");
            }
            if (tbxDescripcion.Text == "")
            {
                validar = false;
                Error.SetError(tbxDescripcion, "Ingresar un descripción.");
            }
            if (tbxUrlImagen.Text == "")
            {
                validar = false;
                Error.SetError(tbxUrlImagen, "Ingresar un UrlImagen.");
            }
            if(cbxMarca.SelectedItem==null)
            {
                validar = false;
                Error.SetError(cbxMarca, "Seleccionar marca.");
            }
            if (cbxCategoria.SelectedItem == null)
            {
                validar = false;
                Error.SetError(cbxCategoria, "Seleccionar categoría.");
            }

            return validar;
        }
        private void borrarErrores()
        {
            Error.SetError(tbxCodigo ,"");
            Error.SetError(tbxNombre ,"");
            Error.SetError(tbxDescripcion ,"");
            Error.SetError(tbxPrecio ,"");
            Error.SetError(tbxUrlImagen ,"");
            Error.SetError(cbxCategoria ,"");
            Error.SetError(cbxMarca ,"");
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            borrarErrores();
            if(validarCampos())
            {

                if (Articulo == null)
                { 
                    agregar(); 
                }
                else
                {
                    modificar();
                }

            }
            else
            {
                MessageBox.Show("Completar campos.");
            }
              
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
        private void modificar()
        {

            Articulos_neg art = new Articulos_neg();

            try
            {
                //Articulo articulo = new Articulo
                //{
                Articulo.Codigo = tbxCodigo.Text;
                Articulo.Nombre = tbxNombre.Text;
                Articulo.Descripcion = tbxDescripcion.Text;
                Articulo.Marca = (Marca)cbxMarca.SelectedItem;
                Articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                Articulo.UrlImagen = tbxUrlImagen.Text;
                Articulo.Precio = Convert.ToDouble(tbxPrecio.Text);
                //};

                if (art.modificarArticulo(Articulo))
                {
                    MessageBox.Show("Articulo modificado!");
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
