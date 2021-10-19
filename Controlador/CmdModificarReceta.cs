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
    class CmdModificarReceta
    {
        public DataTable CargarComboMedico()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CargarComboBoxMedicos", Conexion.Cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void CargarComboEstado(ComboBox est)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Estado, Descripcion FROM Estado";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            est.DataSource = dt;
            con.Close();
        }

        public void ListarRecetas(ref DataSet dataprincipal, string tabla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta AS 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', P.Nro_Documento AS 'DNI', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dataprincipal, tabla);
            da.Dispose();
            con.Close();
        }

        public void BuscarRecetasPorNumero(DataGridView grilla, int Nro_Receta)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', P.Nro_Documento AS 'DNI', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Nro_Receta = @nroReceta";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("nroReceta", Nro_Receta);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();
        }

        public void ModificarMedicoReceta(int id, int idMedico)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Receta SET Id_Medico = @idMed WHERE Nro_Receta = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("id", id);
            comando.Parameters.AddWithValue("idMed", idMedico);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public void ModificarEstadoReceta(int id, int idEstado)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Receta SET Id_Estado = @idEst WHERE Nro_Receta = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("id", id);
            comando.Parameters.AddWithValue("idEst", idEstado);
            comando.ExecuteNonQuery();
            con.Close();
        }
    }
}
