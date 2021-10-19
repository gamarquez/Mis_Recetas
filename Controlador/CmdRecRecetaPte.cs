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
    class CmdRecRecetaPte
    {
        public DataTable CargarComboMedico()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CargarComboBoxMedicos", Conexion.Cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboTipoDocumento()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CargarComboBoxTipoDocumento", Conexion.Cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void BuscarPacientePorDni(int tipoDni, String nroDocumento, DataGridView grilla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT p.Id_Paciente AS ID, p.Nombre_Paciente AS Nombre, p.Apellido_Paciente AS Apellido, t.Descripcion AS 'Tipo Documento', p.Nro_Documento AS 'N° Documento', p.Email AS 'E-mail' FROM Paciente p JOIN Tipo_Documento t ON p.id_tipodocumento = t.id_tipodocumento WHERE p.Id_TipoDocumento = @tipoDni AND p.Nro_Documento LIKE @nroDni + '%'";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("tipoDni", tipoDni);
            comando.Parameters.AddWithValue("nroDni", nroDocumento);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();
        }

        public int BuscarIdPaciente(string tipoDni, int nroDocumento)
        {
            int id = 0;
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT p.Id_Paciente FROM Paciente p JOIN Tipo_Documento t ON p.id_tipodocumento = t.id_tipodocumento WHERE t.Descripcion = @tipoDni and p.Nro_Documento = @nroDni";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("tipoDni", tipoDni);
            comando.Parameters.AddWithValue("nroDni", nroDocumento);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            id = (int)dt.Rows[0][0];
            con.Close();
            return id;
        }

        public bool RegistrarReceta(Receta r)
        {
            bool nueva = false;

            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "INSERT INTO Receta (Nro_Receta, Id_Paciente, Id_Medico, Id_Estado, Id_Usuario_Registra, Fecha_Usuario_Registra) VALUES (@nroReceta, @idPaciente, @idMedico, @idEstado, @idUsuarioRegistra, GETDATE())";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("nroReceta", r.Nro_Receta);
            comando.Parameters.AddWithValue("idPaciente", r.Id_Paciente);
            comando.Parameters.AddWithValue("idMedico", r.Id_Medico);
            comando.Parameters.AddWithValue("idEstado", r.Id_Estado);
            comando.Parameters.AddWithValue("idUsuarioRegistra", Usuario.Id_Usuario);
            comando.ExecuteNonQuery();
            con.Close();
            nueva = true;
            return nueva;
        }

        public int UltimoNroReceta()
        {
            int nroReceta = 0;

            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT TOP 1 Nro_Receta FROM Receta ORDER BY Nro_Receta DESC";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //if (dt.Rows[0][0] != null)
            //{
            //    nroReceta = (int)dt.Rows[0][0];
            //}
            if(dt.Rows.Count > 0)
            {
                nroReceta = (int)dt.Rows[0][0];
            }
            else
            {
                nroReceta = 0;
            }

            con.Close();
            return nroReceta;
        }

        public bool NuevoPaciente(Paciente p)
        {
            bool nuevo = false;

            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "INSERT INTO Paciente VALUES (@idTipoDocumento, + @nroDocumento, @nombrePaciente, @apellidoPaciente, @email)";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("idTipoDocumento", p.Id_TipoDocumento);
            comando.Parameters.AddWithValue("nroDocumento", p.Nro_Documento);
            comando.Parameters.AddWithValue("nombrePaciente", p.Nombre_Paciente);
            comando.Parameters.AddWithValue("apellidoPaciente", p.Apellido_Paciente);
            comando.Parameters.AddWithValue("email", p.Email);
            comando.ExecuteNonQuery();
            con.Close();
            nuevo = true;
            return nuevo;
        }
    }
}
