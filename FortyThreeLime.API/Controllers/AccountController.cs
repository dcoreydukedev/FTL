/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.API.Services;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {

        private UserService userService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
        {
            this.userService = new UserService();

        }

        /// <summary>
        /// Login API for Authenticate user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromQuery]string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) { return BadRequest("Invalid User PIN! User Pin cannot be null!"); }

                //Get user
                User u = userService.GetUser(userId);
            
                if (u != null)
                {
                    u = userService.LoginUser(userId);
                    //Send Json object
                    return Ok(u);
                }
                else
                {
                    return BadRequest("User Not Found!");               
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Logout API for Authenticate user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Logout([FromQuery] string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) { return BadRequest("Invalid User PIN! User Pin cannot be null!"); }

                //Get user
                User u = userService.GetUser(userId);

                if (u != null)
                {
                    u = userService.LogoutUser(userId);
                    //Send Json object
                    return Ok(u);
                }
                else
                {
                    return BadRequest("User Not Found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
