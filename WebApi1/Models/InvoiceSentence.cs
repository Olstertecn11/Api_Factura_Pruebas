using System.Data.Odbc;

namespace WebApi1.Models
{
    public class InvoiceSentence
    {

        public Connection conn;
        public InvoiceSentence()
        {
            this.conn = new Connection();
        }

        public Invoice createInvoice(Invoice invoice)
        {
            string sql = "insert into tbl_factura(fac_fecha, cli_nit, fac_monto, fac_estado, fac_servicio)values(CURRENT_DATE(), '" + invoice.clientNit + "', '" + invoice.amount + "', '" + 0 + "', '" + invoice.serviceName + "')";
            Console.WriteLine(sql);
            OdbcCommand cmd = new OdbcCommand(sql, this.conn.conexion());
            invoice.status = false;
            try
            {
                cmd.ExecuteNonQuery();
                return invoice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void changeInvoiceStatus(int InvoiceId)
        {
            string sql = "update tbl_factura set fac_estado=1 where fac_id = '" + InvoiceId + "'";
            try
            {
                OdbcCommand cmd = new OdbcCommand(sql, this.conn.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
