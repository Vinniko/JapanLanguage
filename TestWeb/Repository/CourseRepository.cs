using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Services;
using TestWeb.Models;

namespace TestWeb.Repository
{
    public class CourseRepository : ICourseRepository
    {
        #region Constructors

        public CourseRepository()
        {

        }
        public CourseRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic

        public CourseModel GetCourse(int id)
        {
            return _dataBaseService.GetCourse(id);
        }
        public List<CourseModel> GetAllCourses()
        {
            var tmpList = _dataBaseService.GetAllCourses();
            return tmpList;
        }

        public void AddCourse(CourseModel courseModel)
        {
            _dataBaseService.AddCourse(courseModel);
        }

        public void UpdateCourse(int id, CourseModel courseModel)
        {
            _dataBaseService.UpdateCourse(id, courseModel);
        }

        public void DeleteCourse(int id)
        {
            _dataBaseService.DeleteCourse(id);
        }

        public void AddCourseForUser(int courseId, int userId)
        {
            _dataBaseService.AddCourseForUser(courseId, userId);
        }

        public List<CourseModel> GetUserCouses(int userId)
        {
            return _dataBaseService.GetUserCouses(userId);
        }

        public bool UserExistenceCourse(int userId, int courseId)
        {
            var tmpUserCourses = _dataBaseService.GetUserCouses(userId);
            for(var i = 0; i < tmpUserCourses.Count; i++)
            {
                if (tmpUserCourses[i].Id == courseId) return true;
            }
            return false;
        }

        #endregion



        #region Fields

        DataBaseService _dataBaseService;

        #endregion
    }
}
