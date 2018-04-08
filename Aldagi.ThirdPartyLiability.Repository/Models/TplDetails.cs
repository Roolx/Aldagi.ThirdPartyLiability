using Aldagi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class TPLDetails
    {
        public int Id { get; set; }
        public int TplTermId { get; set; }
        public TPLTerm TplTerm { get; set; }
        public TplStatus Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
