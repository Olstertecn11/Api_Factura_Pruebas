﻿using System.Data.Odbc;

namespace WebApi1.Models
{
    public class AccountSentences : Connection
    {

        public Connection conn;
        public AccountSentences()
        {
            this.conn = new Connection();
        }

        public List<string> getAccountsNames()
        {
            List<string> accountsNames = new List<string>();
            OdbcDataReader reader = this._get("", "SELECT cue_id, cli_nombre, cue_numero, cue_saldo FROM bd_banco.tbl_cuenta inner join tbl_cliente on cli_id = cue_cliente");
            while (reader.Read())
            {
                string name = reader.GetString(1);
                accountsNames.Add(name);
            }
            return accountsNames;
        }

        public List<Account> getAccounts()
        {
            List<Account> accounts = new List<Account>();
            OdbcDataReader reader = this._get("", "SELECT cue_id, cli_nombre, cue_numero, cue_saldo FROM bd_banco.tbl_cuenta inner join tbl_cliente on cli_id = cue_cliente");
            while (reader.Read())
            {
                Account acc = new Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                accounts.Add(acc);
            }
            Console.WriteLine(accounts.Count);
            return accounts;
        }


        public OdbcDataReader _get(string _table, string sql = "")
        {
            try
            {
                string query = sql.Equals("") ? "select * from " + _table : sql;
                OdbcCommand cmd = new OdbcCommand(query, this.conn.conexion());
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return null;
        }



        public Account getAccountBalance(string accountNo)
        {
            string sql = "SELECT cue_id, cli_nombre, cue_numero, cue_saldo FROM bd_banco.tbl_cuenta inner join tbl_cliente on cli_id = cue_cliente";
            OdbcDataReader reader = this._get("", sql);
            if (reader.Read())
            {
                return new Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
            }
            return null;
        }



    }
}