using System;

namespace NatMarchand.Identity4.BusinessLogic
{
    public class TokenIssuedLog
    {
        public Guid SubjectId { get; set; }
        public string ClientId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Scopes { get; set; }
        public string IpAddress { get; set; }
    }
}