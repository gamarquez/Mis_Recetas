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
    public partial class FormListadoReportes : Form
    {
        public FormListadoReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReporteTicket rt = new FormReporteTicket();
            rt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReporteRecArchivadas ra = new FormReporteRecArchivadas();
            ra.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRecetasPorEstado rpe = new FormRecetasPorEstado();
            rpe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormReporteRecPorFechas rpf = new FormReporteRecPorFechas();
            rpf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormRecetasEntregadasPorMedico repm = new FormRecetasEntregadasPorMedico();
            repm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormRecetasRecibidasPorMedico rrpm = new FormRecetasRecibidasPorMedico();
            rrpm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormReporteRecetasDesechadas rrd = new FormReporteRecetasDesechadas();
            rrd.Show();
        }
    }
}
