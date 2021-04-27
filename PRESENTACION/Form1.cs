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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Articulos_neg aux = new Articulos_neg();
            dgvArticulos.DataSource = aux.listaArticulos();
            RecargarImg(aux.listaArticulos()[0].UrlImagen);
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
    }
}
