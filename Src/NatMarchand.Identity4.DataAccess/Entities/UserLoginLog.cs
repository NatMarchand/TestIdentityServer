using System;

namespace NatMarchand.Identity4.BusinessLogic
{
    public class UserLoginLog
    {
        public Guid SubjectId { get; set; }
        public string Provider { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}