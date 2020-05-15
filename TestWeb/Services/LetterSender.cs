using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using TestWeb.Interfaces;
using TestWeb.Models;

namespace TestWeb.Services
{
    public class LetterSender : ILetterSender
    {
        #region Main Logic
        
        public void Send(LetterModel letterModel)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(letterModel.Login, "vinnik_21@bk.ru"));
            emailMessage.To.Add(new MailboxAddress("", _adminEmailAdress));
            emailMessage.Subject = _messageSubject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = letterModel.Text
        };

            using (var client = new SmtpClient())
            {
                client.ConnectAsync("smtp.mail.ru", 25, false);
                client.AuthenticateAsync("vinnik_21@bk.ru", "alex0000");
                client.SendAsync(emailMessage);

                client.DisconnectAsync(true);
            }
        }

        #endregion



        #region Fields

        private const string _adminEmailAdress = "vinnik_21@bk.ru";
        private const string _messageSubject = "Japan Language";

        #endregion
    }
}
