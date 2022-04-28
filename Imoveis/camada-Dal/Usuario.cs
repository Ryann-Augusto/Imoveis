using MySqlConnector;
using System.Data;

namespace Imoveis.camada_Dal
{
    public class Usuario
    {
        private string MysqlConn()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var stringConexao = configuration.GetConnectionString("DefaultConnection");

            return stringConexao;
        }

        public DataTable ObterUsuarios()
        {
            string queryString = "SELECT Id, nome, email, senha FROM usuario;";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public List<Models.Usuarios> ObteveUsuarios()
        {
            var lista = new List<Models.Usuarios>();
            var planilhaDB = new Usuario();
            foreach (DataRow row in planilhaDB.ObterUsuarios().Rows)
            {
                var usuario = new Models.Usuarios();
                usuario.Id = Convert.ToInt32(row["Id"]);
                usuario.Nome = Convert.ToString(row["nome"]);
                usuario.Email = Convert.ToString(row["email"]);
                usuario.Senha = Convert.ToInt32(row["senha"]);

                lista.Add(usuario);
            }
            return lista;
        }
    }
}
