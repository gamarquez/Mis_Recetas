using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisRecetas.Modelo
{
    public class TipoDocumento
    {
        public int Id_Documento { get; set; }
        public String Descripcion { get; set; }

        public TipoDocumento(int id_Documento, string descripcion)
        {
            Id_Documento = id_Documento;
            Descripcion = descripcion;
        }

        public TipoDocumento()
        {

        }
    }
}
