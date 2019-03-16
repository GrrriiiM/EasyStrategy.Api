using EasyStrategy.Api.Contracts.Groupers;
using EasyStrategy.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class GrouperApiController : ControllerBase
    {
        readonly IGrouperApiService _grouperApiService;
        public GrouperApiController(IGrouperApiService grouperApiService)
        {
            _grouperApiService = grouperApiService;
        }


        [HttpGet("GrouperTypes")]
        public async Task<ActionResult<IEnumerable<TransferObjects.GrouperType>>> ListGrouperType()
        {
            return Ok(await _grouperApiService.ListGrouperType());
        }

        [HttpGet("Groupers")]
        public async Task<ActionResult<IEnumerable<TransferObjects.Grouper>>> ListGrouper()
        {
            return Ok(await _grouperApiService.ListGrouper());
        }



    }
}
