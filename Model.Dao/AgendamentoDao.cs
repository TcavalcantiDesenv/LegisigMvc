using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AgendamentoDao
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AgendamentoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void create(Agendamento obj)
        {
            string create = "insert into Agendamentos values('" + obj.DiaDaSemana + "','" + obj.HoraDeExecucao + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
              //  obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Agendamento obj)
        {
            string delete = "delete from Agendamentos where AgendamentoId ='" + obj.AgendamentoId + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
              //  obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Agendamento obj)
        {
            bool temRegistros;
            string find = "select * from Agendamentos where AgendamentoId='" + obj.AgendamentoId + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.AgendamentoId = Convert.ToInt32(reader["AgendamentoId"].ToString());
                    obj.DiaDaSemana = reader["DiaDaSemana"].ToString();
                    obj.HoraDeExecucao = reader["HoraDeExecucao"].ToString();

                 //   obj.Estados = 99;
                }
                else
                {
                //    obj.Estados = 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return temRegistros;
        }

        public List<Agendamento> findAll()
        {
            List<Agendamento> listaAgendamento = new List<Agendamento>();
            string find = "select * from Agendamentos order by AgendamentoId asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Agendamento obj = new Agendamento();
                    obj.AgendamentoId = Convert.ToInt32(reader["AgendamentoId"].ToString());
                    obj.DiaDaSemana = reader["DiaDaSemana"].ToString();
                    obj.HoraDeExecucao = reader["HoraDeExecucao"].ToString();
                    listaAgendamento.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Agendamento obj2 = new Agendamento();
               // obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAgendamento;
        }

        public void update(Agendamento obj)
        {
            string update = "update Agendamento set DiaDaSemana='" + obj.DiaDaSemana + "',HoraDeExecucao='" + obj.HoraDeExecucao + "' where IdAcesso = '" + obj.AgendamentoId + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

              //  obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
