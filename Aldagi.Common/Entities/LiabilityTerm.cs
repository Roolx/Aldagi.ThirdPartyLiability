using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.Common.Entities
{
    public class LiabilityTerm
    {
        public int LiabilityTermId { get; set; }
        public decimal Limit { get; set; }
        public decimal Bonus { get; set; }
    }
}
