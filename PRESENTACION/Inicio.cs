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
            pbxImg.Load(img);
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
            frmAgregar form = new frmAgregar();
            form.Show();
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

    }
}
