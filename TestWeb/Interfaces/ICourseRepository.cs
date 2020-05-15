using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface ICourseRepository
    {
        CourseModel GetCourse(int id);
         List<CourseModel> GetAllCourses();

         void AddCourse(CourseModel courseModel);

        void UpdateCourse(int id, CourseModel courseModel);

         void DeleteCourse(int id);

        void AddCourseForUser(int courseId, int userId);
        List<CourseModel> GetUserCouses(int userId);

        bool UserExistenceCourse(int userId, int courseId);
    }
}
