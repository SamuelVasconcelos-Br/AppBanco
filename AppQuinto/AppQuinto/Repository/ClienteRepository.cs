using AppQuinto.Models;
using AppQuinto.Repository.Contract;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace AppQuinto.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update cliente set nomeCli = @nomeCli, " +
                                                    "DataNasc=@DataNasc Where IdCli=@IdCli", conexao);

                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = cliente.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdCli", MySqlDbType.VarChar).Value = cliente.idCli;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cliente(nomeCli, DataNasc) " +
                                                    " values (@nomeCli, @DataNasc)", conexao);
                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = cliente.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCli=@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> ClienteList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from cliente", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    ClienteList.Add(
                        new Cliente
                        {
                            idCli = Convert.ToInt32(dr["IdCli"]),
                            nomeCli = (string)dr["nomeCli"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return ClienteList;
            }
        }

        public Cliente ObterCliente(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from cliente " +
                                                    "where IdCli = @IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.idCli = Convert.ToInt32(dr["IdCli"]);
                    cliente.nomeCli = (string)(dr["nomeCli"]);
                    cliente.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                }
                return cliente;
            }
        }
    }
}
