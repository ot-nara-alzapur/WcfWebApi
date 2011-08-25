using System;

namespace Services.Contract.Requests
{
    public class CanReactivateRequest
    {
        public string EmailAddress { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? MemberId { get; set; }
    }
}
