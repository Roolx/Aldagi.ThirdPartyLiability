
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Aldagi.Common.Entities;

namespace Aldagi.ThirdPartyLiability.BLL.Concrete
{
    public class ThirdPartyLiabilityService : IThirdPartyLiabilityService
    {
        public IThirdPartyLiabilityDAL _thidPartyLiabilityDAL;

        public ThirdPartyLiabilityService(IThirdPartyLiabilityDAL thidPartyLiabilityDAL )
        {
            _thidPartyLiabilityDAL = thidPartyLiabilityDAL;
        }
        public LiabilityTerm GetTPLTerm(int tplTermId)
        {
            return _thidPartyLiabilityDAL.GetTPLTerm(tplTermId);
        }

        public IEnumerable<LiabilityTerm> GetTPLTermsByUserId(int internalUserId)
        {
            return _thidPartyLiabilityDAL.GetTPLTermsByUserId(internalUserId);
        }
    }
}
