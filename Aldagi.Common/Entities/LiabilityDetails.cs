using Aldagi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.Common.Entities
{
    public class LiabilityDetails
    {
        public int LiabilityDetailsId { get; set; }
        public TplStatus Status { get; set; } = TplStatus.Unpaid;

        public int LiabilityTermId { get; set; }
    }
}
