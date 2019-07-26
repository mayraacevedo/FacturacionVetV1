using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppVet.Datos
{
   public class BaseDatos
    {
        public bool EjecutarQuery(string Query)
        {
            SqlConnection myConnection = new SqlConnection("Server = localhost\\SQLEXPRESS; Database = BDVet; Trusted_Connection = True");
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(Query, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public DataTable ConsultaBD(string Query)
        {
           
            try
            {
                SqlConnection myConnection = new SqlConnection("Server = ESOTO-PC\\SQLEXPRESS; Database = BDVet; Trusted_Connection = True");
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(Query, myConnection);
                myReader = myCommand.ExecuteReader();
                DataTable Datos = new DataTable();
                Datos.Load(myReader);
                myConnection.Close();
                return Datos;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
