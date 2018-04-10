using Aldagi.Common.Entities;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aldagi.ThirdPartyLiability.BLL.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarDAL _carDal;

        public CarService(ICarDAL carDal)
        {
            _carDal = carDal;
        }

        public IEnumerable<Car> GetCars()
        {
            return _carDal.GetCars().ToList();
        }

        public IEnumerable<Car> GetCarsByManufacturerId(int manufacturerId)
        {
            return _carDal.GetCarsByManufacturerId(manufacturerId);
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _carDal.GetManufacturers();
        }
    }
}
