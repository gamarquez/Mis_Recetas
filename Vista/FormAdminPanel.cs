﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Vista
{
    public partial class FormAdminPanel : Form
    {
        public FormAdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAltaMedico_Click(object sender, EventArgs e)
        {
            FormRegistrarMedico rm = new FormRegistrarMedico();
            rm.Show();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnModificarMedico_Click(object sender, EventArgs e)
        {
            FormModificarMedico mm = new FormModificarMedico();
            mm.Show();
        }

        private void btnModificarReceta_Click(object sender, EventArgs e)
        {
            FormModificarReceta mr = new FormModificarReceta();
            mr.Show();
        }

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            FormListadoReportes lr = new FormListadoReportes();
            lr.Show();
        }

        private void btnModPaciente_Click(object sender, EventArgs e)
        {
            FormModificarPaciente modPac = new FormModificarPaciente();
            modPac.Show();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            FormRegistrarUsuario ru = new FormRegistrarUsuario();
            ru.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormModificarUsuario mu = new FormModificarUsuario();
            mu.Show();
        }
    }
}
