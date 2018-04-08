using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public List<TPLTerm> TPLTerms { get; set; }
    }
}
