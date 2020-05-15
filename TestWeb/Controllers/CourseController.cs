using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;
using TestWeb.Services;

namespace TestWeb.Controllers
{
    public class CourseController : Controller
    {
        #region Constructors

        public CourseController(ICourseRepository courseRepository, IUserRepository userRepository, DataBaseService dataBaseService, ILessonRepository lessonRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _dataBaseService = dataBaseService;
            _lessonRepository = lessonRepository;
        }

        #endregion



        #region Main Logic

        public IActionResult CoursesView(int userId)
        {
            if (userId != 0) ViewBag.User = _userRepository.GetUser(userId);
            ViewBag.Courses = _courseRepository.GetAllCourses();
            ViewBag.CourseRepository = _courseRepository;
            return View();
        }

        public IActionResult OpenCourseView(int userId, int courseId, string message)
        {
            if (userId != 0)
            {
                ViewBag.User = _userRepository.GetUser(userId);
                ViewBag.Flag = _courseRepository.UserExistenceCourse(userId, courseId);
            }
            if(message != null)
            {
                ViewBag.Message = message;
            }
            var courseModel = _courseRepository.GetCourse(courseId);
            var tmpLessonsList = _lessonRepository.GetCourseLessons(courseId);
            ViewBag.Lessons = tmpLessonsList;
            for (var i = 0; i < tmpLessonsList.Count; i++)
            {
                courseModel.HoursCount += tmpLessonsList[i].Hourses;
            }
            ViewBag.Course = courseModel;
            return View();
        }

        public RedirectToActionResult BuyCourse(int _userId, int _id)
        {
            if(_userRepository.GetUser(_userId).Money >= _courseRepository.GetCourse(_id).Price)
            {
                _courseRepository.AddCourseForUser(_id, _userId);
                _dataBaseService.ChangeUserMoney(_userRepository.GetUser(_userId).Money -= _courseRepository.GetCourse(_id).Price, _userId);
                return RedirectToAction("OpenCourseView", "Course", new { courseId = _id, userId = _userId });
            }
            else
            {
                return RedirectToAction("OpenCourseView", "Course", new { userId = _userId, courseId = _id, message = _errorFewMoney });
            }
           
        }

        public IActionResult UserCoursesView(int userId)
        {
            if (userId != 0) ViewBag.User = _userRepository.GetUser(userId);
            ViewBag.Courses = _courseRepository.GetUserCouses(userId);
            return View();
        }

        #endregion



        #region Fields

        ICourseRepository _courseRepository;
        IUserRepository _userRepository;
        ILessonRepository _lessonRepository;
        DataBaseService _dataBaseService;

        private const string _errorFewMoney = "Недостаточно денег. Пополнить счёт можно в личном кабинете";

        #endregion
    }
}