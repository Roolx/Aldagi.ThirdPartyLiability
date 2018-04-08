using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastnName { get; set; }
        public string PersonalId { get; set; }
        public int DetailsId { get; set; }
        public ClientDetails Details { get; set; }
    }
}
