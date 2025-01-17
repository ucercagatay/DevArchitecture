﻿namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Handlers.OperationClaims.Commands;
    using Business.Handlers.OperationClaims.Queries;
    using Core.Entities.Concrete;
    using Core.Entities.Dtos;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// If controller methods will not be Authorize, [AllowAnonymous] is used.
    /// </summary>
    ///
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseApiController
    {
        /// <summary>
        /// List OperationClaims
        /// </summary>
        /// <remarks>bla bla bla OperationClaims</remarks>
        /// <return>OperationClaims List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OperationClaim>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetOperationClaimsQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// It brings the details according to its id.
        /// </summary>
        /// <remarks>bla bla bla OperationClaims</remarks>
        /// <return>OperationClaims List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationClaim))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByid(int id)
        {
            var result = await Mediator.Send(new GetOperationClaimQuery() { Id = id });
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// List OperationClaims
        /// </summary>
        /// <remarks>bla bla bla OperationClaims</remarks>
        /// <return>OperationClaims List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SelectionItem>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getoperationclaimlookup")]
        public async Task<IActionResult> GetOperationClaimLookup()
        {
            var result = await Mediator.Send(new GetOperationClaimLookupQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// Update OperationClaim .
        /// </summary>
        /// <param name="updateOperationClaim"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
        {
            var result = await Mediator.Send(updateOperationClaim);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        /// <summary>
        /// List OperationClaims
        /// </summary>
        /// <remarks>bla bla bla OperationClaims</remarks>
        /// <return>OperationClaims List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OperationClaim>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getuserclaimsfromcache")]
        public async Task<IActionResult> GetUserClaimsFromCache()
        {
            var result = await Mediator.Send(new GetUserClaimsFromCacheQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}