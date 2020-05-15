using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class CourseModel
    {
        #region Constructors

        public CourseModel()
        {

        }
        public CourseModel(int id, string title, string description, int lessonsCount, int price, int hoursCount)
        {
            Id = id;
            Title = title;
            Description = description;
            LessonCount = lessonsCount;
            Price = price;
            HoursCount = hoursCount;
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

        public int LessonCount
        {
            get => _lessonCount;
            set
            {
                _lessonCount = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }
        public int HoursCount
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
            }
        }

        #endregion



        #region Fields

        private int _id;

        private string _title;
        private string _description;

        private int _lessonCount;
        private int _price;
        private int _hoursCount;

        #endregion


    }
}
