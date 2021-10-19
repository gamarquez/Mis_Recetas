using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
    public class Rol
    {
        public int Id_Rol { get; set; }

        public String Descripcion { get; set; }

        public Rol(int id_Rol, string descripcion)
        {
            Id_Rol = id_Rol;
            Descripcion = descripcion;
        }

        public Rol()
        {

        }
    }
}
