using System.Data.SqlClient;

namespace Model.Dao
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            // CONEXAO LOCAL  
           // con = new SqlConnection("Server=200.219.253.106;Database=Financeiro;User Id=sa;Password = SCrsB84Y; ");

            //CONEXAO NO SERVIDOR Financeiro
   //         con = new SqlConnection("Data Source=sql5003.site4now.net;packet size=4096;user id=DB_A1938F_financeiro_admin;pwd=4rtr4x2308;persist security info=False;initial catalog=DB_A1938F_financeiro");

            //CONEXAO NO SERVIDOR Legisig 
       //     con = new SqlConnection("Data Source=sql5036.site4now.net;packet size=4096;user id=DB_A1938F_platin_admin;pwd=4rtr4x2308;persist security info=False;initial catalog=DB_A1938F_platin");
            con = new SqlConnection("Data Source=sql5042.site4now.net;packet size=4096;user id=DB_A1938F_LegisigNovo_admin;pwd=4rtr4x2308;persist security info=False;initial catalog=DB_A1938F_LegisigNovo");
        }

        public static ConexaoDB saberEstado()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;
        }


        public SqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
