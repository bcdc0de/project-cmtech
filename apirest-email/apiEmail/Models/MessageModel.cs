using System;
using MimeKit;

namespace ApiEmail.Models
{
    public class MessageModel
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string TextBody { get; set; }
    }
}
