using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Interfaces
{
    public interface IValidationService
    {
        public bool LoginTest(string login);
        public bool EmailTest(string email);
        public bool PasswordTest(string password);
        public bool AgeTest(int age);
    }
}
