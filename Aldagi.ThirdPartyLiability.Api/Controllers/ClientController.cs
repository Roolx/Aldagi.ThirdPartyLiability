using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aldagi.Common.Entities;
using Aldagi.Common.Enums;
using Aldagi.Common.Exceptions;
using Aldagi.Common.Models;
using Aldagi.ThirdPartyLiability.Api.Helpers;
using Aldagi.ThirdPartyLiability.BLL.Abstract;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aldagi.ThirdPartyLiability.Api.Controllers
{
    [Produces("application/json")]
    [Route("clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IThirdPartyLiabilityService _thirdPartyLiabilityService;
        public ClientController(IClientService clientService, IThirdPartyLiabilityService thirdPartyLiabilityService)
        {
            _clientService = clientService;
            _thirdPartyLiabilityService = thirdPartyLiabilityService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Client>), (int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, typeof(ApiResponse), "Client was not found")]
        public IActionResult GetClient()
        {
            var clients = _clientService.GetClients(User.GetInternalUserId());
            if (!clients.Any())
            {
                return NotFound(new ApiResponse() { Message = "Client was not found" });
            }
            return new JsonResult(clients);
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        public IActionResult GetDetails(int clientId)
        {
            return new JsonResult(_clientService.GetClientDetails(clientId, User.GetInternalUserId()));
        }


        [HttpPost("register")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, typeof(ApiResponse), "Invalid parameters")]
        public IActionResult RegisterClient([FromBody]ClientRegistrationModel client)
        {
            try
            {
                _clientService.AddClient(client, User.GetInternalUserId());
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{clientId}/liability/details")]
        public IActionResult GetClientLiability([FromQuery]int clientId)
        {
            return new JsonResult(_clientService.GetClientLiability(clientId, User.GetInternalUserId()));
        }

        [HttpPut("{clientId}/liability/status")]
        public IActionResult UpdateClientLiabilityStatus([FromQuery] int clientId, [FromBody] TplStatus status)
        {
            _clientService.UpdateClientTPLStatus(clientId, status, User.GetInternalUserId());
            return Ok();
        }


        [HttpPut("{clientId}/liability/term")]
        public IActionResult UpdateClientLiabilityTerm([FromQuery] int clientId, [FromBody]int termId)
        {
            _clientService.UpdateClientTPLTerm(clientId, termId, User.GetInternalUserId());
            return Ok();
        }

        [HttpDelete("{clientId}/liability/remove")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, typeof(ApiResponse), "Client was not found")]
        public IActionResult RemoveClientLiability([FromQuery] int clientId)
        {
            try
            {
                _clientService.DeleteClientTPL(clientId, User.GetInternalUserId());
            }
            catch (ClientNotFoundException)
            {
                return NotFound(new ApiResponse() { Message = "Client was not found" });
            }
            return Ok();
        }


    }
}