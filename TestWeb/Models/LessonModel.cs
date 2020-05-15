using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class LessonModel
    {

        #region Constructors

        public LessonModel()
        {

        }

        public LessonModel(int id, string title, string description, string text, short hourses) 
        {
            Id = id;
            Title = title;
            Description = description;
            Text = text;
            Hourses = hourses;
        }

        #endregion



        #region Get/Set

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

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

        private int _id;

        private string _title;
        private string _description;
        private string _text;

        private short _hourses;

        #endregion

    }
}
