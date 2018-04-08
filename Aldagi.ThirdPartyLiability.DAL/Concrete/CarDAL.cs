
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Aldagi.Common.Entities;

namespace Aldagi.ThirdPartyLiability.DAL.Concrete
{
    public class CarDAL : ICarDAL
    {
        private readonly DatabaseContext _databaseContext;
        public CarDAL(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Car> GetCars()
        {
            var cars = _databaseContext.Cars.ToList();
            return cars.Select((car) => { return new Car() { CarId = car.CarId, ManufacturerId = car.ManufacturerId, ManufacturingYear = car.ManufacturingYear, ModelName = car.ModelName }; });
        }

        public IEnumerable<Car> GetCarsByManufacturerId(int manufacturerId)
        {
            var cars = _databaseContext.Cars.Where(x => x.ManufacturerId == manufacturerId).ToList();
            return cars.Select((car) => { return new Car() { CarId = car.CarId, ManufacturerId = car.ManufacturerId, ManufacturingYear = car.ManufacturingYear, ModelName = car.ModelName }; });
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            var manufacturers = _databaseContext.Manufacturers.ToList();
            return manufacturers.Select((man) =>
            {
                return new Manufacturer()
                {
                    ManufacturerId = man.ManufacturerId,
                    Name = man.Name
                };
            });
        }
    }
}
