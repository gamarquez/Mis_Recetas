using MisRecetas.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mis_Recetas.Controlador
{
    class CmdRecRecetaMedico
    {
        public DataTable CargarComboMedico()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CargarComboBoxMedicos", Conexion.Cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ListarRecetasPorMedicoEstado2(int id, DataGridView grilla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT r.Nro_Receta AS 'N° Receta', p.Nombre_Paciente +' '+ p.Apellido_Paciente Paciente, p.Nro_Documento AS 'N° Documento', m.Nombre_Medico +' '+ m.Apellido_Medico Medico, e.Descripcion Estado, p.Email FROM Receta r, Medico m, Paciente p, Estado e WHERE r.Id_Medico = m.Id_Medico and r.Id_Paciente = p.Id_Paciente and r.Id_Estado = e.Id_Estado and e.Id_Estado = 2 and m.Id_Medico = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("id", id);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();
        }


        public void ActualizarReceta_A_ListaParaEntregar(int[] idRecetasArray)
        {
            foreach (int id in idRecetasArray)
            {
                SqlConnection con = new SqlConnection(Conexion.Cn);
                con.Open();
                var query = "UPDATE Receta SET Id_Estado = 3, Id_Usuario_Recibe_De_Medico = @usuario, Fecha_Usuario_Recibe_De_Medico = GETDATE() WHERE Nro_Receta = @id";
                var comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("usuario", Usuario.Id_Usuario);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
