/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using FortyThreeLime.API.Services;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

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


        [Route("Create")]
        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] string userId, [FromQuery] int commandId, [FromQuery] long timestamp, [FromQuery] string latitude, [FromQuery] string longitude, [FromQuery] string loginToken)
        {          
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    CommandLogRecord clr = new CommandLogRecord
                    (
                        userId, 
                        commandId, 
                        timestamp, 
                        latitude, 
                        longitude
                    );
                    await _CommandLogService.AddCommandLog(clr);

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
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    List<CommandLogRecord> commandLogRecords = await _CommandLogService.GetCommandLogs();

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemType = typeof(CommandLogRecord),
                        Items = commandLogRecords,
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
                        Message = FAILURE_DATA,
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("Get/{userId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string loginToken, [FromQuery] string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    List<CommandLogRecord> commandLogRecords = await _CommandLogService.GetCommandLogs(userId);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemType = typeof(CommandLogRecord),
                        Items = commandLogRecords,
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
                        Message = FAILURE_DATA,
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("Get/{userId}/{commandId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string loginToken, [FromQuery] string userId, [FromQuery] int commandId)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    List<CommandLogRecord> commandLogRecords = await _CommandLogService.GetCommandLogs(userId, commandId);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemType = typeof(CommandLogRecord),
                        Items = commandLogRecords,
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
                        Message = FAILURE_DATA,
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("Get/{userId}/{commandId}/{timestamp}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string loginToken, [FromQuery] string userId, [FromQuery] int commandId, [FromQuery] long timestamp)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    List<CommandLogRecord> commandLogRecords = await _CommandLogService.GetCommandLogs(userId, commandId, timestamp);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemType = typeof(CommandLogRecord),
                        Items = commandLogRecords,
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
                        Message = FAILURE_DATA,
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [Route("Delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] string loginToken, [FromQuery] int id)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    await _CommandLogService.DeleteCommandLog(id);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
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
                        ItemCount = 0,
                        ItemType = typeof(CommandLogRecord),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("CommandLog", "Create", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
