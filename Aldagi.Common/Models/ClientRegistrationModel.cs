using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.Common.Models
{
    public class ClientRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string Image { get; set; }
        public int CarId { get; set; }
        public int LiabilityTermId { get; set; }
    }
}
