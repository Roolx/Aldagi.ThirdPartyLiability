using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }

        public int ClientDetailsId { get; set; }
        public ClientDetails ClientDetails { get; set; }
    }
}
