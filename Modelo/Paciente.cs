using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
    //Hago publica la clase para poder acceder o instanciarla desde otro lado del proyecto
    public class Paciente
    {
        //Declaro las variables con sus tipos de dato.
        public int Id_Paciente { get; set; }
        public int Id_TipoDocumento { get; set; }
        public String Nro_Documento { get; set; }
        public String Nombre_Paciente { get; set; }
        public String Apellido_Paciente { get; set; }
        public String Email { get; set; }

        //Metodo constructor para generar nuevos objetos.
        public Paciente(int id_Paciente, int id_TipoDocumento, string nro_Documento, string nombre, string apellido, String email)
        {
            Id_Paciente = id_Paciente;
            Id_TipoDocumento = id_TipoDocumento;
            Nro_Documento = nro_Documento;
            Nombre_Paciente = nombre;
            Apellido_Paciente = apellido;
            Email = email;
        }

        //Metodo constructor vacio para manipular y mostrar datos.
        public Paciente() 
        {
            
        }
    }
}
