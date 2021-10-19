using MisRecetas.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Recetas.Controlador
{
    class CmdLogin
    {
        public bool Login(string user, string pass)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT Id_Usuario, Nombre_Usuario, Password, U.Id_Rol, R.Descripcion ,Nombre, Apellido FROM Usuario U, Rol R WHERE U.Id_Rol=R.Id_Rol AND Nombre_Usuario = @user and Password = @pass";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@user", user);
            comando.Parameters.AddWithValue("@pass", pass);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario.Id_Usuario = reader.GetInt32(0);
                    Usuario.Nombre_Usuario = reader.GetString(1);
                    Usuario.Password = reader.GetString(2);
                    Usuario.Id_Rol = reader.GetInt32(3);
                    Usuario.Rol = reader.GetString(4);
                    Usuario.Nombre = reader.GetString(5);
                    Usuario.Apellido = reader.GetString(6);
                }
                return true;
            }
            else
                return false;
        }
    }
}
