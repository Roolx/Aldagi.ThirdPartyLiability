using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aldagi.Common.Entities;
using Aldagi.ThirdPartyLiability.Api.Helpers;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aldagi.ThirdPartyLiability.Api.Controllers
{
    [Produces("application/json")]
    [Route("liabilities")]
    
    public class LiabilityController : Controller
    {
        private readonly IThirdPartyLiabilityService _tplService;
        private readonly ILogger<LiabilityController> _logger;
        public LiabilityController(IThirdPartyLiabilityService tplService, ILogger<LiabilityController> logger)
        {
            _tplService = tplService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LiabilityTerm>), 200)]
        public IActionResult Get()
        {
            var terms = _tplService.GetTPLTermsByUserId(User.GetInternalUserId());

            return new JsonResult(terms);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LiabilityTerm), 200)]
        [SwaggerResponse((int)HttpStatusCode.NotFound,typeof(ApiResponse),"Term was not found")]
        public IActionResult Get(int id)
        {
            var term = _tplService.GetTPLTerm(id);

            if(term == null)
            {
                return   NotFound(new ApiResponse() { Message = "Term was not found"  });
            }

            return new JsonResult(term);
        }
    }
}
