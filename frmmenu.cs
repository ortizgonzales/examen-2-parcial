using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EjercicioLogin
{
    public partial class frmmenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }
        Frmusuarios frmusuarios = null;
        frmproducto frmProducto = null;
        frmfactura frmfactura = null;
       

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmusuarios == null)
            {
                frmusuarios = new Frmusuarios();
                frmusuarios.MdiParent = this;
                frmusuarios.FormClosed += Frmusuarios_FormClosed;
                frmusuarios.Show();
            }
            else
            {
                frmusuarios.Activate();
            }
        }

        private void Frmusuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmusuarios = null;
        }

        private void productos_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new frmproducto();
                frmProducto.MdiParent = this;
                frmProducto.FormClosed += frmProducto_FormClosed;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void frmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null; 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (frmfactura == null)
            {
                frmfactura = new frmfactura();
                frmfactura.MdiParent = this;
                frmfactura.FormClosed += frmfactura_FormClosed;
                frmfactura.Show();
            }
            else
            {
                frmfactura.Activate();
            }
        }

        private void frmfactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrmFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmfactura = null;
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {

        }
    }
    }

