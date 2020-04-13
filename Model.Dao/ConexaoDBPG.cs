using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ConexaoDBPG
    {
        private static ConexaoDBPG objConexaoDBPG = null;
        private NpgsqlConnection con;

        private ConexaoDBPG()
        {
            //CONEXAO Postgres
            con = new NpgsqlConnection("server=ibmlider.ddns.com.br;Port=5432;user id=postgres;password=platinpostgres;database=SIM_ADM;Command Timeout=600");

            //CONEXAO Postgres Cloud
            //  con = new NpgsqlConnection("server=200.219.253.106;Port=5432;user id=postgres;password=platinsiad;database=postgres;Command Timeout=600");

        }

        public static ConexaoDBPG saberEstado()
        {
            if (objConexaoDBPG == null)
            {
                objConexaoDBPG = new ConexaoDBPG();
            }

            return objConexaoDBPG;
        }


        public NpgsqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            objConexaoDBPG = null;
        }
    }
}
