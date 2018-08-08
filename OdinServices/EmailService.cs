﻿using OdinModels;
using System;
using System.Collections.Generic;

namespace OdinServices
{
    public class EmailService
    {

        #region Properties
        
        public OptionService OptionService { get; set; }

        #endregion // Properties

        #region Methods

        public void sendCategoryUpdateEmail(string userName)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(userName + "@trendsinternational.com");
            message.To.Add("odin@trendsinternational.com");
            message.Subject = "New Category Request";
            message.From = new System.Net.Mail.MailAddress(userName + "@trendsinternational.com");
            message.Body = "A category update request has been submitted by " + userName;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.trendsinternational.com");
            smtp.Send(message);
        }

        public void sendPendingRequestEmail(string userName, string comment, string requestNum)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("odin@trendsinternational.com");
            message.Subject = "Odin Has a Present for you. A new Product Request #" + requestNum + "!";
            message.From = new System.Net.Mail.MailAddress(userName + "@trendsinternational.com");
            message.Body = "A product request has be submitted by " + userName;
            if (!(string.IsNullOrEmpty(comment)))
            {
                message.Body += " Comment: " + comment;
            }
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.trendsinternational.com");
            smtp.Send(message);
        }

        public void sendStatusChangedEmail(string requestId, List<Request> requests, string userName)
        {
            System.Net.Mail.MailMessage messageAdmin = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailMessage messageUser = new System.Net.Mail.MailMessage();
            string currentUser = Environment.UserName;
            messageUser.To.Add(userName + "@trendsinternational.com");
            messageUser.To.Add("odin@trendsinternational.com");
            messageUser.Subject = "Odin Product Request: " + requestId;
            messageAdmin.Subject = "Odin Product Request: " + requestId;
            messageUser.From = new System.Net.Mail.MailAddress(currentUser + "@trendsinternational.com");
            messageAdmin.From = new System.Net.Mail.MailAddress(currentUser + "@trendsinternational.com");
            messageUser.Body = "Your product request #" + requestId + ":\r\n";
            messageAdmin.Body = "Product request #" + requestId + ":\r\n";
            foreach (Request request in requests)
            {
                messageUser.Body += "\r\n" + request.ItemId + ": " + request.RequestStatus;
                messageAdmin.Body += "\r\n" + request.ItemId + ": " + request.RequestStatus;
                if (request.Comment != "")
                {
                    messageUser.Body += "\r\n    - " + request.Comment;
                    messageAdmin.Body += "\r\n    - " + request.Comment;
                }
            }
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.trendsinternational.com");
            smtp.Send(messageUser);
            smtp.Send(messageAdmin);
        }
    
        #endregion // Methods

        #region Constructor

        public EmailService(OptionService optionService)
        {
            if (optionService == null)
            {
                throw new ArgumentNullException("optionService");
            }
            this.OptionService = optionService;
        }

        #endregion // Constructor
    }
}
