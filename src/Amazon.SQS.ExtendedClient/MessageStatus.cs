using System;

namespace Amazon.SQS.ExtendedClient
{
    public class MessageStatus
    {
        public string Status { get; set; }
        public string Message { get; set; } 
            
        public string OriginalMessage { get; set; }
        public Exception Exception { get; set; }
    }
}