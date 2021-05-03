using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using Dominio;

namespace Actividad_2
{
    public partial class Buscar : Form
    {
        private List<Articulo> listaArticulo;
        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            TxtBuscar.Visible = false; 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
            {
                TxtBuscar.Visible = true;
            }
            else
            {
                TxtBuscar.Visible = true;
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                /// Se carga el Data Grid
                ArticuloBusiness ArticuloBusiness = new ArticuloBusiness();
                listaArticulo = ArticuloBusiness.buscarid(TxtBuscar.Text);

               
                ////LLEno los labels
                CargarLabel();
            }
            if (radioButton2.Checked)
            {
                /// Se carga el Data Grid
                ArticuloBusiness ArticuloBusiness = new ArticuloBusiness();
                listaArticulo = ArticuloBusiness.buscardesc(TxtBuscar.Text);

                    ////Lleno los labels
                    CargarLabel();
                

            }

        }  
        public void CargarLabel()
        {

            try
            {
                ///Se Ocultan las columnas
                LbVisible();
                DgvArticulos.RowHeadersVisible = false;
                DgvArticulos.DataSource = listaArticulo;
                DgvArticulos.Columns["Descripcion"].Visible = false;
                DgvArticulos.Columns["ImagenUrl"].Visible = false;
                DgvArticulos.Columns["Id"].Visible = false;
                DgvArticulos.Columns["Marca"].Visible = false;
                DgvArticulos.Columns["Categoria"].Visible = false;
                DgvArticulos.Columns["Precio"].Visible = false;
                ///

                /// SE CARGAN LOS LABELS
                LCodigo.Text = listaArticulo[0].Codigo;
                    LNombre.Text = listaArticulo[0].Nombre;
                    LDescripcion.Text = listaArticulo[0].Descripcion;
                    LURL.Text = listaArticulo[0].ImagenUrl;
                    LMarca.Text = Convert.ToString(listaArticulo[0].Marca);
                    LCategoria.Text = Convert.ToString(listaArticulo[0].Categoria);
                decimal Ndecimal = decimal.Round(listaArticulo[0].Precio, 2, MidpointRounding.AwayFromZero);
                LPrecio.Text = Convert.ToString(Ndecimal);
               // LPrecio.Text = Convert.ToString(listaArticulo[0].Precio);
                    RecargarImg(listaArticulo[0].ImagenUrl);
               
            }

            catch (Exception)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void LbVisible()
        {
            
            LCodigo.Visible = true;
            LNombre.Visible = true;
            LDescripcion.Visible = true;
            LMarca.Visible = true;
            LCategoria.Visible = true;
            
            LPrecio.Visible = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { 
            LId.Visible = true;
            LURL.Visible = true;
            //LbId.Visible = true;
            LbURL.Visible = true;

            }
            else
            {
                LId.Visible = false;
                LURL.Visible = false;
              //  LbId.Visible = false;
                LbURL.Visible = false;
            }
        }

        private void DgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            CambioDvg();
        }

