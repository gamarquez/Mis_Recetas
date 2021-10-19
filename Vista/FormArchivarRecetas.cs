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
    public partial class FormArchivarRecetas : Form
    {
        public FormArchivarRecetas()
        {
            InitializeComponent();
        }

        CmdArchivarRecetas com = new CmdArchivarRecetas();

        private void FormArchivarRecetas_Load(object sender, EventArgs e)
        {
            actulizarDataGrid();

            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = " ";
            chek.Name = "Seleccionar";
            chek.DisplayIndex = 0;
            chek.ReadOnly = false;

            dgvRecetasArchivar.Columns.Add(chek);

            dgvRecetasArchivar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns["Seleccionar"].Width = 25;
            dgvRecetasArchivar.Columns[0].Width = 50;
            dgvRecetasArchivar.Columns[1].Width = 150;
            dgvRecetasArchivar.Columns[2].Width = 120;
            dgvRecetasArchivar.Columns[3].Width = 150;
            dgvRecetasArchivar.Columns[4].Width = 70;
            dgvRecetasArchivar.Columns[5].Width = 150;

            dgvRecetasArchivar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivar.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRecetasArchivar.Columns[0].ReadOnly = true;
            dgvRecetasArchivar.Columns[1].ReadOnly = true;
            dgvRecetasArchivar.Columns[2].ReadOnly = true;
            dgvRecetasArchivar.Columns[3].ReadOnly = true;
            dgvRecetasArchivar.Columns[4].ReadOnly = true;
            dgvRecetasArchivar.Columns[5].ReadOnly = true;
            dgvRecetasArchivar.RowHeadersVisible = false;

            dgvRecetasArchivar.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvRecetasArchivar.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            ActivarDesactivarCheck(false);
            lblCant.Text = Convert.ToString(contarItemSelect());
        }

        private void actulizarDataGrid()
        {
            com.listarRecetasArchivar(dgvRecetasArchivar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActivarDesactivarCheck(bool vBool)
        {
            foreach (DataGridViewRow row in dgvRecetasArchivar.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Seleccionar"];
                chk.Value = vBool;
                dgvRecetasArchivar.RefreshEdit();
            }
        }

        private int contarItemSelect()
        {
            int cantSelect = 0;

            if (dgvRecetasArchivar.Rows.Count != 0)
            {
                foreach (DataGridViewRow R in dgvRecetasArchivar.Rows)
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

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCheck(true);
        }

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

        private void btnArchivar_Click(object sender, EventArgs e)
        {
            List<int> idRecetasList = new List<int>();

            DialogResult dialogResult = DialogResult.No;

            foreach (DataGridViewRow R in dgvRecetasArchivar.Rows)
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
                com.archivarRecetas(idRecetasArray);

                if (idRecetasArray.Length > 1) //Si la cantidad de recetas seleccionadas es mayor a 1
                {
                    MessageBox.Show("Se han archivado " + idRecetasArray.Length + " recetas", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    lblCant.Text = Convert.ToString(contarItemSelect());
                }
                else if (idRecetasArray.Length == 1)
                {
                    MessageBox.Show("Se ha archivado " + idRecetasArray.Length + " receta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    lblCant.Text = Convert.ToString(contarItemSelect());
                }
            }
            lblCant.Text = Convert.ToString(contarItemSelect());
        }

        private void dgvRecetasArchivar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRecetasArchivar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvRecetasArchivar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecetasArchivar.DataSource != null)
            {
                lblCant.Text = Convert.ToString(contarItemSelect());
            }
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
                String titulo = "Enviar recetas al archivo";
                String subTitulo = "Imprime la lista de recetas llevadas al archivo";

                int left = ep.MarginBounds.Left - 50, top = ep.MarginBounds.Top + 50;

                ep.Graphics.DrawImage(Properties.Resources.Logo_50_x_15, ep.MarginBounds.Right - 150, 40);
                //ep.Graphics.DrawImage(Properties.Resources.Logo_CDF_Blanco, ep.MarginBounds.Right - 150, 40);
                ep.Graphics.DrawString(titulo, fontTitulo, Brushes.DeepSkyBlue, left + 100, 60);
                ep.Graphics.DrawString(subTitulo, fontSubTitulo, Brushes.Black, left + 50, 50 + DGV_ALTO);


                foreach (DataGridViewColumn col in dgvRecetasArchivar.Columns)
                {
                    if (col.Index > 1)
                    {
                        ep.Graphics.DrawString(col.HeaderText, fontHeader, Brushes.DeepSkyBlue, left, top + 10);
                        left += col.Width;

                        if (col.Index < dgvRecetasArchivar.ColumnCount - 1)
                            ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dgvRecetasArchivar.RowCount) * DGV_ALTO);
                    }
                }
                left = ep.MarginBounds.Left - 50;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dgvRecetasArchivar.Rows)
                {
                    // if (row.Index == dgvRecetas.RowCount - 1) break;
                    if (dgvRecetasArchivar.RowCount == 0) break;
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
