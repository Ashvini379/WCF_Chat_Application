using System;

namespace ChatApp.Contract.Domain
{
    public class Message
    {
        public DateTime TimeSent { get; set; }
        public string FromUserID { get; set; }
        public string ToUserID { get; set; }
        public string MessageSent { get; set; }

    }
}