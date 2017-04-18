using System;

namespace NatMarchand.Identity4.DataAccess.Entities
{
    public class Claim
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public byte[] Timestamp { get; set; }
    }
}