/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortyThreeLime.API.Services
{
    public interface IAppAuthService : IAPIService, IDataService
    {
        Task<AppAuth> CreateAppAuth(AppAuth a);
        AppAuthDTO CreateAppAuthDTOFromAppAuthEntity(AppAuth appAuth);
        Task DeleteAppAuth(int id);
        Task<AppAuth> GetAppAuth(int id);
        Task<AppAuth> GetAppAuth(string loginToken);
        Task<List<AppAuth>> GetAppAuths();
        Task<AppAuthService> Init();
        Task<bool> IsActiveAppAuthAsync(string loginToken);
        Task<bool> IsValidAppAuth(string loginToken);
        Task UpdateAppAuth(AppAuth u);
    }


    /// <summary>
    /// Provides AppAuth Data
    /// </summary>
    public sealed class AppAuthService : IAppAuthService
    {
        private ApplicationDbContext _context;
        private Repository<AppAuth> _repo;
        private UserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppAuthService"/> class.
        /// </summary>
        public AppAuthService()
        {
            this._context = ApplicationDbContext.Create();
            this._repo = new Repository<AppAuth>();
            this._userService = new UserService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppAuthService"/> class.
        /// </summary>
        /// <param name="context">The Application DB Context</param>
        /// <param name="repo">The AppAuth Repository.</param>
        public AppAuthService(ApplicationDbContext context, Repository<AppAuth> repo)
        {
            this._context = context;
            this._repo = repo;
            this._userService = new UserService();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public async Task<AppAuthService> Init()
        {
            await CleanupAppAuths();
            return this;
        }

        /// <summary>
        /// Gets the AppAuths.
        /// </summary>
        /// <returns>List of AppAuths</returns>
        public async Task<List<AppAuth>> GetAppAuths()
        {
            return (List<AppAuth>)await _repo.GetAllAsync();
        }

        /// <summary>
        /// Gets the AppAuth.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified AppAuth</returns>
        public async Task<AppAuth> GetAppAuth(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets the AppAuth.
        /// </summary>
        /// <returns>The Specified AppAuth</returns>
        public async Task<AppAuth> GetAppAuth(string loginToken)
        {
            return await _context.AppAuth.SingleAsync(a => a.LoginToken == loginToken);
        }

        /// <summary>
        /// Creates the AppAuth.
        /// </summary>
        /// <param name="a">The AppAuth to create</param>
        /// <returns>The Newly Created AppAuth</returns>
        public async Task<AppAuth> CreateAppAuth(AppAuth a)
        {
            await _repo.AddAsync(a);
            return await GetAppAuth(a.Id);
        }

        /// <summary>
        /// Updates the AppAuth.
        /// </summary>
        /// <param name="u">The AppAuth</param>
        public async Task UpdateAppAuth(AppAuth u)
        {
            await _repo.UpdateAsync(u);
        }

        /// <summary>
        /// Deletes the AppAuth.
        /// </summary>
        /// <param name="id">The id of the AppAuth</param>
        public async Task DeleteAppAuth(int id)
        {
            await _repo.DeleteAsync(id);
        }

        /// <summary>
        /// Is the AppAuth Record Valid
        /// </summary>
        public async Task<bool> IsValidAppAuth(string loginToken)
        {
            AppAuth a = await _context.AppAuth.SingleAsync(a => a.LoginToken == loginToken);
            return a != null;
        }

        /// <summary>
        /// Is The AppAuth Record Active?
        /// </summary>
        public async Task<bool> IsActiveAppAuthAsync(string loginToken)
        {
            AppAuth a = await GetAppAuth(loginToken);
            return ((a != null) && (a.LoginTokenActive == true));
        }

        /// <summary>
        /// Creates the application authentication DTO from application authentication entity.
        /// </summary>
        /// <param name="appAuth">The application authentication entity</param>
        /// <returns></returns>
        public AppAuthDTO CreateAppAuthDTOFromAppAuthEntity(AppAuth appAuth)
        {
            DateTime? logoutTime = string.IsNullOrEmpty(appAuth.LogoutTime) ? null : (DateTime?)DateTime.Parse(appAuth.LogoutTime);

            AppAuthDTO aa = new AppAuthDTO
            (
                appAuth.LoginToken,
                appAuth.LoginTokenActive,
                (Application)_context.Applications.Single(app => app.Id == appAuth.ApplicationId),
                (User)_context.Users.Single(u => u.UserId == appAuth.UserId),
                (Role)_context.Roles.Single(r => r.Id == appAuth.RoleId),
                DateTime.Parse(appAuth.LoginTime),
                DateTime.Parse(appAuth.LoginExpires),
                logoutTime
            );
            return aa;

        }

        /// <summary>
        /// Cleanup Expired AppAuths; Logout The User and Delete the Record
        /// </summary>
        private async Task CleanupAppAuths()
        {
            await Task.Run(async () =>
            {
                List<AppAuth> _l = await GetAppAuths();
                foreach (AppAuth a in _l)
                {
                    if (DateTime.Parse(a.LoginExpires) <= DateTime.Now)
                    {
                        AppAuthDTO appAuthDTO = CreateAppAuthDTOFromAppAuthEntity(a);
                        User u = appAuthDTO.User;
                        await _userService.LogoutUserAsync(u.UserId);
                        await DeleteAppAuth(a.Id);
                    }
                }
            });

        }

    }
}