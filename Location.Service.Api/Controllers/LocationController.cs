using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Location.Service.Application.Locations.GetBranchLocations;
using Location.Service.Application.Locations.UpdatParentOfLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Location.Service.Api.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet("branch/{branchId}")]
        public async Task<IActionResult> GetBranchLocations(int branchId)
        {
            var locationList = await _mediator.Send(new GetBranchLocationsQuery(branchId));
            return Ok(locationList);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateParentOfLocation([FromBody] UpdateParentOfLocationRequest request)
        {
            var location =await _mediator.Send(new UpdateParentOfLocationCommand(request.LocationId, request.ParentLocationId));
            return Ok(location);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("here");
        }
    }
}
