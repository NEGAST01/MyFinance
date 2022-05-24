using MySql.Data.MySqlClient;
using System.Data;
namespace MyFinance.Util { 
    

    public class DAL
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "";
        //private static string host = "localhost";
        private static string connectionString = $"server={server};  database = {database}; Uid = {user}; Pwd = {password}";
        private static MySqlConnection connection;

        public DAL()
        {

            connection = new MySqlConnection(connectionString);
            connection.Open();

        }

        //executa selects
        public DataTable RetDataTable (string Sql)
        {
            DataTable dataTable = new DataTable(); 
            MySqlCommand command = new MySqlCommand(Sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dataTable);
            return dataTable;   
        }

        //executa delete, update, etc

        public void ExecutarComandoSQL(string Sql)
        {
            MySqlCommand command = new MySqlCommand(Sql, connection);
            command.ExecuteNonQuery();


        }


    }
}
