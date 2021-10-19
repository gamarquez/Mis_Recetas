using MisRecetas.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Recetas.Controlador
{
    class CmdEntRecetaArchivada
    {
        public void ListarRecetasArchivadas(ref DataSet dataprincipal, string tabla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT R.Nro_Receta AS 'N° Receta', P.Nombre_Paciente + ' ' + P.Apellido_Paciente AS 'Paciente', P.Nro_Documento AS 'DNI', M.Nombre_Medico + ' ' + M.Apellido_Medico AS 'Medico', FORMAT(R.Fecha_Entrega_A_Archivo, 'dd/MM/yyyy') AS Fecha, E.Descripcion AS 'Estado' FROM Receta R, Medico M, Estado E, Paciente P WHERE R.Id_Medico = M.Id_Medico AND R.Id_Estado = E.Id_Estado AND R.Id_Paciente = P.Id_Paciente AND R.Id_Estado = 5";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dataprincipal, tabla);
            da.Dispose();
            con.Close();
        }

        public void EntregarRecetaArchivada(int Id, string nombreRetira, string parentezcoRetira)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Receta SET Id_Estado = 4, Id_Usuario_Entrega_A_Paciente = @usuario, Fecha_Usuario_Entrega_A_Paciente = GETDATE() , Nombre_Retira = @nombreRetira, Parentezco = @parentezcoRetira WHERE Nro_Receta = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("usuario", Usuario.Id_Usuario);
            comando.Parameters.AddWithValue("nombreRetira", nombreRetira);
            comando.Parameters.AddWithValue("parentezcoRetira", parentezcoRetira);
            comando.Parameters.AddWithValue("id", Id);
            comando.ExecuteNonQuery();
            con.Close();
        }
    }
}
