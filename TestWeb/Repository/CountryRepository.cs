using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Services;

namespace TestWeb.Repository
{
    public class CountryRepository : ICountryRepository
    {
        #region Constructors

        public CountryRepository()
        {

        }
        public CountryRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic

        public Dictionary<string, int> GetCountries()
        {
            return _dataBaseService.GetCountries();
        }

        public void AddCountry(string title)
        {
            _dataBaseService.AddCountry(title);
        }

        public void UpdateCountry(int id, string title)
        {
            _dataBaseService.UpdateCountry(id, title);
        }

        public void DeleteCountry(int id)
        {
            _dataBaseService.DeleteCountry(id);
        }

        #endregion



        #region Fields

        DataBaseService _dataBaseService;

        #endregion
    }
}

