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
    public partial class FormDesecharRecetas : Form
    {
        public FormDesecharRecetas()
        {
            InitializeComponent();
        }

        CmdDesecharRecetas com = new CmdDesecharRecetas();

        private void FormDesecharRecetas_Load(object sender, EventArgs e)
        {
            actulizarDataGrid();

            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = " ";
            chek.Name = "Seleccionar";
            chek.DisplayIndex = 0;
            chek.ReadOnly = false;

            dgvRecetasDesechar.Columns.Add(chek);

            dgvRecetasDesechar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns["Seleccionar"].Width = 25;
            dgvRecetasDesechar.Columns[0].Width = 50;
            dgvRecetasDesechar.Columns[1].Width = 150;
            dgvRecetasDesechar.Columns[2].Width = 120;
            dgvRecetasDesechar.Columns[3].Width = 150;
            dgvRecetasDesechar.Columns[4].Width = 70;
            dgvRecetasDesechar.Columns[5].Width = 150;

            dgvRecetasDesechar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasDesechar.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRecetasDesechar.Columns[0].ReadOnly = true;
            dgvRecetasDesechar.Columns[1].ReadOnly = true;
            dgvRecetasDesechar.Columns[2].ReadOnly = true;
            dgvRecetasDesechar.Columns[3].ReadOnly = true;
            dgvRecetasDesechar.Columns[4].ReadOnly = true;
            dgvRecetasDesechar.Columns[5].ReadOnly = true;
            dgvRecetasDesechar.RowHeadersVisible = false;

            dgvRecetasDesechar.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvRecetasDesechar.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            ActivarDesactivarCheck(false);
            lblCant.Text = Convert.ToString(contarItemSelect());
        }

        private void actulizarDataGrid()
        {
            com.ListarRecetasDesechar(dgvRecetasDesechar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActivarDesactivarCheck(bool vBool)
        {
            foreach (DataGridViewRow row in dgvRecetasDesechar.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Seleccionar"];
                chk.Value = vBool;
                dgvRecetasDesechar.RefreshEdit();
            }
        }

        private int contarItemSelect()
        {
            int cantSelect = 0;

            if (dgvRecetasDesechar.Rows.Count != 0)
            {
                foreach (DataGridViewRow R in dgvRecetasDesechar.Rows)
                {
                    if (Convert.ToBoolean(R.Cells["Seleccionar"].Value) == true)
                    {
                        cantSelect += 1;
                    }
                }
            }
            else
                cantSelect = 0;

            return cantSelect;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCheck(true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCheck(false);
        }

        private void btnArchivar_Click(object sender, EventArgs e)
        {
            List<int> idRecetasList = new List<int>();

            DialogResult dialogResult = DialogResult.No;

            foreach (DataGridViewRow R in dgvRecetasDesechar.Rows)
            {
                if (Convert.ToBoolean(R.Cells["Seleccionar"].Value) == true)
                {
                    idRecetasList.Add(Convert.ToInt32(R.Cells["N° Receta"].Value));
                }
            }

            int[] idRecetasArray = idRecetasList.ToArray();

            if (idRecetasArray.Length > 0)
            {
                dialogResult = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una receta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dialogResult == DialogResult.Yes)
            {
                com.DesecharRecetas(idRecetasArray);

                if (idRecetasArray.Length > 1) //Si la cantidad de recetas seleccionadas es mayor a 1
                {
                    MessageBox.Show("Se han desechado " + idRecetasArray.Length + " recetas", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    lblCant.Text = Convert.ToString(contarItemSelect());
                }
                else if (idRecetasArray.Length == 1)
                {
                    MessageBox.Show("Se ha desechado " + idRecetasArray.Length + " receta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    lblCant.Text = Convert.ToString(contarItemSelect());
                }
            }
            lblCant.Text = Convert.ToString(contarItemSelect());
        }

        private void dgvRecetasDesechar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRecetasDesechar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvRecetasDesechar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecetasDesechar.DataSource != null)
            {
                lblCant.Text = Convert.ToString(contarItemSelect());
            }
        }
    }
}
