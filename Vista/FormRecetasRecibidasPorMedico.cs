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
    public partial class FormRecetasRecibidasPorMedico : Form
    {
        public FormRecetasRecibidasPorMedico()
        {
            InitializeComponent();
        }

        CmdReportes com = new CmdReportes();

        private void FormRecetasRecibidasPorMedico_Load(object sender, EventArgs e)
        {
            CargarComboMedicos();
        }

        private void CargarComboMedicos()
        {
            cboMedico.DataSource = com.CargarComboMedico();
            cboMedico.DisplayMember = "Medico";
            cboMedico.ValueMember = "Id_Medico";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idMed = (int)cboMedico.SelectedIndex + 1;
            // TODO: esta línea de código carga datos en la tabla 'dsRecetasRecibidasPorMedico.Receta' Puede moverla o quitarla según sea necesario.
            this.recetaTableAdapter.verRecetasRecibidasPorMedico(this.dsRecetasRecibidasPorMedico.Receta, idMed);
            this.reportViewer1.RefreshReport();
        }
    }
}
