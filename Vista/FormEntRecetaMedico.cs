using Mis_Recetas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Vista
{
    public partial class FormEntRecetaMedico : Form
    {
        public FormEntRecetaMedico()
        {
            InitializeComponent();
        }

        CmdEntRecetaMedico com = new CmdEntRecetaMedico();

        private void FormEntRecetaMedico_Load(object sender, EventArgs e)
        {
            CargarComboMedicos();
            actulizarDataGrid();
            ContadorDeRecetas();

            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = " ";
            chek.Name = "Seleccionar";
            chek.DisplayIndex = 0;
            chek.ReadOnly = false;

            dgvRecetas.Columns.Add(chek);

            dgvRecetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns["Seleccionar"].Width = 25;
            dgvRecetas.Columns[0].Width = 40;
            dgvRecetas.Columns[1].Width = 150;
            dgvRecetas.Columns[2].Width = 120;
            dgvRecetas.Columns[3].Width = 150;
            dgvRecetas.Columns[4].Width = 130;

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

            dgvRecetas.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvRecetas.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            ActivarDesactivarCheck(false);
        }

        private void ContadorDeRecetas()
        {
            int con = dgvRecetas.Rows.Count;
            lblContador.Text = Convert.ToString(con);
        }

        private void CargarComboMedicos()
        {
            cboMedico.DataSource = com.CargarComboMedico();
            cboMedico.DisplayMember = "Medico";
            cboMedico.ValueMember = "Id_Medico";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            actulizarDataGrid();
            ContadorDeRecetas();
        }

        private void actulizarDataGrid()
        {
            int id = (int)cboMedico.SelectedValue;
            com.ListarRecetasPorMedicoEstado1(id, dgvRecetas);
        }

        private void ActivarDesactivarCheck(bool vBool)
        {
            foreach (DataGridViewRow row in dgvRecetas.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Seleccionar"];
                chk.Value = vBool;
                dgvRecetas.RefreshEdit();
            }
        }


        //-------------------------------Comportamiento del botón CheckBox all TRUE----------------------------------------------------
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCheck(true);
        }
        //-----------------------------------------------------------------------------------------------------------------------------


        //-------------------------------Comportamiento del botón CheckBox all FALSE----------------------------------------------------
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCheck(false);
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            List<int> idRecetasList = new List<int>();

            DialogResult dialogResult = DialogResult.No;
      
            foreach (DataGridViewRow R in dgvRecetas.Rows)
            {
                if (Convert.ToBoolean(R.Cells["Seleccionar"].Value) == true)
                {
                    idRecetasList.Add(Convert.ToInt32(R.Cells["N° Receta"].Value));
                }
            }

            int[] idRecetasArray = idRecetasList.ToArray();

            if (idRecetasArray.Length > 0) //Si la cantidad de filas seleccionadas (true) en el foreach es mayor a 0
            {
                dialogResult = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Desea grabar? (SI/NO)
            }
            else //Si no se selecciono (false) ninguna fila
            {
                MessageBox.Show("Debe seleccionar al menos una receta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dialogResult == DialogResult.Yes) //Si se selecciona SI, actualiza el estado de la receta
            {             
                com.ActualizarReceta_A_PoseeElMedico(idRecetasArray);

                if (idRecetasArray.Length > 1) //Si la cantidad de recetas seleccionadas es mayor a 1
                {
                    MessageBox.Show("Se han entregado " + idRecetasArray.Length + " recetas", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    ContadorDeRecetas();
                }
                else if (idRecetasArray.Length == 1)
                {
                    MessageBox.Show("Se ha entregado " + idRecetasArray.Length + " receta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    ContadorDeRecetas();
                }
            }
            ContadorDeRecetas();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = false;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 40;
                Font fontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
                Font fontSubTitulo = new Font("Segoe UI", 14, FontStyle.Regular);
                Font fontHeader = new Font("Segoe UI", 12, FontStyle.Bold);
                Font fontBody = new Font("Segoe UI", 12, FontStyle.Regular);
                String titulo = "Entregar Recetas registradas al medico";
                String subTitulo = "Imprime la lista de recetas entregadas al medico";

                int left = ep.MarginBounds.Left - 50, top = ep.MarginBounds.Top + 50;

                ep.Graphics.DrawImage(Properties.Resources.Logo_50_x_15, ep.MarginBounds.Right - 150, 60);
                //ep.Graphics.DrawImage(Properties.Resources.Logo_CDF_Blanco, ep.MarginBounds.Right - 150, 40);
                ep.Graphics.DrawString(titulo, fontTitulo, Brushes.DeepSkyBlue, left + 100, 60);
                ep.Graphics.DrawString(subTitulo, fontSubTitulo, Brushes.Black, left + 50, 50 + DGV_ALTO);


                foreach (DataGridViewColumn col in dgvRecetas.Columns)
                {
                    if (col.Index > 1)
                    {
                        ep.Graphics.DrawString(col.HeaderText, fontHeader, Brushes.DeepSkyBlue, left, top + 10);
                        left += col.Width;

                        if (col.Index < dgvRecetas.ColumnCount - 1)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dgvRecetas.RowCount) * DGV_ALTO);
                    }
                }
                left = ep.MarginBounds.Left - 50;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dgvRecetas.Rows)
                {
                    // if (row.Index == dgvRecetas.RowCount - 1) break;
                    if (dgvRecetas.RowCount == 0) break;
                    left = ep.MarginBounds.Left - 50;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //cell.ColumnIndex > 1
                        if (cell.ColumnIndex > 1)
                        {
                            ep.Graphics.DrawString(Convert.ToString(cell.Value), fontBody, Brushes.Black, new RectangleF(left, top + 6, cell.OwningColumn.Width - 4, cell.OwningRow.Height - 2));
                            left += cell.OwningColumn.Width;
                        }
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left - 50, top, ep.MarginBounds.Right, top);
                }
            };
            ppd.ShowDialog();
        }
    }
    
}
