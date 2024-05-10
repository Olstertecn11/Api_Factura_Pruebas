using System.Data.Odbc;
namespace WebApi1.Models
{
    public class Connection
    {
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection("dsn=HotelSConexion");//manejar estandarizacion
            try
            {
                conn.Open();
            }
            catch (OdbcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No Conectó");
            }
            return conn;
        }

        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }
    }
}
