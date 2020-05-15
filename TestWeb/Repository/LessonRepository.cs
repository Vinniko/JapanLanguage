using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Services;

namespace TestWeb.Repository
{
    public class LessonRepository : ILessonRepository
    {

        #region Constructors

        public LessonRepository()
        {

        }
        public LessonRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic

        public LessonModel GetLesson(int id)
        {
            return _dataBaseService.GetLesson(id);
        }

        public void AddLesson(LessonModel lessonModel, int courseId)
        {
            _dataBaseService.AddLesson(lessonModel, courseId);
        }

        public void UpdateLesson(int id, LessonModel lessonModel)
        {
            _dataBaseService.UpdateLesson(id, lessonModel);
        }

        public void DeleteLesson(int id)
        {
            _dataBaseService.DeleteLesson(id);
        }

        public List<LessonModel> GetCourseLessons(int courseId)
        {
            return _dataBaseService.GetCourseLessons(courseId);
        }

        #endregion



        #region Fields

        DataBaseService _dataBaseService;

        #endregion
    }
}
