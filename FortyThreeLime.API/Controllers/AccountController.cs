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

namespace FortyThreeLime.API.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {

        private readonly IConfiguration _Configuration;
        private readonly IUserService _UserService;
        private readonly IRoleService _RoleService;
        private readonly IApplicationService _AppService;
        private readonly IAppAuthService _AppAuthService;

        private User _User = null;
        private Role _Role = null;
        private Application _App = null;

        private string _Token = string.Empty;



        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController(IConfiguration configuration, IUserService userService, IRoleService roleService, IApplicationService appService, IAppAuthService appAuthService)
        {
            this._Configuration = configuration;
            this._UserService = userService;
            this._RoleService = roleService;
            this._AppService = appService;
            this._App = _AppService.GetApplication(_Configuration["ApplicationName"].ToString());
            this._AppAuthService = appAuthService;
        }

        /// <summary>
        /// Login API for Authenticate user
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
        public IActionResult Login([FromQuery]string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) { return BadRequest(USERID_NULL); }

                if (!_UserService.UserExists(userId)) { return BadRequest(USERID_INVALID); }

                // Login User
                this._User = _UserService.LoginUser(userId);

                // Get Role For User
                this._Role = _RoleService.GetRole(_User.RoleId);

                // Create a Login Token
                this._Token = GetLoginToken();

                // Add Login Token To Session
                HttpContext.Session.SetString("LoginToken", this._Token);

                // Create Return Data Object
                LoginData loginData = new LoginData(this._Token, true, this._App, this._User, this._Role, DateTime.Now, DateTime.Now.AddDays(1), null);

                // Create AppAuth Record
                AppAuth appAuth = new AppAuth(loginData);
                _AppAuthService.CreateAppAuth(appAuth);


                return Ok(loginData);

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
        public IActionResult Logout([FromQuery] string loginToken)
        {

            try
            {
                if (string.IsNullOrEmpty(loginToken)) { return BadRequest(LOGIN_TOKEN_NULL); }

                if (!_AppAuthService.IaValidAppAuth(loginToken)) { return BadRequest(LOGIN_TOKEN_INVALID); }

                LoginData loginData = null;

                AppAuth appAuth = _AppAuthService.GetAppAuth(loginToken);

                // Logout User
                this._User = _UserService.LogoutUser(appAuth.UserId);

                // Get Role For User
                this._Role = _RoleService.GetRole(appAuth.RoleId);

                // Create a Login Token
                this._Token = appAuth.LoginToken;

                // Add Login Token To Session
                string testToken = HttpContext.Session.GetString("LoginToken");

                // Check if Session Value matches Stored Value
                if (this._Token == testToken)
                {
                    // Remove Login Token From Session
                    HttpContext.Session.Remove("LoginToken");

                    // Create Return Data Object
                    loginData = new LoginData
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
                    _AppAuthService.DeleteAppAuth(appAuth.Id);
                    return Ok(loginData);
                }
                else
                {
                   var ex = new Exception("The Values for the Login Tokens Do Not Match");
                   return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        #region Helpers

        /// <summary>
        /// Create a Custom Login String Key
        /// </summary>
        private string GetLoginToken()
        {
            StringKeyGeneratorOptions opts = new StringKeyGeneratorOptions() { Length = 28, IncludeCaps = true, IncludeDigits = true, IncludeSpecialChars= false };
            StringKeyGenerator gen = new StringKeyGenerator(opts);
            return gen.Generate().Trim();
        }

        #endregion
    }
}
