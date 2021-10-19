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
    class CmdModificarPaciente
    {
        public void CargarPacientes(ref DataSet dataprincipal, string tabla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Paciente AS 'ID', Nombre_Paciente AS 'Nombre', Apellido_Paciente AS 'Apellido', TD.Descripcion AS 'Tipo Documento', Nro_Documento AS 'DNI', Email AS 'E-mail' FROM Paciente P, Tipo_Documento TD WHERE P.Id_TipoDocumento = TD.Id_TipoDocumento";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dataprincipal, tabla);
            da.Dispose();
            con.Close();
        }

        public void ActualizarPaciente(String nombre, String apellido, int idTipoDoc, String numDocumento, String email, int id)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Paciente SET Nombre_Paciente = @nomPaciente, Apellido_Paciente = @apePaciente, Id_TipoDocumento = @tipoDoc, Nro_Documento = @numDoc, Email = @email WHERE Id_Paciente = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@nomPaciente", nombre);
            comando.Parameters.AddWithValue("@apePaciente", apellido);
            comando.Parameters.AddWithValue("@tipoDoc", idTipoDoc);
            comando.Parameters.AddWithValue("@numDoc", numDocumento);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public DataTable CargarComboTipoDocumento()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CargarComboBoxTipoDocumento", Conexion.Cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
