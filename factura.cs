using datos.accesos;
using datos.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioLogin
{
    public partial class frmfactura : Form
    {
        public frmfactura()
        {
            InitializeComponent();
        }
        productoDA productoDA = new productoDA();
        factura factura = new factura();
        producto producto;
        facturaDA facturaDA = new facturaDA();

        List<detallefactura> detallefacturaLista = new List<detallefactura>();

        decimal subtotal = decimal.Zero;
        decimal imp = decimal.Zero;
        decimal total = decimal.Zero;


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            factura.idencliente = IdentidadMaskedTextBox.Text;
            factura.cliente = NombreTextBox.Text;
            factura.fecha = dateTimePicker1.Value;
            factura.subtotal = Convert.ToDecimal(SubTotalTextBox.Text);
            factura.imp = Convert.ToDecimal(ISVTextBox.Text);
            factura.total = Convert.ToDecimal(TotalTextBox.Text);

            int idFactura = 0;

            idFactura = facturaDA.InsertarFactura(factura);

            if (idFactura != 0)
            {
                foreach (var item in detallefacturaLista)
                {
                    item.idfactura = idFactura;
                    facturaDA.InsertarDetalle(item);
                }
            }

        }

        private void frmfactura_Load(object sender, EventArgs e)
        {
            DetalleDataGridView.DataSource = detallefacturaLista;

        }



        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new producto();
                producto = productoDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionProductoTextBox.Text = producto.descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionProductoTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                detallefactura detalleFactura = new detallefactura();
                detalleFactura.codproducto = producto.codigo;
                detalleFactura.descripcion = producto.descripcion;
                detalleFactura.cant = Convert.ToInt32(CantidadTextBox.Text);
                detalleFactura.precio = producto.precio;
                detalleFactura.total = producto.precio * Convert.ToInt32(CantidadTextBox.Text);






                subtotal += detalleFactura.total;

                imp = subtotal * 0.15M;
                total = subtotal + imp;

                SubTotalTextBox.Text = subtotal.ToString();
                ISVTextBox.Text = imp.ToString();
                TotalTextBox.Text = total.ToString();

                detallefacturaLista.Add(detalleFactura);
                DetalleDataGridView.DataSource = null;
                DetalleDataGridView.DataSource = detallefacturaLista;


            }
        }

        private void DetalleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdentidadMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
