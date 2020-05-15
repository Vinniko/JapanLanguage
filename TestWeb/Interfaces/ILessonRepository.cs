using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface ILessonRepository
    {
        LessonModel GetLesson(int id);

        void AddLesson(LessonModel lessonModel, int courseId);

        void UpdateLesson(int id, LessonModel lessonModel);

        void DeleteLesson(int id);

        List<LessonModel> GetCourseLessons(int courseId);
    }
}
