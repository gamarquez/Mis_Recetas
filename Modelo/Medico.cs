using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
   public class Medico
    {
        //Declaro las variables con sus tipos de datos.
        public int Id_Medico { get; set; }
        public int Nro_Matricula { get; set; }
        public String Nombre_Medico { get; set; }
        public String Apellido_Medico { get; set; }

        //Declaro el metodo constructor para luego realizar inserciones en la DB.
        public Medico(int id_Medico, int nro_Matricula, string nombre_Medico, string apellido_Medico)
        {
            Id_Medico = id_Medico;
            Nro_Matricula = nro_Matricula;
            Nombre_Medico = nombre_Medico;
            Apellido_Medico = apellido_Medico;
        }
        //Declaro constructor vacio para manipular datos.
        public Medico()
        {

        }
    }
}
