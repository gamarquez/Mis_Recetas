using Mis_Recetas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Vista
{
    public partial class FormModificarUsuario : Form
    {
        public FormModificarUsuario()
        {
            InitializeComponent();
        }

        CmdUsuarios com = new CmdUsuarios();
        private int idUser;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            string apellido = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            string rol = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            string user = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
            string pass = dgvUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            cboRol.SelectedIndex = getRol(rol) - 1;
            txtNomUsuario.Text = user;
            txtPass.Text = pass;
            idUser = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value);
        }

        private int getRol(string rol)
        {
            switch (rol)
            {
                case "Admin":
                    return 1;
                case "Administración":
                    return 2;
                case "Recepcionista":
                    return 3;
                default:
                    return 3;
            }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Obtengo el valor de lo campos y lo casteo a una variable.
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int rol = cboRol.SelectedIndex + 1;
            string user = txtNomUsuario.Text;
            string pass = txtPass.Text;

            //Llamo a los metodos y les paso las variables previamente casteadas.
            com.ActualizarUsuario(user, pass, rol, nombre, apellido, idUser);
            com.CargarUsuarios(dgvUsuarios);
            limpiarCampos();

        }

        private void limpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtNomUsuario.Clear();
            txtPass.Clear();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            com.CargarUsuarios(dgvUsuarios);
            dgvUsuarios.ClearSelection();
        }

        private void cargarComboRoles()
        {
            com.CargarComboRol(cboRol);
            cboRol.DisplayMember = "Descripcion";
            cboRol.ValueMember = "Id_Rol";
        }

        private void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            cargarComboRoles();
        }
    }
}
