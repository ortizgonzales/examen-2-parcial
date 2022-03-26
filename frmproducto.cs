using datos.accesos;
using datos.entidades;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace EjercicioLogin
{
    public partial class frmproducto : Form
    {
        public frmproducto()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;

        productoDA productoDA = new productoDA();

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            txtcod.Enabled = true;
            txtdesc.Enabled = true;
            txtprecio.Enabled = true;
            txtexis.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;


        }

        private void DesabilitarControles()
        {
            txtcod.Enabled = false;
            txtdesc.Enabled = false;
            txtprecio.Enabled = false;
            txtexis.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;


        }
        private void LimpiarControles()
        {
            txtcod.Clear();
            txtdesc.Clear();
            txtprecio.Clear();
            txtexis.Clear();
         
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtcod.Text))
                {
                    errorProvider1.SetError(txtcod, "Ingrese el código");
                    txtcod.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtdesc.Text))
                {
                    errorProvider1.SetError(txtdesc, "Ingrese una descripción");
                    txtdesc.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtprecio.Text))
                {
                    errorProvider1.SetError(txtprecio, "Ingrese un precio");
                    txtprecio.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtexis.Text))
                {
                    errorProvider1.SetError(txtexis, "Ingrese una existencia");
                    txtexis.Focus();
                    return;
                }

                producto producto = new producto();
                producto.codigo = txtcod.Text;
                producto.descripcion = txtdesc.Text;
                producto.precio = Convert.ToDecimal(txtprecio.Text);
                producto.existencia = Convert.ToInt32(txtexis.Text);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                

                if (operacion == "Nuevo")
                {
                    bool inserto = productoDA.InsertaProducto(producto);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListaProductos();
                        MessageBox.Show("Producto insertado");
                    }


                }

            }
            catch (Exception)
            {
            }

        }
       

        private void ListaProductos()
        {
            ProductosdataGridView1.DataSource = productoDA.ListaProductos();
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                errorProvider1.SetError(txtprecio, "Ingrese un caracter numerico");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtexis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

       

        private void frmproducto_Load_1(object sender, EventArgs e)
        {
            ListaProductos();
        }

        private void txtexis_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
