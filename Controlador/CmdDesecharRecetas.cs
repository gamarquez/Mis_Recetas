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
    class CmdDesecharRecetas
    {
        public void ListarRecetasDesechar(DataGridView grilla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta AS 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', P.Nro_Documento AS 'N° Documento', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', FORMAT(R.Fecha_Entrega_A_Archivo, 'dd/MM/yyyy') AS Fecha, E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Id_Estado = 5 ORDER BY  R.Fecha_Entrega_A_Archivo DESC";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grilla.DataSource = dt;
            con.Close();
        }
        public void DesecharRecetas(int[] idRecetasArray)
        {
            foreach (int id in idRecetasArray)
            {
                SqlConnection con = new SqlConnection(Conexion.Cn);
                con.Open();
                var query = "UPDATE Receta SET Id_Estado = 6, Id_Usuario_Desecha = @usuario, Fecha_Usuario_Desecha = GETDATE() WHERE Nro_Receta = @id";
                var comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("usuario", Usuario.Id_Usuario);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
