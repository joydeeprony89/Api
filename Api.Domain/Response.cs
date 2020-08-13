using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public class Response
    {
        public int Id { get; set; }
        public int MessageCount { get; set; }
        public bool Unread { get; set; }
        public List<Participant> Participants { get; set; }
        public LastMessages LastMessage { get; set; }
    }
}
