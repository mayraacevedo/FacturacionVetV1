using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Datos
{
    public class ProductoView
    {
        public int ID_PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public string ERROR { get; set; }
        public int CANTIDAD { get; set; }
    }
}
