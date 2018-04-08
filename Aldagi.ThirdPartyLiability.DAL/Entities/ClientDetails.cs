using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class ClientDetails
    {
        public int ClientDetailsId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CarRegistrationNumber { get; set; }

        public string Image { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int? TPLDetailsId { get; set; }
        public TPLDetails TPLDetails { get; set; }

        public int InternalUserId { get; set; }
    }
}
