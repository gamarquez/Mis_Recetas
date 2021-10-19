using Mis_Recetas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Vista
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //--------------------------------MINIMIZA LA VENTANA---------------------------------------------------------------
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //------------------------------------------------------------------------------------------------------------------


        //--------------------------------CIERRA LA APLICACION--------------------------------------------------------------
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //------------------------------------------------------------------------------------------------------------------


        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }


        //---------METODO PARA INGRESAR AL FormPrincipal CUANDO SE PRESIONA LA TECLA ENTER SOBRE EL txtPass-----------------
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginUser();
            }
        }
        //------------------------------------------------------------------------------------------------------------------


        //-------------------------COMPORTAMIENTO EN EL txtUser y txtPass AL HACER CLICK------------------------------------
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------

        
        //------------------METODOS PARA PODER MOVER EL FORMULARIO-----------------------------------------------------------

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //-----------------------------------------------------------------------------------------------------------------


        //---------------AL SALIR DEL FormPrincipal, MUESTRA EL FormLogin--------------------------------------------------
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUser.Text = "USUARIO";
            txtPass.UseSystemPasswordChar = false;
            txtPass.Text = "CONTRASEÑA";
            lblMensajeError.Visible = false;
            this.Show();
            btnLogin.Focus();
        }
        //-----------------------------------------------------------------------------------------------------------------


        //------COMPROBACION DE USUARIO Y CONTRASEÑA, SI SON CORRECTOS MUESTRA EL FormPrincipal, SINO MUESTRA ERROR--------
        private void msgError(string msg)
        {
            lblMensajeError.Text = msg;
            lblMensajeError.Visible = true;
        }
        private void LoginUser()
        {
            if (txtUser.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    CmdLogin com = new CmdLogin();
                    var validLogin = com.Login(txtUser.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        FormPrincipal menuPrincipal = new FormPrincipal();
                        menuPrincipal.Show();
                        menuPrincipal.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Tu usuario y/o contraseña son incorrectos");
                        txtPass.UseSystemPasswordChar = false;
                        txtPass.Text = "CONTRASEÑA";
                        txtUser.Focus();
                    }
                }
                else msgError("Ingrese una contraseña");

            }
            else msgError("Ingrese un usuario");
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
