using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class ArticleModel
    {
        #region Constructors

        public ArticleModel()
        {

        }
        public ArticleModel(int id, string title, string text, string description, string imagePath, DateTime date) 
        {
            Id = id;
            Title = title;
            Text = text;
            Description = description;
            ImagePath = imagePath;
            Date = date;
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
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
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
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
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

        private int _id;

        private string _title;
        private string _text;
        private string _description;
        private string _imagePath;
        private DateTime _date;

        #endregion

    }
}
