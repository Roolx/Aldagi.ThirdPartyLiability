using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class ClientDetails
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarRegistrationNumber { get; set; }
        public Car Car { get; set; }
        public string Image { get; set; }

        public int TplDetailsId { get; set; }
        public TPLDetails TplDetails { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
