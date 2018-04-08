using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class TPLTerm
    {
        public int Id { get; set; }
        public decimal Limit { get; set; }
        public decimal Bonus { get; set; }
        public int IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
