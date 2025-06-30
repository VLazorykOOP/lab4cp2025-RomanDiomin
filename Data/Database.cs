using MySql.Data.MySqlClient;
using System;

namespace CosmeticsApp.Data
{
    public static class Database
    {
        private static readonly string connectionString = "server=localhost;user=root;password=KiCo72L9gi7g;database=cosmetics_db;";

        public static MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                // Обробка помилки
                throw new Exception("Не вдалося підключитися до бази даних: " + ex.Message);
            }
            return connection;
        }
    }
}
