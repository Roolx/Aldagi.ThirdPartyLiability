using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aldagi.ThirdPartyLiability.Api.Controllers
{
    [Produces("application/json")]
    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return  new JsonResult( _carService.GetCars());
        }

        [HttpGet("manufacturers")]
        public IActionResult GetManufacturers()
        {
            return new JsonResult(_carService.GetManufacturers());
        }


        [HttpGet("{manufacturerId}")]
        public IActionResult GetCarsByManufacturer([FromRoute]int manufacturerId)
        {
            return new JsonResult(_carService.GetCarsByManufacturerId(manufacturerId));
        }
    }
}