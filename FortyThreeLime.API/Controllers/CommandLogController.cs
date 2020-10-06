using FortyThreeLime.API.Services;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/CommandLog")]
    [ApiController]
    public class CommandLogController : ApiControllerBase
    {

        private readonly ICommandLogService _CommandLogService;
        private readonly IAppAuthService _AppAuthService;

        public CommandLogController(ICommandLogService commandLogService, IAppAuthService appAuthService)
        {
            this._CommandLogService = commandLogService;
            this._AppAuthService = appAuthService;
        }


        /// <summary>
        /// Creates the Specified Command Log Record
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="CommandId">The command identifier.</param>
        /// <param name="Timestamp">The timestamp.</param>
        /// <param name="Lattitude">The latitude.</param>
        /// <param name="Longitude">The longitude.</param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] string UserId, [FromBody] int CommandId, [FromBody] long Timestamp, 
                                    [FromBody] string Lattitude, [FromBody] string Longitude, [FromBody] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    CommandLogRecord clr = new CommandLogRecord(UserId, CommandId, Timestamp, Lattitude, Longitude);
                    _CommandLogService.AddCommandLog(clr);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,                     
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };

                    return Ok(ret);
                }
                else
                {
                    var ret = new
                    {
                        Success = false,
                        Message = FAILURE_ACTION,                        
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
