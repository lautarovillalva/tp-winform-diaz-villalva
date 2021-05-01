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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargarArticulos();

        }




        private void RecargarImg(string img)
        {
            try
            {
                pbxImg.Load(img);
            }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            MessageBox.Show(seleccionado.Descripcion);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmArticulo form = new frmArticulo();
            form.ShowDialog();
            cargarArticulos();
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            string texto = "";
            texto = tbxFiltro.Text;

            if(texto != "")
            {
                Articulos_neg aux = new Articulos_neg();
                dgvArticulos.DataSource = aux.listaArticulosFiltrados(texto);
            }

            else
            {
                cargarArticulos();
            }
           
        }


        private void cargarArticulos()
        {
            Articulos_neg aux = new Articulos_neg();
            dgvArticulos.DataSource = aux.listaArticulos();
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            RecargarImg(aux.listaArticulos()[0].UrlImagen);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmArticulo modificar = new frmArticulo(seleccionado);
            modificar.ShowDialog();
            cargarArticulos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            Articulos_neg articulos_Neg = new Articulos_neg();
            try
            {
                if (MessageBox.Show("Estás seguro que deseas elminar el artículo?", "Eliminado!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    articulos_Neg.eliminarArticulo(seleccionado);
                }
                cargarArticulos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
