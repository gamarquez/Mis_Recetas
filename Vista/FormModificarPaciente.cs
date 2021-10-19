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
    public partial class FormModificarPaciente : Form
    {
        public FormModificarPaciente()
        {
            InitializeComponent();
        }

        CmdModificarPaciente com = new CmdModificarPaciente();
        private int idPaciente;

        private void FormModificarPaciente_Load(object sender, EventArgs e)
        {
            txtDni.Focus();
            actulizarDataGrid();
            CargarComboTipoDocumentos();
            dgvPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[0].Width = 40;
            dgvPacientes.Columns[1].Width = 160;
            dgvPacientes.Columns[2].Width = 100;
            dgvPacientes.Columns[3].Width = 90;
            dgvPacientes.Columns[4].Width = 90;
            dgvPacientes.Columns[5].Width = 220;

            dgvPacientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPacientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPacientes.Columns[0].ReadOnly = true;
            dgvPacientes.Columns[1].ReadOnly = true;
            dgvPacientes.Columns[2].ReadOnly = true;
            dgvPacientes.Columns[3].ReadOnly = true;
            dgvPacientes.Columns[4].ReadOnly = true;
            dgvPacientes.Columns[5].ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;

            dgvPacientes.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(22, 110, 150);
            dgvPacientes.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }

        //Actualiza el datagridview con consulta en la DB
        DataSet resultados = new DataSet();
        DataView filtro;
        private void actulizarDataGrid()
        {
            resultados.Reset();
            com.CargarPacientes(ref resultados, "pacientes");
            filtro = ((DataTable)resultados.Tables["pacientes"]).DefaultView;
            dgvPacientes.DataSource = filtro;
        }

        //Aplica filtro Nombre y actualiza el datagridview
        private void filtroNombreDataGrid()
        {
            string salida_datos = "";
            if (txtNombreYApellido.Text != "")
            {
                if (txtDni.Text != "")
                    salida_datos = "(Nombre LIKE '%" + txtNombreYApellido.Text + "%' OR Apellido LIKE '%" + txtNombreYApellido.Text + "%' AND DNI LIKE '%" + Convert.ToInt32(txtDni.Text) + "%')";
                else
                    salida_datos = "(Nombre LIKE '%" + txtNombreYApellido.Text + "%' OR Apellido LIKE '%" + txtNombreYApellido.Text + "%')";
            }
            else
            {
                if (txtDni.Text != "")
                    salida_datos = "(DNI LIKE '%" + Convert.ToInt32(txtDni.Text) + "%')";
                else
                    filtro.RowFilter = string.Empty;
            }
            filtro.RowFilter = salida_datos;
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
        }

        private void txtNombreYApellido_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarComboTipoDocumentos()
        {

            cboTipoDoc.DataSource = com.CargarComboTipoDocumento();
            cboTipoDoc.DisplayMember = "Descripcion";
            cboTipoDoc.ValueMember = "Id_TipoDocumento";
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = dgvPacientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            string apellido = dgvPacientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            string tipoDoc = dgvPacientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            string nroDoc = dgvPacientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            string email = dgvPacientes.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            cboTipoDoc.SelectedIndex = getTipoDocumento(tipoDoc) - 1;
            txtNroDoc.Text = nroDoc;
            txtEmail.Text = email;
            idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private int getTipoDocumento(string tipoDoc)
        {
            switch (tipoDoc)
            {
                case "DNI":
                    return 1;
                case "LC":
                    return 2;
                case "LE":
                    return 3;
                case "OTRO":
                    return 4;
                default:
                    return 4;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }

        private void txtNombreYApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
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

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tipo_Dni = (int)cboTipoDoc.SelectedValue;
            switch (tipo_Dni)
            {
                case 1:
                    if (Char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                        e.Handled = false;
                    else
                        e.Handled = true;          //el resto de teclas pulsadas se desactivan
                    break;
                case 2:
                    if (Char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }

        private void limpiarCampos()
        {
            txtDni.Clear();
            txtNombreYApellido.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDoc.Clear();
            txtEmail.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int tipoDoc = cboTipoDoc.SelectedIndex + 1;
            string nroDoc = txtNroDoc.Text;
            string email = txtEmail.Text;

            com.ActualizarPaciente(nombre, apellido, tipoDoc, nroDoc, email, idPaciente);
            actulizarDataGrid();
            limpiarCampos();
        }
    }
}
