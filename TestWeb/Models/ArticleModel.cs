using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class ArticleModel
    {

        #region Get/Set

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        #endregion



        #region Fields

        private string _title;
        private string _text;
        private DateTime _date;

        #endregion

    }
}
