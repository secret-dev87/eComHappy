﻿using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
   
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpGet]
        public async Task<IActionResult> InsertAsync()
        {
            //var result = await _mediator.Send(insertProductOption);

            return new JsonResult(new { success = true });
        }
    }
}
