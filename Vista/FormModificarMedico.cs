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
    public partial class FormModificarMedico : Form
    {
        public FormModificarMedico()
        {
            InitializeComponent();
        }

        CmdMedicos com = new CmdMedicos();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgvMedicos_SelectionChanged(object sender, EventArgs e)
        {
            string nombre = Convert.ToString(dgvMedicos.CurrentRow.Cells["Nombre"].Value);
            string apellido = Convert.ToString(dgvMedicos.CurrentRow.Cells["Apellido"].Value);
            string matricula = Convert.ToString(dgvMedicos.CurrentRow.Cells["Matricula"].Value);

            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtMatricula.Text = matricula;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Obtengo el valor de lo campos y lo casteo a una variable.
            String matricula = txtMatricula.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int id = Convert.ToInt32(dgvMedicos.CurrentRow.Cells["ID"].Value);

            //Llamo a los metodos y les paso las variables previamente casteadas.
            com.ActualizarMedico(matricula, nombre, apellido, id);
            com.CargarMedicos(dgvMedicos);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //Cargo la grilla de medicos y la indexeo a 0.
            com.CargarMedicos(dgvMedicos);
            dgvMedicos.ClearSelection();
        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
    }
}
