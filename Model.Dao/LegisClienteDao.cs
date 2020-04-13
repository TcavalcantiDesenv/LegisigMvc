using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LegisClienteDao : Obrigatorio<LegisClientes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public LegisClienteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public List<LegisClientes> findAll()
        {
            List<LegisClientes> listaLegis_Cliente = new List<LegisClientes>();
            string find = "select*from Legis_Cliente";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LegisClientes obj = new LegisClientes();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Lei = reader["Lei"].ToString();
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                LegisClientes obj2 = new LegisClientes();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }

        public void update(LegisClientes obj)
        {
            string update = "update Legis_Cliente set IDCliente='" + obj.IDCliente + "',IDProduto='" + obj.IDProduto + "',IDSubProduto='" + obj.IDSubProduto + "',IDLegisGeral='" + obj.IDLegisGeral + "',Aplicavel='" + obj.Aplicavel + "',Lei='" + obj.Lei + "' where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

  
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public void updatePartial(LeisClientes obj)
        {
            string update = "update Legis_Cliente set Aplicavel='" + obj.Aplicavel + "',Lei='" + obj.Lei + "' where IDLegisGeral='" + obj.IDLegisGeral + "' and IDCliente = '" + obj.IDCliente + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void create(LegisClientes obj)
        {
            throw new NotImplementedException();
        }

        public void delete(LegisClientes obj)
        {
            throw new NotImplementedException();
        }

        public bool find(LegisClientes obj)
        {
            throw new NotImplementedException();
        }

       
    }
}
