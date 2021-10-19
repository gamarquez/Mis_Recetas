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
    class CmdEntRecetaPte
    {
        public void ListarRecetasListas(ref DataSet dataprincipal, string tabla)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "SELECT r.Nro_Receta AS 'N° Receta', p.Nombre_Paciente +' '+ p.Apellido_Paciente Paciente, p.Nro_Documento AS 'DNI', m.Nombre_Medico +' '+ m.Apellido_Medico Medico, e.Descripcion Estado FROM Receta r, Medico m, Paciente p, Estado e WHERE r.Id_Medico = m.Id_Medico and r.Id_Paciente = p.Id_Paciente and r.Id_Estado = e.Id_Estado and e.Id_Estado = 3";
            var comando = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dataprincipal, tabla);
            da.Dispose();
            con.Close();
        }

        public void ActualizarReceta_A_Entregada(int id, string nombreRetira, string parentezcoRetira)
        {
            SqlConnection con = new SqlConnection(Conexion.Cn);
            con.Open();
            var query = "UPDATE Receta SET Id_Estado = 4, Id_Usuario_Entrega_A_Paciente = @usuario, Fecha_Usuario_Entrega_A_Paciente = GETDATE() , Nombre_Retira = @nombreRetira, Parentezco = @parentezcoRetira WHERE Nro_Receta = @id";
            var comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("usuario", Usuario.Id_Usuario);
            comando.Parameters.AddWithValue("nombreRetira", nombreRetira);
            comando.Parameters.AddWithValue("parentezcoRetira", parentezcoRetira);
            comando.Parameters.AddWithValue("id", id);
            comando.ExecuteNonQuery();
            con.Close();
        }
    }
}
