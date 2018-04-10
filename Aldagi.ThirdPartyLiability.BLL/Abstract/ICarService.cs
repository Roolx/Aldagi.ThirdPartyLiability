
using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aldagi.ThirdPartyLiability.BLL.Abstract
{
    public interface ICarService
    {
        IEnumerable<Manufacturer> GetManufacturers();

        IEnumerable<Car> GetCars();

        IEnumerable<Car> GetCarsByManufacturerId(int manufacturerId);
    }
}
