using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;
using TestWeb.Exeptions;

namespace TestWeb.Controllers
{
    public class FeedbackController : Controller
    {
        #region Constructors

        public FeedbackController(IUserRepository userRepository, ILetterCreater letterCreater, ILetterSender letterSender, IValidationService validationService)
        {
            _userRepository = userRepository;
            _letterCreater = letterCreater;
            _letterSender = letterSender;
            _validationService = validationService;
        }

        #endregion



        #region Main Logic

        public IActionResult FeedbackView(int userId, string message)
        {
            if (userId != 0) ViewBag.User = _userRepository.GetUser(userId);
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(int _userId, string email, string login, string text)
        {
            string tmpMessage = string.Empty;
            try
            {
                if (email != null || text != null)
                {
                    if (_validationService.EmailTest(email))
                    {
                        _letterSender.Send(_letterCreater.Create(email, login, text));
                    }
                    else
                    {
                        throw new BadEmailException(_errorEmail);
                    }
                }
                else
                {
                    throw new BadEmailException(_errorSendMessage);
                }
            }
            catch (BadEmailException ex)
            {
                tmpMessage = ex.Message;
            }
            catch(UserAlreadyExistException ex)
            {
                _letterSender.Send(_letterCreater.Create(email, login, text));
            }
            
            if(_userId != 0)
            return RedirectToAction("FeedbackView", new { userId = _userId, message = tmpMessage });
            else return RedirectToAction("FeedbackView", new { message = tmpMessage });
        }

        #endregion




        #region Fields

        IUserRepository _userRepository;
        ILetterCreater _letterCreater;
        ILetterSender _letterSender;
        IValidationService _validationService;
        private const string _errorSendMessage = "Пустые поля почты либо текста";
        private const string _errorEmail = "Неправильная почта";

        #endregion
    }
}