using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Emails
{
    public class SendEmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