        private void CambioDvg()
        {
            try
            {

                    Articulo seleccionado = (Articulo)DgvArticulos.CurrentRow.DataBoundItem;
                    //CargarLabel();
                    LLenarLB(seleccionado);
                    LLenarTX(seleccionado);
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void LLenarLB( Articulo seleccionado)
        {
            LCodigo.Text = seleccionado.Codigo;
            LNombre.Text = seleccionado.Nombre;
            LDescripcion.Text = seleccionado.Descripcion;
            LMarca.Text = Convert.ToString(seleccionado.Marca);
            LCategoria.Text = Convert.ToString(seleccionado.Categoria);

            decimal Ndecimal = decimal.Round(seleccionado.Precio, 2, MidpointRounding.AwayFromZero);
            LPrecio.Text = Convert.ToString(Ndecimal);
            //LPrecio.Text = Convert.ToString(seleccionado.Precio);
            LURL.Text = seleccionado.ImagenUrl;
            RecargarImg(seleccionado.ImagenUrl);
        }
        private void LLenarTX(Articulo seleccionado)
        {
            txtCodigo.Text = seleccionado.Codigo;
            txtNombre.Text = seleccionado.Nombre;
            txtDescripcion.Text = seleccionado.Descripcion;
            //txtMarca.Text = Convert.ToString(seleccionado.Marca);
            //txtCategoria.Text = Convert.ToString(seleccionado.Descripcion);
            decimal Ndecimal = decimal.Round(seleccionado.Precio, 2, MidpointRounding.AwayFromZero);
            txtPrecio.Text = Convert.ToString(Ndecimal);
            txtUrlImagen.Text = seleccionado.ImagenUrl;
           //txtPrecio.Text = Convert.ToString(seleccionado.Precio);
            RecargarImg(seleccionado.ImagenUrl);
        }
        private void CargarCbx()
        {
            MarcaBusiness marcaBusiness = new MarcaBusiness();
            CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
            try
            {
                cboMarca.DataSource = marcaBusiness.listar();
                cboCategoria.DataSource = categoriaBusiness.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarGrilla()
        {
            ArticuloBusiness ArticuloBusiness = new ArticuloBusiness();
            
            try
            {

                listaArticulo = ArticuloBusiness.Listar2();
                DgvArticulos.RowHeadersVisible = false;
                DgvArticulos.DataSource = listaArticulo;

                
                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                DgvArticulos.Columns["Id"].Visible = false;
                DgvArticulos.Columns["ImagenUrl"].Visible = false;

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

        private void opcionesAgregar(bool activo)
        {
            if (activo)
            {
                txtCodigo.Visible = true;
                txtNombre.Visible = true;
                txtDescripcion.Visible = true;
                txtPrecio.Visible = true;
                txtUrlImagen.Visible = true;
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
                cboCategoria.Visible = true;
                cboMarca.Visible = true;
                LbURL.Visible = true;
                LbId.Visible = false;
                LCodigo.Visible = false;
                LNombre.Visible = false;
                LDescripcion.Visible = false;
                LMarca.Visible = false;
                LCategoria.Visible = false;
                LPrecio.Visible = false;
                LURL.Visible = false;
                    
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gbxBuscar.Visible = false;

                LbTitulo.Text = "Agregar artículo";
                DgvArticulos.Location = new System.Drawing.Point(40, 50);
                DgvArticulos.Size = new System.Drawing.Size(611, 104);
            }
            else
            {
                txtCodigo.Visible = false;
                txtNombre.Visible = false;
                txtDescripcion.Visible = false;
                txtPrecio.Visible = false;
                txtUrlImagen.Visible = false;
                btnAceptar.Visible = false;
                btnCancelar.Visible = false;
                cboCategoria.Visible = false;
                LbURL.Visible = false;
                cboMarca.Visible = false;

                LbId.Visible = false;
                btnAgregar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                gbxBuscar.Visible = true;

                LbTitulo.Text = "Busqueda de artículos";
                DgvArticulos.Location = new System.Drawing.Point(480, 58);
                DgvArticulos.Size = new System.Drawing.Size(207, 150);
            }
        }
        private void opcionesEditar(bool activo)
        {
            if (activo)
            {
                txtCodigo.Visible = true;
                txtNombre.Visible = true;
                txtDescripcion.Visible = true;
                txtPrecio.Visible = true;
                txtUrlImagen.Visible = true;
                btnEditar2.Visible = true;
                btnCancelar.Visible = true;
                cboCategoria.Visible = true;
                cboMarca.Visible = true;
                LbURL.Visible = true;
                LbId.Visible = false;
                LCodigo.Visible = false;
                LNombre.Visible = false;
                LDescripcion.Visible = false;
                LMarca.Visible = false;
                LCategoria.Visible = false;
                LPrecio.Visible = false;
                LURL.Visible = false;
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gbxBuscar.Visible = false;

                LbTitulo.Text = "Editar artículo";
                DgvArticulos.Location = new System.Drawing.Point(40, 50);
                DgvArticulos.Size = new System.Drawing.Size(611, 104);
            }
            else
            {
                txtCodigo.Visible = false;
                txtNombre.Visible = false;
                txtDescripcion.Visible = false;
                txtPrecio.Visible = false;
                txtUrlImagen.Visible = false;
                btnAceptar.Visible = false;
                btnCancelar.Visible = false;
                cboCategoria.Visible = false;
                LbURL.Visible = false;
                cboMarca.Visible = false;
                LbId.Visible = false;
                btnAgregar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                gbxBuscar.Visible = true;
                btnEditar2.Visible = false;
                //btnEditar.Visible = false;
                LbTitulo.Text = "Busqueda de artículos";
                DgvArticulos.Location = new System.Drawing.Point(480, 58);
                DgvArticulos.Size = new System.Drawing.Size(207, 150);
            }
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            cargarGrilla();
            opcionesAgregar(true);
            CargarCbx();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloBusiness articuloBusiness = new ArticuloBusiness();
            ///Valido si el Codigo existe
       
            listaArticulo = articuloBusiness.buscarid(txtCodigo.Text);
            if (listaArticulo.Count>0)
            {
                MessageBox.Show("El articulo ya existe");
            }
            else
            {
                try
                {

                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articulo.ImagenUrl = txtUrlImagen.Text;
                    articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                    articuloBusiness.agregar(articulo);
                    MessageBox.Show("El articulo se agrego a la base de datos");
                    cargarGrilla();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }






        }
        private void btnEditar2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcionesAgregar(false);
            btnEditar2.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MarcaBusiness marcaBusiness = new MarcaBusiness();
            CategoriaBusiness categoriaBusiness = new CategoriaBusiness();

            cargarGrilla();
            CargarCbx();
            opcionesEditar(true);
            //CambioDvg();
        }

        private void btnEditar2_Click_1(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloBusiness articuloBusiness = new ArticuloBusiness();

            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articuloBusiness.editar(articulo);
                MessageBox.Show("El articulo se modifico");
                opcionesEditar(false);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloBusiness articuloBusiness = new ArticuloBusiness();
           // CambioDvg();
            //CargarLabel();
            try
            {
                if (MessageBox.Show("¿Desea eliminar permanentemente el Articulo?", "Percusión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    articulo.Codigo = LCodigo.Text;
                    articuloBusiness.eliminar(articulo);
                    MessageBox.Show("El Articulo se Elimino");
                    cargarGrilla();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
