using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Interfaces
{
    public interface ICountryRepository
    {
        Dictionary<string, int> GetCountries();

        void AddCountry(string title);

        void UpdateCountry(int id, string title);

        void DeleteCountry(int id);

    }
}
