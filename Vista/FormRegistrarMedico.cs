using Mis_Recetas.Controlador;
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
    public partial class FormRegistrarMedico : Form
    {
        public FormRegistrarMedico()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            CmdMedicos com = new CmdMedicos();
            Medico med = new Medico();

            DialogResult dialogResult = DialogResult.No;
            bool nuevoMed = false;

            if (nuevoMed == false)
            {
                dialogResult = MessageBox.Show("¿Desea registrar a un nuevo médico?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (dialogResult == DialogResult.Yes)
            {
                med.Nombre_Medico = txtNombre.Text;
                med.Apellido_Medico = txtApellido.Text;
                med.Nro_Matricula = Convert.ToInt32(txtMatricula.Text);
                com.RegistrarMedico(med);

                MessageBox.Show("Médico registrado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                limpiarCampos();
            }    
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtMatricula.Clear();
        }

        private void FormRegistrarMedico_Load(object sender, EventArgs e)
        {

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }
    }
}
