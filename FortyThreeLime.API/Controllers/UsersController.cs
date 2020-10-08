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

        private readonly UserService _UserService;
        private readonly AppAuthService _AppAuthService;

        public UsersController()
        {
            this._UserService = new UserService();
            this._AppAuthService = new AppAuthService();
        }

        /// <summary>
        /// Gets All Users 
        /// </summary>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpGet]
        [Route("Get")]
        public IActionResult Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
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
        [HttpGet]
        [Route("Get/{userId}")]
        public IActionResult Get([FromQuery]string userId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
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
        [HttpGet]
        [Route("Create")]        
        public IActionResult Create([FromQuery] string userId, [FromQuery] string username, [FromQuery] int roleId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
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

      
        [HttpDelete]
        [Route("Delete/{userId}")]
        public IActionResult Delete([FromQuery] string userId, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuthAsync(loginToken).Result == true)
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
