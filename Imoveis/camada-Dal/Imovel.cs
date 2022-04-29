using MySqlConnector;
using System.Data;

namespace Imoveis.camada_Dal
{
    public class Imovel
    {
        private string MySqlConn()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var stringConexao = configuration.GetConnectionString("DefaultConnection");

            return stringConexao;
        }

        public DataTable ObterImoveis()
        {
            string queryString = "SELECT ImovelId, imoveldsc, imovelvlr, imovelnumQrt, imovelnumvag, imovelrua, imovelbro, imovelcdd, imoveluf, imovelcep, usu.nome FROM imoveis.imovel INNER JOIN usuario usu ON usuarioid = usu.id; ";
            using (MySqlConnection connection = new MySqlConnection(MySqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }
    }
}
