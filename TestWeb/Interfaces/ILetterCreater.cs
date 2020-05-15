using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface ILetterCreater
    {
        LetterModel Create(string email, string text, string login);
    }
}
