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
    public partial class FormBuscarRecetaAdmin : Form
    {
        public FormBuscarRecetaAdmin()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtNumeroReceta.Text.Length < 0)
            {
                MessageBox.Show("Ingrese un numero de receta", "Error");
            }
            else
            {
                CmdModificarReceta mod_rec = new CmdModificarReceta();
                DataTable dt = new DataTable();

                dt = mod_rec.TraerDatosReceta(Convert.ToInt32(txtNumeroReceta.Text));

                dgvRecetas.DataSource = dt;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
