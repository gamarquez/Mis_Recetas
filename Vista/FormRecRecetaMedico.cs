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
    public partial class FormRecRecetaMedico : Form
    {
        public FormRecRecetaMedico()
        {
            InitializeComponent();
        }

        CmdRecRecetaMedico com = new CmdRecRecetaMedico();

        private void FormRecRecetaMedico_Load(object sender, EventArgs e)
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
            dgvRecetas.Columns[5].Width = 130;

            dgvRecetas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecetas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRecetas.Columns[0].ReadOnly = true;
            dgvRecetas.Columns[1].ReadOnly = true;
            dgvRecetas.Columns[2].ReadOnly = true;
            dgvRecetas.Columns[3].ReadOnly = true;
            dgvRecetas.Columns[4].ReadOnly = true;
            dgvRecetas.Columns[5].Visible = false;
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

        private void actulizarDataGrid()
        {
            int id = (int)cboMedico.SelectedValue;
            com.ListarRecetasPorMedicoEstado2(id, dgvRecetas);
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ActivarDesactivarCheck(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            List<int> idRecetasList = new List<int>();
            List<string> correos = new List<string>();

            DialogResult dialogResult = DialogResult.No;

            foreach (DataGridViewRow R in dgvRecetas.Rows)
            {
                if (Convert.ToBoolean(R.Cells["Seleccionar"].Value) == true)
                {
                    idRecetasList.Add(Convert.ToInt32(R.Cells["N° Receta"].Value));
                    correos.Add(Convert.ToString(R.Cells["Email"].Value));
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
                com.ActualizarReceta_A_ListaParaEntregar(idRecetasArray);
                enviarMails(correos);

                if (idRecetasArray.Length > 1) //Si la cantidad de recetas seleccionadas es mayor a 1
                {
                    MessageBox.Show("Se han recibido " + idRecetasArray.Length + " recetas", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    ContadorDeRecetas();
                }
                else if (idRecetasArray.Length == 1)
                {
                    MessageBox.Show("Se ha recibido " + idRecetasArray.Length + " receta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    actulizarDataGrid();
                    ContadorDeRecetas();
                }
            }
            ContadorDeRecetas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            actulizarDataGrid();
            ContadorDeRecetas();
        }

        protected void enviarMails(List<string> correos)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress("facujaamaya14@gmail.com");
            correo.Subject = "Receta";
            correo.Body = string.Format("¡Su receta esta lista para ser retirada!",Environment.NewLine,"atte.: CLÍNICA DEÁN FUNES");
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("facujaamaya14@gmail.com", "saulhudson");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            try
            {
                foreach (var mail in correos)
                {

                    //agregar destinatario del correo
                    correo.To.Add(mail);
                    //enviar el correo     
                    smtp.Send(correo.From.Address, mail, correo.Subject, correo.Body);
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
