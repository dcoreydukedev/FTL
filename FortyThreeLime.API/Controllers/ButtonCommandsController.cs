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

namespace FortyThreeLime.API.Controllers
{
    [Route("api/ButtonCommands")]
    [ApiController]
    public class ButtonCommandsController : ApiControllerBase
    {

        private readonly IButtonCommandService _ButtonCommandService;
        private readonly IAppAuthService _AppAuthService;

        public ButtonCommandsController(IButtonCommandService buttonCommandService, IAppAuthService appAuthService)
        {
            this._ButtonCommandService = buttonCommandService;
            this._AppAuthService = appAuthService;
        }


        /// <summary>
        /// Gets the button command list.
        /// </summary>
        /// <returns>List of ButtonCommand Objects</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }               

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if(_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    List<ButtonCommand> buttonCommands = _ButtonCommandService.GetCommands();
   
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Gets the button command;
        /// </summary>
        /// <returns>ButtonCommand Object</returns>
        [HttpGet("{commandId}")]
        public IActionResult Get(int commandId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    ButtonCommand buttonCommand = _ButtonCommandService.GetCommand(commandId);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        

    }
}
