using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class InternalUser
    {
        public int InternalUserId { get; set; }
        public string Name { get; set; }
        public List<TPLTerm> TPLTerms { get; set; }
    }
}
