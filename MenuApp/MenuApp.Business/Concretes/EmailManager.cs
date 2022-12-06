using MenuApp.Business.Abstracts;
using MenuApp.Business.DTOs.Emails;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.Concretes
{
    public class EmailManager : IMailService
    {
        public void SendEmail(SendEmailDto request)
        {
            throw new NotImplementedException();
        }
    }
}
