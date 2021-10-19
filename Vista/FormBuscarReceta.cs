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
    public partial class FormBuscarReceta : Form
    {
        public FormBuscarReceta()
        {
            InitializeComponent();
        }

        CmdBuscarReceta com = new CmdBuscarReceta();

        private void FormBuscarReceta_Load(object sender, EventArgs e)
        {
            txtNReceta.Focus();
            actulizarDataGrid();

            dgvRecetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[0].Width = 50;
            dgvRecetas.Columns[1].Width = 150;
            dgvRecetas.Columns[2].Width = 120;
            dgvRecetas.Columns[3].Width = 150;
            dgvRecetas.Columns[4].Width = 150;

            dgvRecetas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRecetas.Columns[0].ReadOnly = true;
            dgvRecetas.Columns[1].ReadOnly = true;
            dgvRecetas.Columns[2].ReadOnly = true;
            dgvRecetas.Columns[3].ReadOnly = true;
            dgvRecetas.Columns[4].ReadOnly = true;
     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataSet resultados = new DataSet();
        DataView filtro;
        private void actulizarDataGrid()
        {
            resultados.Reset();
            com.ListarRecetas(ref resultados, "recetas");
            filtro = ((DataTable)resultados.Tables["recetas"]).DefaultView;
            dgvRecetas.DataSource = filtro;
        }

        private void txtNReceta_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtNReceta.Text != "")
            {
                txtApellido.Enabled = false;
                txtDni.Enabled = false;
                txtNombre.Enabled = false;
                com.BuscarRecetasPorNumero(dgvRecetas, Convert.ToInt32(txtNReceta.Text));
            }
            else
            {
                txtApellido.Enabled = true;
                txtDni.Enabled = true;
                txtNombre.Enabled = true;
                actulizarDataGrid();
            }
            
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            String nombre = txtNombre.Text;
            com.BuscarRecetasPorNombre(dgvRecetas, nombre);
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            String apellido = txtApellido.Text;
            com.BuscarRecetasPorApellido(dgvRecetas, apellido);
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtDni.Text != "")
            {
                String dni = txtDni.Text;

                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtNReceta.Enabled = false;

                com.BuscarRecetasPorDni(dgvRecetas, dni);
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtNReceta.Enabled = true;
                actulizarDataGrid();
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNReceta.Text = string.Empty;
            txtNReceta.Enabled = true;
            txtApellido.Text = string.Empty;
            txtApellido.Enabled = true;
            txtDni.Text = string.Empty;
            txtDni.Enabled = true;
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = true;
            actulizarDataGrid();
 
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

        private void txtNReceta_KeyPress(object sender, KeyPressEventArgs e)
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
