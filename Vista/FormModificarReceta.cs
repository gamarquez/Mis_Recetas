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
    public partial class FormModificarReceta : Form
    {
        public FormModificarReceta()
        {
            InitializeComponent();
        }

        CmdModificarReceta com = new CmdModificarReceta();

        private void FormModificarReceta_Load(object sender, EventArgs e)
        {
            actulizarDataGrid();
            cargarComboMedicos();
            cargarComboEstados();

            dgvRecetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[0].Width = 40;
            dgvRecetas.Columns[1].Width = 140;
            dgvRecetas.Columns[2].Width = 90;
            dgvRecetas.Columns[3].Width = 130;
            dgvRecetas.Columns[4].Width = 120;

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
            dgvRecetas.RowHeadersVisible = false;


            dgvRecetas.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(22, 110, 150);
            dgvRecetas.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        //Actualiza el datagridview con consulta en la DB
        DataSet resultados = new DataSet();
        DataView filtro;
        private void actulizarDataGrid()
        {
            resultados.Reset();
            com.ListarRecetas(ref resultados, "recetas");
            filtro = ((DataTable)resultados.Tables["recetas"]).DefaultView;
            dgvRecetas.DataSource = filtro;
        }

        private void cargarComboMedicos()
        {
            cboMedico.DataSource = com.CargarComboMedico();
            cboMedico.DisplayMember = "Medico";
            cboMedico.ValueMember = "Id_Medico";
        }

        private void cargarComboEstados()
        {
            com.CargarComboEstado(cboEstado);
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.ValueMember = "Id_Estado";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtroNombreDataGrid()
        {
            string salida_datos = "";
            if (txtNombre.Text != "")
            {
                if (txtDni.Text != "")
                    salida_datos = "(Paciente LIKE '%" + txtNombre.Text + "%' AND DNI LIKE '%" + Convert.ToInt32(txtDni.Text) + "%')";
                else
                    salida_datos = "(Paciente LIKE '%" + txtNombre.Text + "%')";
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

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
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

        private void txtNroReceta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNroReceta_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNroReceta.Text != "")
            {
                com.BuscarRecetasPorNumero(dgvRecetas, Convert.ToInt32(txtNroReceta.Text));
            }
            else
            {
                actulizarDataGrid();
            }
        }

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            int seleccion = dgvRecetas.CurrentRow.Index + 1;

            //Consulto si es igual a 0, y envio un mensaje para su correccion
            if (seleccion == 0)
            {
                MessageBox.Show("Seleccione un registro para modifcar!");
            }
            //En caso de que se seleccione una fila, se ejecuta el metodo.
            else
            {
                //Obtengo el valor de lo campos y lo casteo a una variable.
                int estado = (int)cboEstado.SelectedIndex + 1;
                int id = Convert.ToInt32(dgvRecetas.CurrentRow.Cells[0].Value);

                //Llamo a los metodos y les paso las variables previamente casteadas.
                com.ModificarEstadoReceta(id, estado);
                actulizarDataGrid();
                limpiarCampos();
            }
        }

        private void btnModificarMedico_Click(object sender, EventArgs e)
        {
            int seleccion = dgvRecetas.CurrentRow.Index + 1;

            //Consulto si es igual a 0, y envio un mensaje para su correccion
            if (seleccion == 0)
            {
                MessageBox.Show("Seleccione un registro para modifcar!");
            }
            //En caso de que se seleccione una fila, se ejecuta el metodo.
            else
            {
                //Obtengo el valor de lo campos y lo casteo a una variable.
                int medico = (int)cboMedico.SelectedIndex + 1;
                int id = Convert.ToInt32(dgvRecetas.CurrentRow.Cells[0].Value);

                //Llamo a los metodos y les paso las variables previamente casteadas.
                com.ModificarMedicoReceta(id, medico);
                actulizarDataGrid();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtDni.Clear();
            txtNroReceta.Clear();
            txtNombre.Clear();
        }
    }
}
