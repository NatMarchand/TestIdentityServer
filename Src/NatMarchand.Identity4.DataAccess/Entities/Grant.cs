using System;

namespace NatMarchand.Identity4.DataAccess.Entities
{
    public class Grant
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public Guid SubjectId { get; set; }
        public string ClientId { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public DateTimeOffset? Expiration { get; set; }
        public string Data { get; set; }
    }
}