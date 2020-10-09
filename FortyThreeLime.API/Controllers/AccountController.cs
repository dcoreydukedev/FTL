/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.API.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Mime;

namespace FortyThreeLime.API.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {

        private readonly IConfiguration _Configuration;
        private readonly UserService _UserService;
        private readonly RoleService _RoleService;
        private readonly ApplicationService _AppService;
        private readonly AppAuthService _AppAuthService;

        private User _User = null;
        private Role _Role = null;
        private Application _App = null;

        private string _Token = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController(IConfiguration configuration)
        {
            this._Configuration = configuration;
            this._UserService = new UserService();
            this._RoleService = new RoleService();
            this._AppService = new ApplicationService();
            this._App = _AppService.GetApplication(_Configuration["ApplicationName"].ToString());
            this._AppAuthService = new AppAuthService();
        }


        /// <summary>
        /// Login API for Authenticating Users
        /// </summary>
        /// <param name="userId">
        /// The 4 Character User Id
        /// </param>
        /// <returns>
        /// Successful Login: Status Code 202 and Login Data Object
        /// Bad Requests: User Not Found, UserId is Null or Empty
        /// Login Failure on Error: Status Code 500 and Exception
        /// </returns>
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromQuery] string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) { return BadRequest(USERID_NULL); }

                if (!_UserService.UserExists(userId)) { return BadRequest(USERID_INVALID); }               

                // Login User
                this._User = await _UserService.LoginUserAsync(userId);

                // Get Role For User
                this._Role = await _RoleService.GetRoleAsync(_User.RoleId);

                // Create a Login Token
                this._Token = GetLoginToken();

                // Create Application Authentication DTO
                // Login Expires 12 hours from creation
                AppAuthDTO appAuthDTO = new AppAuthDTO(this._Token, true, this._App, this._User, this._Role, DateTime.Now, DateTime.Now.AddHours(12), null);

                // Create AppAuth Record
                AppAuth appAuth = new AppAuth(appAuthDTO);
                await _AppAuthService.CreateAppAuth(appAuth);

                // Log the Action
                string logmsg = String.Format("User {0} | {1} has logged in", _User.UserId, _User.Username);
                await LogAction("Account", "Login", logmsg);

                // Return Status code 200 Success + AppAuthDTO
                return Ok(appAuthDTO);

            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("Account", "Login", ex);

                // Return Status Code 500 + exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Login API for Authenticating Users
        /// </summary>
        /// <param name="loginToken">
        /// The login Token created when the user logged in
        /// </param>
        /// <returns>
        /// Successful Login: Status Code 202 and Login Data Object
        /// Bad Requests: User Not Found, UserId is Null or Empty
        /// Login Failure on Error: Status Code 500 and Exception
        /// </returns>
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromQuery] string loginToken)
        {

            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IsValidAppAuth(loginToken).Result) { return BadRequest(LOGIN_TOKEN_INVALID); }

                AppAuthDTO appAuthDTO = null;

                AppAuth appAuth = await _AppAuthService.GetAppAuth(loginToken);

                // Logout User
                this._User = await _UserService.LogoutUserAsync(appAuth.UserId);

                // Get Role For User
                this._Role = await _RoleService.GetRoleAsync(appAuth.RoleId);

                // Create a Login Token
                this._Token = appAuth.LoginToken;

                // Create Return Data Object
                appAuthDTO = new AppAuthDTO
                (
                    this._Token,
                    false,
                    this._App,
                    this._User,
                    this._Role,
                    DateTime.Parse(appAuth.LoginTime),
                    DateTime.Parse(appAuth.LoginExpires),
                    DateTime.Now
                );

                // Delete AppAuth Record
                await _AppAuthService.DeleteAppAuth(appAuth.Id);

                // Log the Action
                string logmsg = String.Format("User {0} | {1} has logged out", _User.UserId, _User.Username);
                await LogAction("Account", "Logout", logmsg);

                // Return Status code 200 Success + LoginData
                return Ok(appAuthDTO);

            }
            catch (Exception ex)
            {
                // Log the Exception
                await LogError("Account", "Logout", ex);

                // Return Status Code 500 + exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        #region Helpers

        /// <summary>
        /// Create a Custom Login String Key
        /// </summary>
        private string GetLoginToken()
        {
            StringKeyGeneratorOptions opts = new StringKeyGeneratorOptions() { Length = 28, IncludeCaps = true, IncludeDigits = true, IncludeSpecialChars = false };
            StringKeyGenerator gen = new StringKeyGenerator(opts);
            return gen.Generate().Trim();
        }

        #endregion
    }
}
