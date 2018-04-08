
using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Abstract
{
    public interface ICarDAL
    {
        IEnumerable<Car>GetCars();

        IEnumerable<Manufacturer> GetManufacturers();

        IEnumerable<Car> GetCarsByManufacturerId(int manufacturerId);
    }
}
