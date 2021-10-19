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
    public partial class FormRecetasPorEstado : Form
    {
        public FormRecetasPorEstado()
        {
            InitializeComponent();
        }

        CmdReportes com = new CmdReportes();

        private void FormRecetasPorEstado_Load(object sender, EventArgs e)
        {
            
            cargarComboEstados();
            
        }

        private void cargarComboEstados()
        {
            com.CargarComboEstado(cboEstado);
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.ValueMember = "Id_Estado";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int estado = (int)cboEstado.SelectedIndex + 1;
            // TODO: esta línea de código carga datos en la tabla 'dsRecetasPorEstado.Receta' Puede moverla o quitarla según sea necesario.
            this.recetaTableAdapter.verRecetasPorEstado(this.dsRecetasPorEstado.Receta, estado);
            this.reportViewer1.RefreshReport();
        }
    }
}
