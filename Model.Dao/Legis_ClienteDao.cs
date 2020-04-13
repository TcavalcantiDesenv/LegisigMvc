using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class Legis_ClienteDao : Obrigatorio<Legis_Cliente>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public Legis_ClienteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Legis_Cliente obj)
        {
            string create = "insert into Legis_Cliente values('" + obj.Id + "','" + obj.IDCliente + "','" + obj.IDProduto + "','" + obj.IDSubProduto + "','" + obj.IDLegisGeral + "','" + obj.Aplicavel + "','" + obj.Lei + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Legis_Cliente obj)
        {
            string delete = "delete from Legis_Cliente where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Legis_Cliente obj)
        {
            bool temRegistros;
            string find = "select*from Legis_Cliente where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente =Convert.ToInt32( reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Lei = reader["Lei"].ToString();
                    obj.Estados = 99;
                }
                else
                {
                    obj.Estados = 1;
                }
            }
            catch (Exception)
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

        public List<Legis_Cliente> findAll()
        {
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = "select*from Legis_Cliente";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
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
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<LeisClientes> ExportarLeisClientesPorCliente(string cliente)
        {
            List<LeisClientes> listaLeisCliente = new List<LeisClientes>();
            string find = "select Id,IDCliente as NumCliente,IDLegisGeral as NumLei,RazaoSocial,Sistema,Ambito,Numero,Ano,Orgao,Tema,Ementa,Tipo,Municipio,Estado,Pais,lei as Situacao, Aplicavel,Link,Arqpdf as PDF from LeisClientes where IDCliente='" + cliente + "' order by Numero asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LeisClientes obj = new LeisClientes();
                    obj.IdLei = Convert.ToInt32(reader["Id"].ToString());
                    obj.RazaoSocial = reader["RazaoSocial"].ToString();
                    obj.IDCliente = Convert.ToInt32(reader["NumCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["NumLei"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Lei = reader["Situacao"].ToString();
                    obj.Link = reader["Link"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["PDF"].ToString();

                    listaLeisCliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                var Erro = ex.Message;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLeisCliente;
        }
        public List<ParametrosClientesModel> ExportarParametrosClientesPorCliente(string cliente)
        {
            List<ParametrosClientesModel> listaParametrosCliente = new List<ParametrosClientesModel>();
            string find = "select Id,IDCliente as NumCliente,Id as NumParametro,Exigencia,Assunto,Capitulo,Parametro,Obrigacao,Numero,Aplicavel,Conhecimento from ParametrosClientes where IDCliente='" + cliente + "' order by Numero asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ParametrosClientesModel obj = new ParametrosClientesModel();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.NumCliente = Convert.ToInt32(reader["NumCliente"].ToString());
                    obj.NumParametro = Convert.ToInt32(reader["NumParametro"].ToString());
                    obj.Exigencia = reader["Aplicavel"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Assunto = reader["Assunto"].ToString();
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();


                    listaParametrosCliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                var Erro = ex.Message;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaParametrosCliente;
        }
        public List<LeisClientes> buscarLeisClientesPorCliente(string cliente)
        {
            List<LeisClientes> listaLeisCliente = new List<LeisClientes>();
            string find = "select*from LeisClientes where IDCliente='" + cliente + "' order by RazaoSocial asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LeisClientes obj = new LeisClientes();
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
                    obj.Dias = Convert.ToInt32(reader["Dias"].ToString());
                    obj.RazaoSocial = reader["RazaoSocial"].ToString();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Lei = reader["Lei"].ToString();
                    obj.Param = reader["Param"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    obj.Ativo = reader["Ativo"].ToString();
                  
                    listaLeisCliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                var Erro = ex.Message;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLeisCliente;
        }
        public List<LeisClientes> buscarLeisClientesPorID(LeisClientes obj)
        {
            List<LeisClientes> listaLeisCliente = new List<LeisClientes>();
            string find = "select*from LeisClientes where IDLei='" + obj.IdLei + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                //    LeisClientes obj = new LeisClientes();
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
                    obj.Dias = Convert.ToInt32(reader["Dias"].ToString());
                    obj.RazaoSocial = reader["RazaoSocial"].ToString();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Lei = reader["Lei"].ToString();
                    obj.Param = reader["Param"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    obj.Ativo = reader["Ativo"].ToString();

                    listaLeisCliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                var Erro = ex.Message;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLeisCliente;
        }

        public List<Legis_Cliente> Total_Cliente_Ambito_Federal(string cliente)
        {
            if(cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }

            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = "Select distinct   'Federal' as Ambito, "+
                          "  (  select Count(LG.Ambito) as Federal  " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, " +
                          "  conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  " +                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and  " +
                          "  LG.Ambito = 'Federal' and PC.Aplicavel = 1 " +cliente+ ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros " + cliente + " ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Estadual(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = "Select distinct   'Estadual' as Ambito, " +
                          "  (  select Count(LG.Ambito) as Federal  " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, " +
                          "  conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  " +                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and  " +
                          "  LG.Ambito = 'Estadual' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Municipal(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = "Select distinct   'Municipal' as Ambito, " +
                          "  (  select Count(LG.Ambito) as Federal  " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, " +
                          "  conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  " +                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and  " +
                          "  LG.Ambito = 'Municipal' and PC.Aplicavel = 1 " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros " + cliente + " ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Normas(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = "Select distinct   'Normas Técnicas' as Ambito, " +
                          "  (  select Count(LG.Ambito) as Federal  " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, " +
                          "  conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  " +                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and  " +
                          "  LG.Ambito = 'Normas Técnicas' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + " ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_MeioAmbiente(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Meio Ambiente' as Sistema, " +
                          "  (  select Count(LG.Sistema) as Sistema  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and  " +
                          "  PC.ID  = C.IDParametros and LG.Sistema = 'Meio Ambiente' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Sistema"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_Qualidade(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Qualidade' as Sistema, " +
                          "  (  select Count(LG.Sistema) as Sistema  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and  " +
                          "  PC.ID  = C.IDParametros and LG.Sistema = 'Qualidade' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Sistema"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_ResponsabilidadeSocial(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Responsabilidade Social' as Sistema, " +
                          "  (  select Count(LG.Sistema) as Sistema  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and  " +
                          "  PC.ID  = C.IDParametros and LG.Sistema = 'Responsabilidade Social' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Sistema"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_SegurançaeSaude(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Segurança e Saúde' as Sistema, " +
                          "  (  select Count(LG.Sistema) as Sistema  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and  LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and  " +
                          "  PC.ID  = C.IDParametros and LG.Sistema = 'Segurança e Saúde' and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Ambito = reader["Sistema"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Aplicabilidade_Aplicavel(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Aplicavel' as Aplicabilidade, "+
                          "  (  select count(PC.Aplicavel) as Aplicavel  " +
                          "    from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Aplicabilidade = reader["Aplicabilidade"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Aplicabilidade_Conhecimento(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct   'Conhecimento' as Conhecimento, " +
                          "  (  select count(PC.Conhecimento) as Conhecimento  " +
                          "    from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and PC.COnhecimento = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_Atende(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct 'Atende' as Avaliacoes, "+
                          "  (  select count(C.Resultado) as Atende from legis_cliente as LC, " +
                          "  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and C.Resultado = 'Atende' " +
                          "  and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.Atende = reader["Avaliacoes"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_NaoInformado(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct 'Não Informado' as Avaliacoes, " +
                          "  (  select count(C.Resultado) as Atende from legis_cliente as LC, " +
                          "  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and C.Resultado = 'Não Informado' " +
                          "  and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.NaoInformado = reader["Avaliacoes"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_AtendeParcial(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct 'Atende Parcial' as Avaliacoes, " +
                          "  (  select count(C.Resultado) as Atende from legis_cliente as LC, " +
                          "  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and C.Resultado = 'Atende Parcial' " +
                          "  and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.AtendeParcial = reader["Avaliacoes"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_EmAndamento(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct 'Em Andamento' as Avaliacoes, " +
                          "  (  select count(C.Resultado) as Atende from legis_cliente as LC, " +
                          "  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and C.Resultado = 'Em Andamento' " +
                          "  and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros  " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.EmAndamento = reader["Avaliacoes"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_NaoAplicavel(string cliente)
        {
            if (cliente != "")
            {
                cliente = "and LC.IDCliente = " + cliente;
            }
            else { cliente = ""; }
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string find = @"Select distinct 'Não Aplicavel' as Avaliacoes, " +
                          "  (  select count(C.Resultado) as Atende from legis_cliente as LC, " +
                          "  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral=PC.IDLegisgeral and " +
                          "  LC.IDCliente = PC.IDCliente and  " +
                          "  LC.IDLegisgeral=C.IDLegis and " +
                          "  PC.ID  = C.IDParametros and C.Resultado = 'Não Aplicavel' " +
                          "  and PC.Aplicavel = 1  " + cliente + ") as Total " +
                          "  from legis_cliente as LC,  ParametrosCliente as PC, conformidade as C, LegisGeral as LG " +
                          "  where LG.Id = LC.IDLegisGeral and LC.IDLegisgeral = PC.IDLegisgeral and " +
                          "  LC.IDLegisgeral = C.IDLegis and " +
                          "  PC.ID = C.IDParametros " + cliente + "";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.NaoAplicavel = reader["Avaliacoes"].ToString();
                    obj.Total = Convert.ToInt32(reader["Total"].ToString());
                    listaLegis_Cliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Legis_Cliente obj2 = new Legis_Cliente();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;
        }

        public void update(Legis_Cliente obj)
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

                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public void updatePartial(Legis_Cliente obj)
        {
            string update = "update LeisClientes set Aplicavel='" + obj.Aplicavel + "',Lei='" + obj.Lei + "' where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public bool findLegis_ClientePorId(Legis_Cliente obj)
        {
            bool temRegistros;
            string find = "select*from Legis_Cliente where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Lei = reader["Lei"].ToString();

                    obj.Estados = 99;

                }
                else
                {
                    obj.Estados = 1;
                }
            }
            catch (Exception)
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
        public List<Legis_Cliente> findAllLegis_Cliente(Legis_Cliente objLegis_Cliente)
        {
            List<Legis_Cliente> listaLegis_Cliente = new List<Legis_Cliente>();
            string findAll = "select* from Legis_Cliente where IDCliente like '%" + objLegis_Cliente.IDCliente + "%' or IDProduto like '%" + objLegis_Cliente.IDProduto + "%' or IDSubProduto like '%" + objLegis_Cliente.IDSubProduto + "%' or IDLegisGeral like '%" + objLegis_Cliente.IDLegisGeral + "%' or Aplicavel like '%" + objLegis_Cliente.Aplicavel + "%' or Lei like '%" + objLegis_Cliente.Lei + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Legis_Cliente obj = new Legis_Cliente();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Lei = reader["Lei"].ToString();
                    listaLegis_Cliente.Add(obj);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegis_Cliente;

        }

    }
}
