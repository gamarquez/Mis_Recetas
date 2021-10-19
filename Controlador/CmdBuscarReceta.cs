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
    class CmdBuscarReceta
    {
        public void ListarRecetas(ref DataSet dataprincipal, string tabla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta AS 'N° Receta', P.Nombre_Paciente +' '+ P.Apellido_Paciente Paciente, P.Nro_Documento AS 'N° Documento', M.Nombre_Medico +' '+ M.Apellido_Medico Medico, E.Descripcion Estado FROM Receta R, Medico M, Paciente P, Estado E WHERE R.Id_Medico = M.Id_Medico and R.Id_Paciente = P.Id_Paciente and R.Id_Estado = E.Id_Estado";
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
            var query = "SELECT R.Nro_Receta 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', P.Nro_Documento AS 'N° Documento', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Nro_Receta = @nroReceta";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("nroReceta", Nro_Receta);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();         
        }

        public void BuscarRecetasPorNombre(DataGridView grilla, String nombre)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', p.Nro_Documento AS 'N° Documento', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Id_Paciente = P.Id_Paciente AND Nombre_Paciente LIKE @nombre + '%'";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();         
        }

        public void BuscarRecetasPorApellido(DataGridView grilla, String apellido)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', p.Nro_Documento AS 'N° Documento', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Id_Paciente = P.Id_Paciente AND Apellido_Paciente LIKE @apellido + '%'";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("apellido", apellido);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();          
        }

        public void BuscarRecetasPorDni(DataGridView grilla, String dni)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', p.Nro_Documento AS 'N° Documento', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Id_Paciente = P.Id_Paciente AND Nro_Documento LIKE @dni + '%'";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("dni", dni);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();           
        }
    }
}
