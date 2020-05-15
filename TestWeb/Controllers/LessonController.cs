using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;

namespace TestWeb.Controllers
{
    public class LessonController : Controller
    {
        #region Constructors

        public LessonController(ILessonRepository lessonRepository, IUserRepository userRepository)
        {
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
        }

        #endregion



        #region Main Logic

        public IActionResult LessonView(int lessonId, int userId)
        {
            ViewBag.User = _userRepository.GetUser(userId);
            ViewBag.Lesson = _lessonRepository.GetLesson(lessonId);
            return View();
        }

        #endregion



        #region Fields

        ILessonRepository _lessonRepository;
        IUserRepository _userRepository;

        #endregion
    }
}