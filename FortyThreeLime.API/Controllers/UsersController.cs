using FortyThreeLime.API.Services;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {

        private readonly IUserService _UserService;
        private readonly IAppAuthService _AppAuthService;

        public UsersController(IUserService UserService, IAppAuthService appAuthService)
        {
            this._UserService = UserService;
            this._AppAuthService = appAuthService;
        }


        /// <summary>
        /// Gets All Users 
        /// </summary>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpGet]
        public IActionResult Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    List<User> users = _UserService.GetUsers();

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemCount = users.Count,
                        ItemType = typeof(User),
                        Items = users,
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
                        ItemType = typeof(User),
                        Items = new List<User>(),
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
        /// Gets the Specified User
        /// </summary>
        /// <param name="userId">Id of the User.</param>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpGet("{UserName}")]
        public IActionResult Get(string userId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    User user = _UserService.GetUser(userId);

                    if (user != null)
                    {
                        var ret = new
                        {
                            Success = true,
                            Message = SUCCESS_DATA,
                            ItemType = typeof(User),
                            Item = user,
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
                            ItemType = typeof(User),
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
                        ItemType = typeof(User),
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
        /// Create the Specified User
        /// </summary>
        /// <param name="username">The Name of the User to Create</param>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] string userId, [FromBody] string username, [FromBody] int roleId, [FromBody] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    User user = new User(userId, username, roleId, true, false);
                    user = _UserService.CreateUser(user);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,
                        ItemCount = 1,
                        ItemType = typeof(User),
                        Item = user,
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
                        ItemType = typeof(User),
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

      
        [HttpDelete("{userId}")]
        public IActionResult Delete(string userId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    _UserService.DeleteUser(userId);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,
                        ItemCount = 0,
                        ItemType = typeof(User),
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
                        ItemType = typeof(User),
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
