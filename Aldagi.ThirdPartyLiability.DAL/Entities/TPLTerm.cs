using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class TPLTerm
    {
        public int TPLTermId { get; set; }
        public decimal Limit { get; set; }
        public decimal Bonus { get; set; }

        public int InternalUserId { get; set; }
        public InternalUser IdentityUser { get; set; }
    }
}
