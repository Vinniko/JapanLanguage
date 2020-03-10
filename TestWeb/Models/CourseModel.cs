using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class CourseModel
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

        private string _title;
        private string _description;

        private int _lessonCount;
        private int _price;
        private int _hoursCount;

        #endregion


    }
}
