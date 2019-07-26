using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Datos
{
   public class Gestion
    {
        BaseDatos objDatos = new BaseDatos();
       
        public List<ProductoView> cbProducto()
        {
            List<ProductoView> ListPro = new List<ProductoView>();
            string Query = "SELECT ID_PRODUCTO,DESCRIPCION FROM PRODUCTO";
            DataTable Datos = objDatos.ConsultaBD(Query);
            
            foreach (DataRow Row in Datos.Rows)
            {
                ProductoView Pro = new ProductoView();
                Pro.ID_PRODUCTO = Convert.ToInt32(Row["ID_PRODUCTO"].ToString());
                Pro.DESCRIPCION = Row["DESCRIPCION"].ToString();
                ListPro.Add(Pro);
            }
          
            return ListPro;
        }

        public List<ProductoView> ConsultProducto(int ID_Producto)
        {
            List<ProductoView> ListPro = new List<ProductoView>();
            string Query = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO="+ID_Producto;
            DataTable Datos = objDatos.ConsultaBD(Query);
            
            foreach (DataRow Row in Datos.Rows)
            {
                ProductoView Pro = new ProductoView();
                Pro.ID_PRODUCTO = Convert.ToInt32(Row["ID_PRODUCTO"].ToString());
                Pro.DESCRIPCION = Row["DESCRIPCION"].ToString();
                Pro.PRECIO = Convert.ToInt32(Row["PRECIO"]);
                ListPro.Add(Pro);
            }
            return ListPro;

        }

        public bool GuardarFactura(string Total,List<ProductoView> Productos)
        {
            int ID_Factura=0;
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat("Insert into Factura values({0})",Total);

            if (objDatos.EjecutarQuery(Query.ToString()))
            {
                string QueryFac = "SELECT MAX(ID_FACTURA) AS ID_FACTURA FROM FACTURA";
                DataTable Datos = objDatos.ConsultaBD(QueryFac);
                foreach (DataRow Row in Datos.Rows)
                {
                    ID_Factura = Convert.ToInt32(Row["ID_FACTURA"].ToString());
                }
                
                foreach (var Producto in Productos)
                {
                    StringBuilder QueryDet = new StringBuilder();
                    QueryDet.AppendFormat("Insert into Factura_Det values({0},{1},{2},{3})",
                        ID_Factura,
                        Producto.ID_PRODUCTO,
                        Producto.CANTIDAD,
                        Producto.PRECIO);
                    objDatos.EjecutarQuery(QueryDet.ToString());
                }
                return true;
            }
            else
                return false;
        }
        public bool GuardarProducto(string Descripcion,string Precio)
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat("Insert into Producto values('{0}',{1})", Descripcion,Precio);

            if (!objDatos.EjecutarQuery(Query.ToString()))
                return false;
            else
                return true;
        }
    }
}
