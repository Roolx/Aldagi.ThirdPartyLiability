using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Abstract
{
    public interface IThirdPartyLiabilityDAL
    {
        IEnumerable<LiabilityTerm> GetTPLTermsByUserId(int internalUserId);
        LiabilityTerm GetTPLTerm(int tplTermId);
    }
}
