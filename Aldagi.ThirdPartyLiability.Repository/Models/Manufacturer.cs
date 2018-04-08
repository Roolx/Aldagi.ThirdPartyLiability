using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
