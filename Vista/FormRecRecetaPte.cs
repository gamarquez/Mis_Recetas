using Mis_Recetas.Controlador;
using Mis_Recetas.Crystal;
using MisRecetas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Vista
{
    public partial class FormRecRecetaPte : Form
    {
        public FormRecRecetaPte()
        {
            InitializeComponent();
        }

        CmdRecRecetaPte com = new CmdRecRecetaPte();


        static string user = ConfigurationManager.AppSettings["UsuarioTickets"];
        static string pass = ConfigurationManager.AppSettings["PassTickets"];
        static string server = ConfigurationManager.AppSettings["ServidorTickets"];
        static string db = ConfigurationManager.AppSettings["DBTickets"];
        static string printer = ConfigurationManager.AppSettings["Impresora"];

        private void FormRecRecetaPte_Load(object sender, EventArgs e)
        {
            CargarComboMedicos();
            CargarComboTipoDocumentos();

            seccionBuscarPaciente.Enabled = true;
            seccionRegistrar.Enabled = false;
            seccionNuevoPaciente.Enabled = false;
        }

        private void CargarComboMedicos()
        {

            cboMedico.DataSource = com.CargarComboMedico();
            cboMedico.DisplayMember = "Medico";
            cboMedico.ValueMember = "Id_Medico";
        }

        private void CargarComboTipoDocumentos()
        {

            cboTipoDocumento.DataSource = com.CargarComboTipoDocumento();
            cboTipoDocumento.DisplayMember = "Descripcion";
            cboTipoDocumento.ValueMember = "Id_TipoDocumento";

            cboTipoDocumento2.DataSource = com.CargarComboTipoDocumento();
            cboTipoDocumento2.DisplayMember = "Descripcion";
            cboTipoDocumento2.ValueMember = "Id_TipoDocumento";
        }

        //------------------------------------BUSCAR PACIENTES POR DNI-----------------------------------------------------------------------
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (txtNroDocumento.Text == "") //VALIDACION
            {
                MessageBox.Show("Debe ingresar al menos un numero ", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNroDocumento.Focus();
            }
            else
            {
                int tipoDni = (int)cboTipoDocumento.SelectedValue;
                String documento = txtNroDocumento.Text;

                com.BuscarPacientePorDni(tipoDni, documento, dgvPacientes);
                dgvPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPacientes.Columns[0].Width = 40;
                dgvPacientes.Columns[1].Width = 90;
                dgvPacientes.Columns[2].Width = 80;
                dgvPacientes.Columns[3].Width = 50;
                dgvPacientes.Columns[4].Width = 80;
                dgvPacientes.Columns[5].Width = 150;

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
        }
        //-------------------------------------------------------------------------------------------------------------------------------------


        //-----------------MOSTRAMOS EL PACIENTE SELECCIONADO DEL DataGridView EN LA SECCION REGISTRAR RECETA----------------------------------
        int idPaciente;
        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        private void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            txtNroDocumento2.Clear();
            dgvPacientes.ClearSelection();
            txtEmail.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            bool nuevaRec = false;

            if (nuevaRec == false)
            {
                dialogResult = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (dialogResult == DialogResult.Yes)
            {
                Receta r = new Receta();

                string tipoDni = lblTipoDoc.Text;
                int nroDocumento = Convert.ToInt32(lblNroDoc.Text);
                int idPaciente = com.BuscarIdPaciente(tipoDni, nroDocumento);
                int nroReceta = com.UltimoNroReceta() + 1; //Busca el ultimo nro receta y le suma 1
                int idMedico = (int)cboMedico.SelectedIndex + 1; //Hacer un  swich  id de cada medico
                int idEstado = 1; //Estado 1: recibido del paciente

                r.Nro_Receta = nroReceta;
                r.Id_Paciente = idPaciente;
                r.Id_Medico = idMedico;
                r.Id_Estado = idEstado;

                bool nuevaReceta = com.RegistrarReceta(r);

                if (nuevaReceta)
                {
                    MessageBox.Show("Receta registrada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    seccionRegistrar.Enabled = false;
                    limpiar();
                    lblNom.Text = "-";
                    lblApe.Text = "-";
                    lblNroDoc.Text = "-";
                    lblTipoDoc.Text = "-";
                    lblEmail.Text = "-";

                    // ACA VA EL REPORTE
                    FormReporteTicket rt = new FormReporteTicket();
                    rt.Show();
                }
                else
                {
                    MessageBox.Show("Fallo al registrar la receta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            seccionRegistrar.Enabled = false;
            seccionBuscarPaciente.Enabled = true;
            seccionNuevoPaciente.Enabled = true;
            limpiar();
            lblNom.Text = "-";
            lblApe.Text = "-";
            lblNroDoc.Text = "-";
            lblTipoDoc.Text = "-";
            lblEmail.Text = "-";
        }

        private void btnCargarPaciente_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = DialogResult.No;
            bool nuevoPac = false;

            if (nuevoPac == false)
            {
                dialogResult = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (dialogResult == DialogResult.Yes)
            {
                Paciente p = new Paciente();
                p.Id_TipoDocumento = (int)cboTipoDocumento2.SelectedValue;
                p.Nro_Documento = txtNroDocumento2.Text;
                p.Nombre_Paciente = txtNombre.Text;
                p.Apellido_Paciente = txtApellido.Text;
                p.Email = txtEmail.Text;

                bool nuevo = com.NuevoPaciente(p);

                if (nuevo)
                {
                    MessageBox.Show("Paciente cargado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    seccionRegistrar.Enabled = true;

                    lblNom.Text = p.Nombre_Paciente;
                    lblApe.Text = p.Apellido_Paciente;
                    lblNroDoc.Text = p.Nro_Documento;
                    lblEmail.Text = p.Email;
                    int tipo = p.Id_TipoDocumento;
                    switch (tipo)
                    {
                        case 1:
                            lblTipoDoc.Text = "DNI";
                            break;
                        case 2:
                            lblTipoDoc.Text = "LC";
                            break;
                        case 3:
                            lblTipoDoc.Text = "LE";
                            break;
                        case 4:
                            lblTipoDoc.Text = "OTRO";
                            break;
                    }
                    limpiar();
                    seccionNuevoPaciente.Enabled = false;
                    btnRegistrar.Focus();
                }
                else
                {
                    MessageBox.Show("Fallo al cargar el paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tipoDni = (int)cboTipoDocumento.SelectedValue;
            switch (tipoDni)
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

        private void txtNroDocumento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tipo_Dni = (int)cboTipoDocumento2.SelectedValue;
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

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombre = dgvPacientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            String apellido = dgvPacientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            String tipoDoc = dgvPacientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            String nroDoc = dgvPacientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            String email = dgvPacientes.Rows[e.RowIndex].Cells[5].Value.ToString();

            lblNom.Text = nombre;
            lblApe.Text = apellido;
            lblTipoDoc.Text = tipoDoc;
            lblNroDoc.Text = nroDoc;
            lblEmail.Text = email;
            idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString());

            seccionRegistrar.Enabled = true;
            seccionNuevoPaciente.Enabled = false;
        }
    }
}

