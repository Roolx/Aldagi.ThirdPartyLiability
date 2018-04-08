using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Concrete
{
    public class ThirdPartyLiabilityDAL : IThirdPartyLiabilityDAL
    {
        private readonly DatabaseContext _databaseContext;
        public ThirdPartyLiabilityDAL(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public LiabilityTerm GetTPLTerm(int tplTermId)
        {
            var term = _databaseContext.TPLTerms.Where(x => x.TPLTermId == tplTermId).FirstOrDefault();
            if (term == null)
                return null;
            return new LiabilityTerm() { Bonus = term.Bonus, LiabilityTermId = term.TPLTermId, Limit = term.Limit };
        }

        public IEnumerable<LiabilityTerm> GetTPLTermsByUserId(int internalUserId)
        {
            var terms = _databaseContext.TPLTerms.Where(x => x.InternalUserId == internalUserId).ToList();
            if (terms == null)
                return null;
            return terms.Select((term) =>
            {
                return new LiabilityTerm()
                {
                    Bonus = term.Bonus,
                    Limit = term.Limit,
                    LiabilityTermId = term.TPLTermId
                };
            });
        }
    }
}
