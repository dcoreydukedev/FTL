/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/ButtonCommands")]
    [ApiController]
    public class ButtonCommandsController : ApiControllerBase
    {

        private readonly ButtonCommandService _ButtonCommandService;
        private readonly AppAuthService _AppAuthService;

        public ButtonCommandsController()
        {
            this._ButtonCommandService = new ButtonCommandService();
            this._AppAuthService = new AppAuthService();
        }


        /// <summary>
        /// Gets the button command list.
        /// </summary>
        /// <returns>List of ButtonCommand Objects</returns>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }               

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if(_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    List<ButtonCommand> buttonCommands = await _ButtonCommandService.GetButtonCommands();
   
                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemCount = buttonCommands.Count,
                        ItemType = typeof(ButtonCommand),
                        Items = buttonCommands,
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
                        Message = LOGIN_REQUIRED,
                        ItemCount = 0,
                        ItemType = typeof(ButtonCommand),
                        Items = new List<ButtonCommand>(),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("ButtonCommands", "Get", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Gets the button command;
        /// </summary>
        /// <returns>ButtonCommand Object</returns>
        [HttpGet]
        [Route("Get/{commandId}")]
        public async Task<IActionResult> Get(int commandId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
                {
                    ButtonCommand buttonCommand = await _ButtonCommandService.GetButtonCommand(commandId);
                    if(buttonCommand != null)
                    {
                        var ret = new
                        {
                            Success = true,
                            Message = SUCCESS_DATA,
                            ItemType = typeof(ButtonCommand),
                            Item = buttonCommand,
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
                            ItemType = typeof(ButtonCommand),
                            LoginToken = loginToken,
                            Timestamp = new Timestamp().GetTimestamp()
                        };
                        return BadRequest(ret);
                    }
                    
                }
                else
                {
                    var ret = new 
                    {
                        Success = false,
                        Message = LOGIN_REQUIRED,
                        ItemCount = 0,
                        ItemType = typeof(ButtonCommand),
                        LoginToken = loginToken,
                        Timestamp = new Timestamp().GetTimestamp()
                    };
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("ButtonCommands", "Get", ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        

    }
}
