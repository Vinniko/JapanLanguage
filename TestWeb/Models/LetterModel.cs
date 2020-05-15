using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class LetterModel
    {

        #region Constructors

        public LetterModel()
        {

        }
        public LetterModel(string email, string login, string text)
        {
            Email = email;
            Login = login;
            Text = text;
        }

        #endregion



        #region Fields

        public string Email { get; set; }
        public string Login { get; set; }
        public string Text { get; set; }

        #endregion
    }
}
