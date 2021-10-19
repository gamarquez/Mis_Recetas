using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
    //Hago publica la clase para poder acceder o instanciarla desde otro lado del proyecto
    public class Estado
    {

        //Declaro las variables con sus tipos de dato.
        public int Id { get; set; }
        public String Descripcion { get; set; }

        //Metodo constructor para generar nuevos objetos.
        public Estado(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        //Metodo constructor vacio para manipular y mostrar datos.
        public Estado()
        {

        }
    }
}
