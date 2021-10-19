using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
   public class Receta
    {
        public int Id_Receta { get; set; }
        public int Nro_Receta { get; set; }
        public int Id_Medico { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Usuario_Registra { get; set; }
        public DateTime Fecha_Usuario_Registra { get; set; }
        public int Id_Usuario_Entrega_A_Medico { get; set; }
        public DateTime Fecha_Usuario_Entrega_A_Medico { get; set; }
        public int Id_Usuario_Recibe_De_Medico { get; set; }
        public DateTime Fecha_Usuario_Recibe_De_Medico { get; set; }
        public int Id_Usuario_Entrega_A_Paciente { get; set; }
        public DateTime Fecha_Usuario_Entrega_A_Paciente { get; set; }
        public String Nombre_Retira { get; set; }
        public String Parentezco { get; set; }
        public int Id_Usuario_Entrega_A_Archivo { get; set; }
        public DateTime Fecha_Entrega_A_Archivo { get; set; }
        public int Id_Usuario_Desecha { get; set; }
        public DateTime Fecha_Usuario_Desecha { get; set; }

        public Receta(int id_Receta, int nro_Receta, int id_Medico, int id_Paciente, int id_Estado, int id_Usuario_Registra, DateTime fecha_Usuario_Registra, int id_Usuario_Entrega_A_Medico, DateTime fecha_Usuario_Entrega_A_Medico, int id_Usuario_Recibe_De_Medico, DateTime fecha_Usuario_Recibe_De_Medico, int id_Usuario_Entrega_A_Paciente, DateTime fecha_Usuario_Entrega_A_Paciente, string nombre_Retira, string parentezco, int id_Usuario_Entrega_A_Archivo, DateTime fecha_Entrega_A_Archivo, int id_Usuario_Desecha, DateTime fecha_Usuario_Desecha)
        {
            Id_Receta = id_Receta;
            Nro_Receta = nro_Receta;
            Id_Medico = id_Medico;
            Id_Paciente = id_Paciente;
            Id_Estado = id_Estado;
            Id_Usuario_Registra = id_Usuario_Registra;
            Fecha_Usuario_Registra = fecha_Usuario_Registra;
            Id_Usuario_Entrega_A_Medico = id_Usuario_Entrega_A_Medico;
            Fecha_Usuario_Entrega_A_Medico = fecha_Usuario_Entrega_A_Medico;
            Id_Usuario_Recibe_De_Medico = id_Usuario_Recibe_De_Medico;
            Fecha_Usuario_Recibe_De_Medico = fecha_Usuario_Recibe_De_Medico;
            Id_Usuario_Entrega_A_Paciente = id_Usuario_Entrega_A_Paciente;
            Fecha_Usuario_Entrega_A_Paciente = fecha_Usuario_Entrega_A_Paciente;
            Nombre_Retira = nombre_Retira;
            Parentezco = parentezco;
            Id_Usuario_Entrega_A_Archivo = id_Usuario_Entrega_A_Archivo;
            Fecha_Entrega_A_Archivo = fecha_Entrega_A_Archivo;
            Id_Usuario_Desecha = id_Usuario_Desecha;
            Fecha_Usuario_Desecha = fecha_Usuario_Desecha;
        }

        public Receta()
        {

        }
    }
}
