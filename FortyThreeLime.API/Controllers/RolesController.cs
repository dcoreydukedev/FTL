using FortyThreeLime.API.Services;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ApiControllerBase
    {

        private readonly RoleService _RoleService;
        private readonly AppAuthService _AppAuthService;

        public RolesController()
        {
            this._RoleService = new RoleService();
            this._AppAuthService = new AppAuthService();
        }


        /// <summary>
        /// Gets All Roles 
        /// </summary>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpGet]
        [Route("Get")]
        public IActionResult Get([FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    List<Role> roles = _RoleService.GetAllRoles();

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_DATA,
                        ItemCount = roles.Count,
                        ItemType = typeof(Role),
                        Items = roles,
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
                        ItemType = typeof(Role),
                        Items = new List<Role>(),
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
        /// Gets the Specified Role
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpGet]
        [Route("Get/{roleName}")]
        public IActionResult Get(string roleName, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    Role role = _RoleService.GetRole(roleName);

                    if (role != null)
                    {
                        var ret = new
                        {
                            Success = true,
                            Message = SUCCESS_DATA,
                            ItemType = typeof(Role),
                            Item = role,
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
                            ItemType = typeof(Role),
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
                        ItemType = typeof(Role),
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
        /// Create the Specified Role
        /// </summary>
        /// <param name="roleName">The Name of the Role to Create</param>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpPost]
        [Route("Create")]     
        public IActionResult Create([FromBody] string roleName, string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    Role role = _RoleService.CreateRole(roleName);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,
                        ItemCount = 1,
                        ItemType = typeof(Role),
                        Item = role,
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
                        ItemType = typeof(Role),
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
        /// Delete the Specified Role
        /// </summary>
        /// <param name="roleName">The Name of the Role to Delete</param>
        /// <param name="loginToken">Token Given to User Upon Successful Login</param>
        [HttpDelete]
        [Route("Delete/{roleName}")]
        public IActionResult Delete(string roleName, [FromQuery] string loginToken)
        {
            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                if (_AppAuthService.IsActiveAppAuth(loginToken) == true)
                {
                    _RoleService.DeleteRole(roleName);

                    var ret = new
                    {
                        Success = true,
                        Message = SUCCESS_ACTION,
                        ItemCount = 0,
                        ItemType = typeof(Role),
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
                        ItemType = typeof(Role),
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
