using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Recetas.Modelo
{
    public class Receta_Administrador
    {
        public string Usuario_Registra { get; set; }
        public DateTime Fecha_Usuario_Registra { get; set; }
        public string Usuario_Entrega_Medico { get; set; }
        public DateTime Fecha_Entrega_Medico { get; set; }
        public string Usuario_Recibe_Medico { get; set; }
        public DateTime Fecha_Usuario_Recibe_Medico { get; set; }
        public string Usuario_Entrega_Paciente { get; set; }
        public DateTime Fecha_Usuario_Entrega_Paciente { get; set; }

    }
}
