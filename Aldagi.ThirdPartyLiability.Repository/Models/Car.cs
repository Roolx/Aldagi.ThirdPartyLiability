using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.Repository.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public DateTime ManufacturingYear { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
