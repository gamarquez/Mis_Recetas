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
    public partial class FormEntRecetaArchivada : Form
    {
        public FormEntRecetaArchivada()
        {
            InitializeComponent();
        }

        CmdEntRecetaArchivada com = new CmdEntRecetaArchivada();

        private void FormEntRecetaArchivada_Load(object sender, EventArgs e)
        {
            actulizarDataGrid();

            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = " ";
            chek.Name = "Seleccionar";
            chek.DisplayIndex = 0;
            chek.ReadOnly = false;
            dgvRecetasArchivadas.Columns.Add(chek);

            dgvRecetasArchivadas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns["Seleccionar"].Width = 25;
            dgvRecetasArchivadas.Columns[0].Width = 40;
            dgvRecetasArchivadas.Columns[1].Width = 150;
            dgvRecetasArchivadas.Columns[2].Width = 120;
            dgvRecetasArchivadas.Columns[3].Width = 150;
            dgvRecetasArchivadas.Columns[4].Width = 70;
            dgvRecetasArchivadas.Columns[5].Width = 120;

            dgvRecetasArchivadas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetasArchivadas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvRecetasArchivadas.Columns[0].ReadOnly = true;
            dgvRecetasArchivadas.Columns[1].ReadOnly = true;
            dgvRecetasArchivadas.Columns[2].ReadOnly = true;
            dgvRecetasArchivadas.Columns[3].ReadOnly = true;
            dgvRecetasArchivadas.Columns[4].ReadOnly = true;
            dgvRecetasArchivadas.Columns[5].ReadOnly = true;
            dgvRecetasArchivadas.RowHeadersVisible = false;

            txtRetira.Enabled = false;
            txtParentezco.Enabled = false;
            btnEntregar.Enabled = false;

            dgvRecetasArchivadas.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvRecetasArchivadas.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        //Actualiza el datagridview con consulta en la DB
        DataSet resultados = new DataSet();
        DataView filtro;
        private void actulizarDataGrid()
        {
            resultados.Reset();
            com.ListarRecetasArchivadas(ref resultados, "recetas");
            filtro = ((DataTable)resultados.Tables["recetas"]).DefaultView;
            dgvRecetasArchivadas.DataSource = filtro;
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

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            filtroNombreDataGrid();
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
            foreach (DataGridViewRow Row in dgvRecetasArchivadas.Rows)
            {
                if (Row.Index != rowSelect)
                {
                    ((DataGridViewCheckBoxCell)Row.Cells["Seleccionar"]).Value = false;
                }
            }
        }

        private void dgvRecetasArchivadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarNoSeleccionado(e.RowIndex);
            dgvRecetasArchivadas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvRecetasArchivadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            habilitarTxtRetira();
        }

        private void habilitarTxtRetira()
        {
            txtRetira.Enabled = false;
            foreach (DataGridViewRow Row in dgvRecetasArchivadas.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["Seleccionar"].Value) == true)
                {
                    txtRetira.Enabled = true;
                }
            }
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

            foreach (DataGridViewRow Row in dgvRecetasArchivadas.Rows)
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
                com.EntregarRecetaArchivada(idRecetaRetiraPte, txtRetira.Text, txtParentezco.Text);
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = false;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                Font fontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
                Font fontSubTitulo = new Font("Segoe UI", 14, FontStyle.Regular);
                Font fontHeader = new Font("Segoe UI", 12, FontStyle.Bold);
                Font fontBody = new Font("Segoe UI", 12, FontStyle.Regular);
                String titulo = "Entregar Receta a Paciente";
                String subTitulo = "Imprime la receta que se entrega al paciente";

                int left = ep.MarginBounds.Left - 50, top = ep.MarginBounds.Top + 50;

                 ep.Graphics.DrawImage(Properties.Resources.Logo_50_x_15, ep.MarginBounds.Right - 150, 60);
                //ep.Graphics.DrawImage(Properties.Resources.Logo_CDF_Blanco, ep.MarginBounds.Right - 150, 40);
                ep.Graphics.DrawString(titulo, fontTitulo, Brushes.DeepSkyBlue, left + 100, 60);
                ep.Graphics.DrawString(subTitulo, fontSubTitulo, Brushes.Black, left + 50, 50 + DGV_ALTO);


                foreach (DataGridViewColumn col in dgvRecetasArchivadas.Columns)
                {
                    if (col.Index > 1)
                    {
                        ep.Graphics.DrawString(col.HeaderText, fontHeader, Brushes.DeepSkyBlue, left, top + 10);
                        left += col.Width;

                        if (col.Index < dgvRecetasArchivadas.ColumnCount - 1)
                            ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dgvRecetasArchivadas.RowCount - 1) * DGV_ALTO);
                    }
                }
                left = ep.MarginBounds.Left - 50;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dgvRecetasArchivadas.Rows)
                {
                    if (row.Index == dgvRecetasArchivadas.RowCount - 1) break;
                    left = ep.MarginBounds.Left - 50;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex > 1)
                        {
                            ep.Graphics.DrawString(Convert.ToString(cell.Value), fontBody, Brushes.Black, new RectangleF(left, top + 4, cell.OwningColumn.Width - 3, cell.OwningRow.Height));
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
