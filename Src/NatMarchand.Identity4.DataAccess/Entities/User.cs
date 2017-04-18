using System;

namespace NatMarchand.Identity4.DataAccess.Entities
{
    public class User
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
