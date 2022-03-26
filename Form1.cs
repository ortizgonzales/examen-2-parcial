using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using datos;
using datos.accesos;
using datos.entidades;




namespace EjercicioLogin
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

     

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnacep_Click(object sender, EventArgs e)
        {
            usuarioDAA usuarioDAA = new usuarioDAA();

            usuario usuario = new usuario();

            usuario = usuarioDAA.login(txtsuario.Text, txtcontra.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos erroneos");
                return;
            }

            frmmenu frmMenu = new frmmenu();
            frmMenu.Show();
            this.Hide();


        }
    }
}
