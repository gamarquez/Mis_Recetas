using Mis_Recetas.Modelo;
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

        public DataTable TraerDatosReceta(int nro_receta)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Conexion.Cn);
                con.Open();
                var query = "SELECT u1.Nombre_Usuario as 'Usuario_Registra', r.Fecha_Usuario_Registra, u2.Nombre_Usuario as 'Usu_Ent_Medico', r.Fecha_Usuario_Entrega_A_Medico, u3.Nombre_Usuario as 'Usu_Rec_Med', r.Fecha_Usuario_Recibe_De_Medico, " +
                    " u4.Nombre_Usuario as 'Usu_Ent_Pac', r.Fecha_Usuario_Entrega_A_Paciente " +
                    " FROM Receta r LEFT JOIN Usuario u1 ON r.Id_Usuario_Registra = u1.Id_Usuario LEFT JOIN Usuario u2 ON r.Id_Usuario_Entrega_A_Medico = u2.Id_Usuario LEFT JOIN Usuario u3 ON r.Id_Usuario_Recibe_De_Medico = u3.Id_Usuario " +
                    " LEFT JOIN Usuario u4 ON r.Id_Usuario_Entrega_A_Paciente = u4.Id_Usuario WHERE r.Nro_Receta = @nro_receta ";
                var comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("nro_receta", nro_receta);

                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);

                //if(dt != null)
                //{
                //    receta.Usuario_Registra = dt.Rows[0]["Usuario_Registra"].ToString();
                //    receta.Fecha_Usuario_Registra = Convert.ToDateTime(dt.Rows[0]["Fecha_Usuario_Registra"].ToString());
                //    receta.Usuario_Entrega_Medico = dt.Rows[0]["Usu_Ent_Medico"].ToString();
                //    receta.Fecha_Entrega_Medico = Convert.ToDateTime(dt.Rows[0]["Fecha_Usuario_Entrega_A_Medico"].ToString());
                //    receta.Usuario_Recibe_Medico = dt.Rows[0]["Usu_Rec_Med"].ToString();
                //    receta.Fecha_Usuario_Recibe_Medico = Convert.ToDateTime(dt.Rows[0]["Fecha_Usuario_Recibe_De_Medico"].ToString());
                //    receta.Usuario_Entrega_Paciente = dt.Rows[0]["Usu_Ent_Pac"].ToString();
                //    receta.Fecha_Usuario_Entrega_Paciente = Convert.ToDateTime(dt.Rows[0]["Fecha_Usuario_Entrega_A_Paciente"].ToString());
                //}

                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
