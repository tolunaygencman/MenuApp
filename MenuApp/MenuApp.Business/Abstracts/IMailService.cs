using MenuApp.Business.DTOs.Emails;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.Abstracts
{
    public interface IMailService
    {
        void SendEmail(SendEmailDto request);
    }
}
