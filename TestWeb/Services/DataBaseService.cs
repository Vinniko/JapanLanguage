using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TestWeb.Models;
using TestWeb.Exeptions;

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



        #region Work With Countries

        public Dictionary<string, int> GetCountries()
        {
            ConnectionEnable();

            var tmpDictionary = new Dictionary<string, int>();
            String sqlCommand = String.Concat("select id, title from countries");
            var getCountriesCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getCountriesCommand.ExecuteReader();
            while (reader.Read())
            {
                tmpDictionary.Add(reader[1].ToString(), int.Parse(reader[0].ToString()));
            }
            reader.Close();

            ConnectionDisable();

            return tmpDictionary;
        }

        public void AddCountry(string title)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT counties(title) VALUES('", title, "')");
            var addCountryCommand = new MySqlCommand(sqlCommand, Connection);
            addCountryCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void UpdateCountry(int id, string title)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("UPDATE countries SET title = '", title, "'", " where id =", id);
            var updateCountryCommand = new MySqlCommand(sqlCommand, Connection);
            updateCountryCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void DeleteCountry(int id)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("DELETE FROM countries WHERE id = ", id);
            var deleteCountry = new MySqlCommand(sqlCommand, Connection);
            deleteCountry.ExecuteScalar();

            ConnectionDisable();
        }

        #endregion



        #region Work With Lessons

        public LessonModel GetLesson(int id)
        {
            ConnectionEnable();

            LessonModel tmpLesson = new LessonModel();
            String sqlCommand = String.Concat("select id, title, description, text, hourses from lessons where id =", id.ToString());
            var getLessonCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getLessonCommand.ExecuteReader();
            while (reader.Read())
            {
                tmpLesson = new LessonModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), short.Parse(reader[4].ToString()));
            }
            reader.Close();

            ConnectionDisable();

            return tmpLesson;
        }

        public void AddLesson(LessonModel lessonModel, int courseId)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT lessons(title, description, text, hourses, id_kurse) VALUES('", lessonModel.Title, "','",  lessonModel.Description, "','", lessonModel.Text, "',", lessonModel.Hourses, ",", courseId, ")");
            var addLessonCommand = new MySqlCommand(sqlCommand, Connection);
            addLessonCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void UpdateLesson(int id, LessonModel lessonModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("UPDATE lessons SET title = '", lessonModel.Title, "', description = '", lessonModel.Description, "', text = '", lessonModel.Text, "', hourses = ", lessonModel.Hourses, " where id =", lessonModel.Id);
            var updateLessonCommand = new MySqlCommand(sqlCommand, Connection);
            updateLessonCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void DeleteLesson(int id)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("DELETE FROM lessons WHERE id = ", id);
            var deleteLesson = new MySqlCommand(sqlCommand, Connection);
            deleteLesson.ExecuteScalar();

            ConnectionDisable();
        }

        public List<LessonModel> GetCourseLessons(int courseId)
        {
            ConnectionEnable();

            List<LessonModel> tmpLessonsModels = new List<LessonModel>();
            String sqlCommand = String.Concat("select id, title, description, text, hourses from lessons where id_kurse =", courseId.ToString());
            var getLessonsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getLessonsCommand.ExecuteReader();
            while (reader.Read())
            {
                var tmpLesson = new LessonModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), short.Parse(reader[4].ToString()));
                tmpLessonsModels.Add(tmpLesson);
            }
            reader.Close();

            ConnectionDisable();

            return tmpLessonsModels;
        }

        #endregion



        #region Work With Courses

        public CourseModel GetCourse(int id)
        {
            ConnectionEnable();

            CourseModel tmpCourse = new CourseModel();
            String sqlCommand = String.Concat("select id, title, description, price from kurses where id =", id.ToString());
            var getCourseCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getCourseCommand.ExecuteReader();
            while (reader.Read())
            {
                tmpCourse = new CourseModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), 0, int.Parse(reader[3].ToString()), 0);
            }
            reader.Close();

            ConnectionDisable();

            return tmpCourse;
        }

        public List<CourseModel> GetAllCourses()
        {
            ConnectionEnable();

            List<CourseModel> tmpCoursesModels = new List<CourseModel>();
            String sqlCommand = String.Concat("select id, title, description, price from kurses");
            var getCoursesCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getCoursesCommand.ExecuteReader();
            while (reader.Read())
            {
                var tmpCourse = new CourseModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), 0, int.Parse(reader[3].ToString()), 0);
                tmpCoursesModels.Add(tmpCourse);
            }
            reader.Close();

            ConnectionDisable();

            return tmpCoursesModels;
        }

        public void AddCourse(CourseModel courseModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT kourses(title, description, price) VALUES('", courseModel.Title, "','", courseModel.Description, "',", courseModel.Price, ")");
            var addCourseCommand = new MySqlCommand(sqlCommand, Connection);
            addCourseCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void UpdateCourse(int id, CourseModel courseModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("UPDATE kurses SET title = '", courseModel.Title, "', description = '", courseModel.Description, "', price = ", courseModel.Price,  " where id =", courseModel.Id);
            var updateCourseCommand = new MySqlCommand(sqlCommand, Connection);
            updateCourseCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void DeleteCourse(int id)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("DELETE FROM kurses WHERE id = ", id);
            var deleteCourse = new MySqlCommand(sqlCommand, Connection);
            deleteCourse.ExecuteScalar();

            ConnectionDisable();
        }

        public void AddCourseForUser(int courseId, int userId)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("insert userskurses(id_kurse, id_user) values(", courseId, ",", userId, ")");
            var addCourseForUserCommand = new MySqlCommand(sqlCommand, Connection);
            addCourseForUserCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public List<CourseModel> GetUserCouses(int userId)
        {
            ConnectionEnable();

            List<CourseModel> tmpCoursesModels = new List<CourseModel>();
            String sqlCommand = String.Concat("SELECT kurses.id, kurses.title, kurses.description, kurses.price FROM kurses inner join userskurses on userskurses.id_kurse = kurses.id where userskurses.id_user =", userId);
            var getCoursesCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getCoursesCommand.ExecuteReader();
            while (reader.Read())
            {
                var tmpCourse = new CourseModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), 0, int.Parse(reader[3].ToString()), 0);
                tmpCoursesModels.Add(tmpCourse);
            }
            reader.Close();

            ConnectionDisable();

            return tmpCoursesModels;
        }

        #endregion



        #region Work With Articles

        public ArticleModel GetArticle(int id)
        {
            ConnectionEnable();

            ArticleModel tmpArticle = new ArticleModel();
            String sqlCommand = String.Concat("select id, title, text, description, imagePath, date from articles where id =", id.ToString());
            var getArticleCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getArticleCommand.ExecuteReader();
            while (reader.Read())
            {
                tmpArticle = new ArticleModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), DateTime.Parse(reader[5].ToString()));
            }
            reader.Close();

            ConnectionDisable();

            return tmpArticle;
        }
        public List<ArticleModel> GetAllArticles()
        {
            ConnectionEnable();

            List<ArticleModel> tmpArticlesModels = new List<ArticleModel>();
            String sqlCommand = String.Concat("select id, title, text, description, imagePath, date from articles");
            var getArticlesCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getArticlesCommand.ExecuteReader();
            while (reader.Read())
            {
                var tmpArticle = new ArticleModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), DateTime.Parse(reader[5].ToString()));
                tmpArticlesModels.Add(tmpArticle);
            }
            reader.Close();

            ConnectionDisable();

            return tmpArticlesModels;
        }

        public void AddArticle(ArticleModel articleModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT articles(title, text, description, imagePath, date) VALUES('", articleModel.Title, "','", articleModel.Text, "','", articleModel.Description, "','", articleModel.ImagePath, "','", articleModel.Date, "')");
            var addArticleCommand = new MySqlCommand(sqlCommand, Connection);
            addArticleCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void UpdateArticle(int id, ArticleModel articleModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("UPDATE articles SET title = '", articleModel.Title, "', text = '", articleModel.Text, "', description = '", articleModel.Description, "', imagePath = '", articleModel.ImagePath, "', date = ", articleModel.Date, " where id =", articleModel.Id);
            var updateArticleCommand = new MySqlCommand(sqlCommand, Connection);
            updateArticleCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void DeleteArticle(int id)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("DELETE FROM articles WHERE id = ", id);
            var deleteArticle = new MySqlCommand(sqlCommand, Connection);
            deleteArticle.ExecuteScalar();

            ConnectionDisable();
        }

        #endregion



        #region Work With News

        public NewsModel GetNews(int id)
        {
            ConnectionEnable();

            NewsModel tmpNews = new NewsModel();
            String sqlCommand = String.Concat("select id, title, text, description, imagePath, date from news where id =", id.ToString());
            var getNewsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getNewsCommand.ExecuteReader();
            while (reader.Read())
            {
                tmpNews = new NewsModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[4].ToString(), DateTime.Parse(reader[5].ToString()), reader[3].ToString());
            }
            reader.Close();

            ConnectionDisable();

            return tmpNews;
        }
        public List<NewsModel> GetAllNews()
        {
            ConnectionEnable();

            List<NewsModel> tmpNewsModels = new List<NewsModel>();
            String sqlCommand = String.Concat("select id, title, text, description, imagePath, date from news");
            var getNewsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getNewsCommand.ExecuteReader();
            while (reader.Read())
            {
                var tmpNews = new NewsModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[4].ToString(), DateTime.Parse(reader[5].ToString()), reader[3].ToString());
                tmpNewsModels.Add(tmpNews);
            }
            reader.Close();

            ConnectionDisable();

            return tmpNewsModels;
        }

        public void AddNews(NewsModel newsModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT news(title, text, description, imagePath, date) VALUES('", newsModel.Title, "','", newsModel.Text, "','", newsModel.Description, "','", newsModel.ImagePath, "','", newsModel.Date, "')");
            var addNewsCommand = new MySqlCommand(sqlCommand, Connection);
            addNewsCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void UpdateNews(int id, NewsModel newsModel)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("UPDATE news SET title = '", newsModel.Title, "', text = '", newsModel.Text, "', description = '", newsModel.Description, "', imagePath = '", newsModel.ImagePath, "', date = ", newsModel.Date, " where id =", newsModel.ID);
            var updateNewsCommand = new MySqlCommand(sqlCommand, Connection);
            updateNewsCommand.ExecuteScalar();

            ConnectionDisable();
        }

        public void DeleteNews(int id)
        {
            ConnectionEnable();

            string sqlCommand = String.Concat("DELETE FROM news WHERE id = ", id);
            var deleteNews = new MySqlCommand(sqlCommand, Connection);
            deleteNews.ExecuteScalar();

            ConnectionDisable();
        }

        #endregion



        #region Work With Users

        public UserModel GetUser(int id)
        {
            ConnectionEnable();

            UserModel user = new UserModel();
            String sqlCommand = String.Concat("SELECT AuthorizationUsers.id, AuthorizationUsers.login, AuthorizationUsers.age, AuthorizationUsers.money, NoAthorizationUsers.email, NoAthorizationUsers.password, Countries.title FROM AuthorizationUsers inner join NoAthorizationUsers on NoAthorizationUsers.id = AuthorizationUsers.id_NAU inner join Countries on Countries.id = AuthorizationUsers.id_country where AuthorizationUsers.id =", id);
            var getUserCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getUserCommand.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[5].ToString(), reader[4].ToString(), reader[6].ToString(), short.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()));
            }
            reader.Close();

            ConnectionDisable();

            return user;
        }

        public UserModel GetUser(string email)
        {
            ConnectionEnable();

            UserModel user = new UserModel();
            String sqlCommand = String.Concat("SELECT AuthorizationUsers.id, AuthorizationUsers.login, AuthorizationUsers.age, AuthorizationUsers.money, NoAthorizationUsers.email, NoAthorizationUsers.password, Countries.title FROM AuthorizationUsers inner join NoAthorizationUsers on NoAthorizationUsers.id = AuthorizationUsers.id_NAU inner join Countries on Countries.id = AuthorizationUsers.id_country where NoAthorizationUsers.email ='", email, "'");
            var getUserCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getUserCommand.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[5].ToString(), reader[4].ToString(), reader[6].ToString(), short.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()));
            }
            reader.Close();

            ConnectionDisable();

            return user;
        }

        public int AddUser(UserModel user)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("INSERT NoAthorizationUsers(email, password) VALUES('", user.Email, "','", user.Password, "')");
            var addUserCommand = new MySqlCommand(sqlCommand, Connection);
            addUserCommand.ExecuteScalar();
            sqlCommand = "SELECT LAST_INSERT_ID()";
            var getLastIdCommand = new MySqlCommand(sqlCommand, Connection);
            int tmpId = int.Parse(getLastIdCommand.ExecuteScalar().ToString());
            sqlCommand = String.Concat("INSERT AuthorizationUsers(id_NAU, login, age, id_country, money) VALUES(", tmpId, ",'", user.Login, "',", user.Age, ",", 1, ",", user.Money, ")");
            addUserCommand = new MySqlCommand(sqlCommand, Connection);
            addUserCommand.ExecuteScalar();
            sqlCommand = "SELECT LAST_INSERT_ID()";
            getLastIdCommand = new MySqlCommand(sqlCommand, Connection);
            tmpId = int.Parse(getLastIdCommand.ExecuteScalar().ToString());

            ConnectionDisable();

            return tmpId;
        }

        public void ChangeUserLogin(string login, int id)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("update AuthorizationUsers set login = '", login, "' where id = ", id.ToString());
            var updateUserLoginCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserLoginCommand.ExecuteScalar();

            ConnectionDisable();
        }
        public void ChangeUserPassword(string password, int id)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("update NoAthorizationUsers set password = '", password, "' where id = (SELECT id_NAU from AuthorizationUsers where id = ", id.ToString(), ")");
            var updateUserPasswordCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserPasswordCommand.ExecuteScalar();

            ConnectionDisable();
        }
        public void ChangeUserEmail(string email, int id)
        {

        }
        public void ChangeUserAge(short age, int id)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("update AuthorizationUsers set age = ", age, " where id = ", id.ToString());
            var updateUserLoginCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserLoginCommand.ExecuteScalar();

            ConnectionDisable();
        }
        public void ChangeUserMoney(int money, int id)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("update AuthorizationUsers set money = ", money.ToString(), " where id = ", id.ToString());
            var updateUserMoneyCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserMoneyCommand.ExecuteScalar();

            ConnectionDisable();
        }
        public void ChangeUserCountry(string country, int id)
        {
            ConnectionEnable();

            String sqlCommand = String.Concat("update AuthorizationUsers set id_country = (select id from countries where title ='", country, "') where id = ", id.ToString());
            var updateUserCountryCommand = new MySqlCommand(sqlCommand, Connection);
            updateUserCountryCommand.ExecuteScalar();

            ConnectionDisable();
        }
        public bool LoginExistTester(string login)
        {
            ConnectionEnable();

            bool tmpFlag = false;
            String sqlCommand = String.Concat("SELECT login FROM AuthorizationUsers");
            var getUsersLoginsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getUsersLoginsCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == login) tmpFlag = true;
            }
            reader.Close();

            ConnectionDisable();

            return tmpFlag;
        }
        public bool EmailExistTester(string email)
        {
            ConnectionEnable();

            bool tmpFlag = false;
            String sqlCommand = String.Concat("SELECT * FROM NoAthorizationUsers");
            var getUsersLoginsCommand = new MySqlCommand(sqlCommand, Connection);
            var reader = getUsersLoginsCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == email) tmpFlag = true;
            }
            reader.Close();

            ConnectionDisable();

            return tmpFlag;
        }

        #endregion

        #endregion



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
