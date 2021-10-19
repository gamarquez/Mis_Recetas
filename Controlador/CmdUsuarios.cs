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
    class CmdUsuarios
    {
        public void CargarComboRol(ComboBox est)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Rol, Descripcion FROM Rol";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            est.DataSource = dt;
            con.Close();
        }

        public void ActualizarUsuario(String nombreUsuario, String password, int idRol, String nombre, String apellido, int id)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Usuario SET Nombre_Usuario = @nomUsuario, Password = @pass, Id_Rol = @idRol, Nombre = @nom, Apellido = @ape WHERE Id_Usuario = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@nomUsuario", nombreUsuario);
            comando.Parameters.AddWithValue("@pass", password);
            comando.Parameters.AddWithValue("@idRol", idRol);
            comando.Parameters.AddWithValue("@nom", nombre);
            comando.Parameters.AddWithValue("@ape", apellido);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public void CargarUsuarios(DataGridView grilla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Usuario AS 'ID', Nombre AS 'Nombre', Apellido AS 'Apellido', R.Descripcion AS 'Rol', Nombre_Usuario AS 'Username', Password AS 'Password' FROM Usuario U, Rol R WHERE U.Id_Rol = R.Id_Rol";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();
        }

        public void RegistrarUsuario(String nombreUsuario, String password, int idRol, String nombre, String apellido)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "INSERT INTO Usuario (Nombre_Usuario, Password, Id_Rol, Nombre, Apellido) VALUES (@nomUsuario, @pass, @idRol, @nom, @ape)";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@nomUsuario", nombreUsuario);
            comando.Parameters.AddWithValue("@pass", password);
            comando.Parameters.AddWithValue("@idRol", idRol);
            comando.Parameters.AddWithValue("@nom", nombre);
            comando.Parameters.AddWithValue("@ape", apellido);
            comando.ExecuteNonQuery();
            con.Close();
        }
    }
}
