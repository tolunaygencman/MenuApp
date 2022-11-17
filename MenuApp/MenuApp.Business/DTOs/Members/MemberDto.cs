using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Members
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string RestourantName { get; set; }
    }
}
