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
    /// <summary>
    /// Provides Application Data
    /// </summary>
    public interface IApplicationService : IAPIService
    {
        Application CreateApplication(Application a);
        Application GetApplication(int id);
        Application GetApplication(string applicationName);
        List<Application> GetApplications();
        void UpdateApplication(Application u);
    }

    /// <summary>
    /// Provides Application Data
    /// </summary>
    public sealed class ApplicationService : IApplicationService
    {
        private ApplicationDbContext _context;
        private Repository<Application> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class.
        /// </summary>
        public ApplicationService()
        {
            _context = ApplicationDbContext.Create();
            _repo = new Repository<Application>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class.
        /// </summary>
        /// <param name="context">The Application DB Context</param>
        /// <param name="repo">The Application Repository.</param>
        public ApplicationService(ApplicationDbContext context, Repository<Application> repo)
        {
            this._context = context;
            this._repo = repo;
        }


        /// <summary>
        /// Gets the Applications.
        /// </summary>
        /// <returns>List of Applications</returns>
        public List<Application> GetApplications()
        {
            return (List<Application>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the Application.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified Application</returns>
        public Application GetApplication(int id)
        {
            return _repo.GetById(id);
        }


        /// <summary>
        /// Gets the Application.
        /// </summary>
        /// <param name="applicationName">The name of the application</param>
        /// <returns>The Specified Application</returns>
        public Application GetApplication(string applicationName)
        {
            return _context.Applications.Where(a => a.AppName == applicationName).SingleOrDefault();
        }

        /// <summary>
        /// Creates the Application.
        /// </summary>
        /// <param name="a">The Application to create</param>
        /// <returns>The Newly Created Application</returns>
        public Application CreateApplication(Application a)
        {
            _repo.Add(a);
            return GetApplication(a.Id);
        }


        /// <summary>
        /// Updates the Application.
        /// </summary>
        /// <param name="u">The Application</param>
        public void UpdateApplication(Application u)
        {
            _repo.Update(u);
        }

        /// <summary>
        /// Deletes the Application.
        /// </summary>
        /// <param name="id">The id of the Application</param>
        public void DeleteApplication(int id)
        {
            _repo.Delete(id);
        }

    }
}