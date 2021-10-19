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
    public partial class FormReporteRecetasDesechadas : Form
    {
        public FormReporteRecetasDesechadas()
        {
            InitializeComponent();
        }

        private void FormReporteRecetasDesechadas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsRecetasDesechadas.Receta' Puede moverla o quitarla según sea necesario.
            this.recetaTableAdapter.verRecetasDesechadas(this.dsRecetasDesechadas.Receta);

            this.reportViewer1.RefreshReport();
        }
    }
}
