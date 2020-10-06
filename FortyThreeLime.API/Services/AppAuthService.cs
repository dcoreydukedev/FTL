/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FortyThreeLime.API.Services
{
    public interface IAppAuthService : IAPIService
    {
        AppAuth CreateAppAuth(AppAuth a);
        AppAuth GetAppAuth(int id);
        AppAuth GetAppAuth(string loginToken);
        List<AppAuth> GetAppAuths();
        void UpdateAppAuth(AppAuth u);
        void DeleteAppAuth(int id);
        bool IaValidAppAuth(string loginToken);
        bool IsActiveAppAuth(string loginToken);
    }

    /// <summary>
    /// Provides AppAuth Data
    /// </summary>
    public sealed class AppAuthService : IAppAuthService
    {
        private ApplicationDbContext _context;
        private ApplicationRepository<AppAuth> _repo;


        /// <summary>
        /// Initializes a new instance of the <see cref="AppAuthService"/> class.
        /// </summary>
        /// <param name="repo">The AppAuth Repository.</param>
        public AppAuthService(ApplicationDbContext context, ApplicationRepository<AppAuth> repo)
        {
            this._context = context;
            this._repo = repo;
        }


        /// <summary>
        /// Gets the AppAuths.
        /// </summary>
        /// <returns>List of AppAuths</returns>
        public List<AppAuth> GetAppAuths()
        {
            return (List<AppAuth>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the AppAuth.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified AppAuth</returns>
        public AppAuth GetAppAuth(int id)
        {
            return _repo.GetById(id);
        }


        /// <summary>
        /// Gets the AppAuth.
        /// </summary>
        /// <returns>The Specified AppAuth</returns>
        public AppAuth GetAppAuth(string loginToken)
        {
            return _context.AppAuth.Where(a => a.LoginToken == loginToken).SingleOrDefault();
        }

        /// <summary>
        /// Creates the AppAuth.
        /// </summary>
        /// <param name="u">The AppAuth to create</param>
        /// <returns>The Newly Created AppAuth</returns>
        public AppAuth CreateAppAuth(AppAuth a)
        {
            _repo.Add(a);
            return GetAppAuth(a.Id);
        }


        /// <summary>
        /// Updates the AppAuth.
        /// </summary>
        /// <param name="u">The AppAuth</param>
        public void UpdateAppAuth(AppAuth u)
        {
            _repo.Update(u);
        }

        /// <summary>
        /// Deletes the AppAuth.
        /// </summary>
        /// <param name="id">The id of the AppAuth</param>
        public void DeleteAppAuth(int id)
        {
            _repo.Remove(id);
        }

        /// <summary>
        /// Is the AppAuth Record Valid
        /// </summary>
        public bool IaValidAppAuth(string loginToken)
        {
            AppAuth a = GetAppAuth(loginToken);
            return a == null;
        }

        /// <summary>
        /// Is The AppAuth Record Active?
        /// </summary>
        public bool IsActiveAppAuth(string loginToken)
        {
            AppAuth a = GetAppAuth(loginToken);
            return ((a != null) && (a.LoginTokenActive == true));
        }

    }
}