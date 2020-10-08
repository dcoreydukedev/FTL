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

        private readonly CommandLogService _CommandLogService;
        private readonly AppAuthService _AppAuthService;

        public CommandLogController()
        {
            this._CommandLogService = new CommandLogService();
            this._AppAuthService = new AppAuthService();
        }


        /// <summary>
        /// Creates the Specified Command Log Record
        /// </summary>        
        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] CommandLogRecord commandLogRecord, string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    CommandLogRecord clr = new CommandLogRecord(commandLogRecord.UserId, commandLogRecord.CommandId, commandLogRecord.Timestamp, commandLogRecord.Latitude, commandLogRecord.Longitude);
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
                // Log the Exception
                LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
