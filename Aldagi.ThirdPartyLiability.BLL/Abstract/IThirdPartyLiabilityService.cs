using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.BLL.Abstract
{
    public interface IThirdPartyLiabilityService
    {
        IEnumerable<LiabilityTerm> GetTPLTermsByUserId(int internalUserId);
        LiabilityTerm GetTPLTerm(int tplTermId);
    }
}
