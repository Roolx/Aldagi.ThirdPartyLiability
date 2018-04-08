using Aldagi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class TPLDetails
    {
        public int TplDetailsId { get; set; }
        public TplStatus Status { get; set; } = TplStatus.Unpaid;

        public int TPLTermId { get; set; }
        public TPLTerm TPLTerm { get; set; }
    }
}
