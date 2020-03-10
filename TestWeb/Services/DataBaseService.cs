using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestWeb.Services
{
    public class DataBaseService
    {
        #region Main Logic

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        private void ConnectionEnable()
        {
            Connection.Open();
        }

        

        /// <summary>
        /// Разрыв соединения с базой данных
        /// </summary>
        private void ConnectionDisable()
        {
            Connection.Close();
        }

        #endregion

        public void AddNews(string title)
        {
            ConnectionEnable();
            DateTime d = new DateTime();
            d = DateTime.Now;
            String sqlCommand = String.Concat("INSERT news(title, text) VALUES('", title, "', 'fefefeffefefefefefef')");
            var addUserCommand = new MySqlCommand(sqlCommand, Connection);
            addUserCommand.ExecuteScalar();

            ConnectionDisable();

        }

        public void EditNews(string title)
        {
            ConnectionEnable();
            String sqlCommand = String.Concat("UPDATE news SET title = '", title, "'WHERE id = '", 1, "'");
            var updateUserLoginCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserLoginCommand.ExecuteScalar();
            ConnectionDisable();
        }

        public string GetNews()
        {
            ConnectionEnable();
            String sqlCommand = String.Concat("SELECT title FROM news WHERE id='", 1, "'");
            var getUserSettingsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getUserSettingsCommand.ExecuteScalar();
            string t = reader.ToString();
            ConnectionDisable();
            return t;
        }

        #region Fields

        /// <summary>
        /// Адресс подключения к базе данных
        /// </summary>
        const String DataBaseAdress = "server=localhost;user=root;database=JapanLanguageSiteDb;password=123456789q;";

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        private static MySqlConnection Connection = new MySqlConnection(DataBaseAdress);

        #endregion
    }
}
