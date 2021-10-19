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
    class CmdMedicos
    {
        public void RegistrarMedico(Medico med)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "INSERT INTO Medico (Nombre_Medico, Apellido_Medico, Nro_Matricula) VALUES (@nombre, @apellido, @nro_matricula)";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("nombre", med.Nombre_Medico);
            comando.Parameters.AddWithValue("apellido", med.Apellido_Medico);
            comando.Parameters.AddWithValue("nro_matricula", med.Nro_Matricula);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public void CargarMedicos(DataGridView grilla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Medico AS 'ID', Nro_Matricula AS 'Matricula', Nombre_Medico AS 'Nombre', Apellido_Medico 'Apellido' FROM Medico";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();    
        }

        public void ActualizarMedico(String matricula, String nombreMedico, String apellidoMedico, int id)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Medico SET Nro_Matricula = @nromatricula, Nombre_Medico=@nomMedico, Apellido_Medico=@apeMedico WHERE Id_Medico = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@nromatricula", matricula);
            comando.Parameters.AddWithValue("@nomMedico", nombreMedico);
            comando.Parameters.AddWithValue("@apeMedico", apellidoMedico);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            con.Close();             
        }
    }
}
