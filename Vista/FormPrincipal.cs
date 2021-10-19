using MisRecetas.Modelo;
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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            
            CargarDatosUsuario();
            //Se habilitan botones según el rol del usuario 
            // 1 para admin 
            // 2 para administraición
            // 3 para recepcionista

            if (Usuario.Id_Rol == 1)
            {
                lblPanelAdmin.Visible = true;
                pictureBox5.Visible = true;
                btnEnvRecetaArchivo.Visible = true;
                btnEntRecetaArchivada.Visible = true;
            }
            else
            {
                if (Usuario.Id_Rol == 2)
                {
                    lblPanelAdmin.Visible = false;
                    pictureBox5.Visible = true;
                    btnEnvRecetaArchivo.Visible = true;
                    btnEntRecetaArchivada.Visible = true;
                }
                else
                {
                    lblPanelAdmin.Visible = false;
                    pictureBox5.Visible = false;
                    btnEnvRecetaArchivo.Visible = false;
                    btnEntRecetaArchivada.Visible = false;
                    btnDesecharReceta.Visible = false;
                }
            }
        }

        private void CargarDatosUsuario()
        {
            lblName.Text = Usuario.Nombre + ", " + Usuario.Apellido;
            lblPosition.Text = Usuario.Rol;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Advertencia",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //--------------------METODO PARA PODER MOVER EL FORMULARIO DESDE EL panelBarraTitulo-----------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //---------------------------------------------------------------------------------------------------------------

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Advertencia", 
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //-------------------METODOS PARA PODER MAXIMIZAR Y RESTAURAR VENTANA--------------------------------------------
        // capturar posición y tamaño antes de maximizar
        int lx, ly;
        int sh, sw;

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sh = this.Size.Height;
            sw = this.Size.Width;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault(); //Busca en la conexion el formulario
            //si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                //formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            //si el formulario existe
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(Object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormRecRecetaPte"] == null)
                btnRecRecetaPte.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormEntRecetaMedico"] == null)
                btnEntRecetaMco.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormRecRecetaMedico"] == null)
                btnRecRecetaMco.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormEntRecetaPte"] == null)
                btnEntRecetaPte.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormArchivarRecetas"] == null)
                btnEnvRecetaArchivo.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormEntRecetaArchivada"] == null)
                btnEntRecetaArchivada.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormDesecharRecetas"] == null)
                btnDesecharReceta.BackColor = Color.FromArgb(138, 235, 213);
            if (Application.OpenForms["FormBuscarReceta"] == null)
                btnBuscarReceta.BackColor = Color.FromArgb(171, 242, 224);
        }

        private void btnRecRecetaMco_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRecRecetaMedico>();
            btnRecRecetaMco.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void btnEntRecetaPte_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEntRecetaPte>();
            btnEntRecetaPte.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void btnEnvRecetaArchivo_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormArchivarRecetas>();
            btnEnvRecetaArchivo.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void lblPanelAdmin_Click(object sender, EventArgs e)
        {
            FormAdminPanel ap = new FormAdminPanel();
            ap.Show();
        }

        private void btnEntRecetaArchivada_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEntRecetaArchivada>();
            btnEntRecetaArchivada.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void btnDesecharReceta_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDesecharRecetas>();
            btnDesecharReceta.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void btnBuscarReceta_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBuscarReceta>();
            btnBuscarReceta.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormTerminosYCondiciones tyc = new FormTerminosYCondiciones();
            tyc.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormAyuda ayuda = new FormAyuda();
            ayuda.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnRecRecetaPte_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRecRecetaPte>();
            btnRecRecetaPte.BackColor = Color.FromArgb(136, 227, 198);
        }

        private void btnEntRecetaMco_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEntRecetaMedico>();
            btnEntRecetaMco.BackColor = Color.FromArgb(136, 227, 198);
        }


    }
}
