using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;

namespace TestWeb.Services
{
    public class LetterCreater : ILetterCreater
    {
        public LetterModel Create(string email, string login, string text)
        {
            return new LetterModel(email, login, TextCreater(email, login, text));
        }


        private string TextCreater(string email, string login, string text)
        {
            return string.Concat(text, "\n", login, " from: ", email);
        }
    }
}
