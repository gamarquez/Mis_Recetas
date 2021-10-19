using Mis_Recetas.Controlador;
using MisRecetas.Modelo;
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
    public partial class FormRegistrarUsuario : Form
    {
        public FormRegistrarUsuario()
        {
            InitializeComponent();
        }

        CmdUsuarios com = new CmdUsuarios();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
            cargarComboRoles();
        }

        private void cargarComboRoles()
        {
            com.CargarComboRol(cboRol);
            cboRol.DisplayMember = "Descripcion";
            cboRol.ValueMember = "Id_Rol";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            

            DialogResult dialogResult = DialogResult.No;
            bool nuevoUser = false;

            if (nuevoUser == false)
            {
                dialogResult = MessageBox.Show("¿Desea registrar a un nuevo usuario?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (dialogResult == DialogResult.Yes)
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int idRol = cboRol.SelectedIndex + 1;
                string nomUsuario = txtNomUsuario.Text;
                string pass = txtPass.Text;
                com.RegistrarUsuario(nomUsuario, pass, idRol, nombre, apellido);
                MessageBox.Show("Usuario registrado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtNomUsuario.Clear();
            txtPass.Clear();
        }
    }
}
