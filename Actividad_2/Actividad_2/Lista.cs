using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Business;

namespace Actividad_2
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }
        private List<Articulo> listaArticulo;

        private void Lista_Load(object sender, EventArgs e)
        {
            cargarGrilla();


            /////
            MarcaBusiness MarcaBusiness = new MarcaBusiness();

            try
            {
                cboMarca.DataSource = MarcaBusiness.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ///


        }
        private void cargarGrilla()
        {
            ArticuloBusiness ArticuloBusiness = new ArticuloBusiness();
            try
            {

                listaArticulo = ArticuloBusiness.Listar2();
                dgvArticulos.RowHeadersVisible = false;
                dgvArticulos.DataSource = listaArticulo;


                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                dgvArticulos.Columns["Id"].Visible = false;

                dgvArticulos.Columns["ImagenUrl"].Visible = false;


                RecargarImg(listaArticulo[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString());

            }
        }
        private void RecargarImg(string img)
        {
            try
            {
                pbxArticulo.Load(img);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la imagen");
                // throw;
            }
        }


            private void dgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
 
        }

        private void dgvArticulos_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                RecargarImg(seleccionado.ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
         
        }

    }
}
