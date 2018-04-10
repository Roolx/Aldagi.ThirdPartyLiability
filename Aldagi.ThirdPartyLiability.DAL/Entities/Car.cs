using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public int ManufacturingYear { get; set; }
        public int ManufacturerId { get; set; }
    }
}
