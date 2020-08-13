using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Unread { get; set; }
    }
}
