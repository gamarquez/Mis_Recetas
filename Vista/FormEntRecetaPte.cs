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
    public partial class FormEntRecetaPte : Form
    {
        public FormEntRecetaPte()
        {
            InitializeComponent();
        }

        CmdEntRecetaPte com = new CmdEntRecetaPte();

        private void FormEntRecetaPte_Load(object sender, EventArgs e)
        {
            actulizarDataGrid();

            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = " ";
            chek.Name = "Seleccionar";
            chek.DisplayIndex = 0;
            chek.ReadOnly = false;

            dgvRecetas.Columns.Add(chek);

            dgvRecetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns["Seleccionar"].Width = 25;
            dgvRecetas.Columns[0].Width = 50;
            dgvRecetas.Columns[1].Width = 150;
            dgvRecetas.Columns[2].Width = 170;
            dgvRecetas.Columns[3].Width = 140;
            dgvRecetas.Columns[4].Width = 110;

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

            txtRetira.Enabled = false;
            txtParentezco.Enabled = false;
            btnEntregar.Enabled = false;

            dgvRecetas.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvRecetas.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

        }

        //Actualiza el datagridview con consulta en la DB
        DataSet resultados = new DataSet();
        DataView filtro;
        private void actulizarDataGrid()
        {
            resultados.Reset();
            com.ListarRecetasListas(ref resultados, "recetas");
            filtro = ((DataTable)resultados.Tables["recetas"]).DefaultView;
            dgvRecetas.DataSource = filtro;
        }

        //Aplica filtro Nombre y actualiza el datagridview
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

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borrarNoSeleccionado(int rowSelect)
        {
            foreach (DataGridViewRow Row in dgvRecetas.Rows)
            {
                if (Row.Index != rowSelect)
                {
                    ((DataGridViewCheckBoxCell)Row.Cells["Seleccionar"]).Value = false;
                }
            }
        }

        private void habilitarTxtRetira()
        {
            txtRetira.Enabled = false;
            foreach (DataGridViewRow Row in dgvRecetas.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["Seleccionar"].Value) == true)
                {
                    txtRetira.Enabled = true;
                }
            }
        }

        private void dgvRecetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarNoSeleccionado(e.RowIndex);
            dgvRecetas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvRecetas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            habilitarTxtRetira();
        }

        private void txtRetira_TextChanged(object sender, EventArgs e)
        {
            bool activarBtnEntregar = false;
            bool activarTxtParentezco = false;

            string[] palabraPaciente = { "pte", "Pte", "PTE", "paciente", "Paciente", "PACIENTE" };
            foreach (string palabra in palabraPaciente)
            {
                if (txtRetira.Text == palabra)
                {
                    activarBtnEntregar = true;
                }
            }

            if (txtRetira.Text.Length > 2 && activarBtnEntregar == false)
            {
                activarTxtParentezco = true;
            }
            btnEntregar.Enabled = activarBtnEntregar;
            txtParentezco.Enabled = activarTxtParentezco;
        }

        private void txtParentezco_TextChanged(object sender, EventArgs e)
        {
            if (txtParentezco.Text.Length > 2)
                btnEntregar.Enabled = true;
            else
                btnEntregar.Enabled = false;
        }

        private void txtRetira_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }

        private void txtParentezco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                e.Handled = false;
            else
                e.Handled = true;          //el resto de teclas pulsadas se desactivan
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            int idRecetaRetiraPte = 0;
            int cont = 0;
            String nombrePte = "";

            DialogResult dialogResult = DialogResult.No;

            foreach (DataGridViewRow Row in dgvRecetas.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["Seleccionar"].Value) == true)
                {
                    idRecetaRetiraPte = (int)Row.Cells["N° Receta"].Value;
                    nombrePte = (String)Row.Cells["Paciente"].Value;
                    cont += 1;
                }
            }
            if (cont == 1) //Si la cantidad de filas seleccionadas (true) en el foreach es mayor a 0
            {
                dialogResult = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Desea grabar? (SI/NO)
            }
            else //Si no se selecciono (false) ninguna fila
            {
                MessageBox.Show("Debe seleccionar una receta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dialogResult == DialogResult.Yes) //Si se selecciona SI, actualiza el estado de la receta
            {
                MessageBox.Show("Receta entregada al paciente: " + nombrePte, " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                com.ActualizarReceta_A_Entregada(idRecetaRetiraPte, txtRetira.Text, txtParentezco.Text);
                actulizarDataGrid();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtParentezco.Clear();
            txtRetira.Clear();
        }
    }
}
