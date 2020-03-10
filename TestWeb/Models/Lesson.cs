using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class Lesson
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
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
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

        public short Hourses
        {
            get => _hourses;
            set
            {
                _hourses = value;
            }
        }
        #endregion



        #region Fields

        private string _title;
        private string _description;
        private string _text;

        private short _hourses;

        #endregion

    }
}
