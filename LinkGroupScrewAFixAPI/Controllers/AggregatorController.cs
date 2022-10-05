using LinkGroup.ScrewAFix.Models;
using LinkGroup.ScrewAFix.Services;
using LinkGroup.ScrewAFix.Services.Interfaces;
using LinkGroup.ScrewAFix.Services.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkGroupScrewAFixAPI.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AggregatorController : ControllerBase {

        private readonly ILogger<AggregatorController> _logger;
        private readonly IMediator _mediator;
        private readonly ConfigValues _config;
        public AggregatorController( IMediator mediator, ILogger <AggregatorController> logger, IOptions<ConfigValues> config )
        {
            _mediator = mediator;
            _logger = logger;
            _config = config.Value; 

        }

        [HttpPost("Brokerrequest", Name ="broker-post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IServiceResponse>> PostAsync([FromBody] CustomerRequest customerDetails)
        {
            if (!ModelState.IsValid)
            {
                return GetModelStateBadRequest();
            }

            if (customerDetails != null)
            {

                return await _mediator.Send(new ServiceRequestAsync()
                {
                    CustomerRequest = customerDetails,
                });
            }

            return CreateBadRequest("Invalid request.");
        }
        private ActionResult CreateBadRequest(string message)
        {
            _logger.LogWarning(message);
            return BadRequest(message);
        }
        private ActionResult GetModelStateBadRequest()
        {
            var errors = new SerializableError(ModelState);
            _logger.LogWarning($"Bad Request, model state errors: {JsonSerializer.Serialize(errors)}");

            return BadRequest(ModelState);
        }
    }
}
