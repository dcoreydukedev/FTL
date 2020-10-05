/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.API.Controllers;
using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FortyThreeLime.API.Services
{
    /// <summary>
    /// Service to Provide ButtonCommand Data to An API Controller
    /// </summary>
    internal sealed class ButtonCommandService : IAPIService
    {

        private ApplicationDbContext _context;
        private ApplicationRepository<ButtonCommand> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandService"/> class.
        /// </summary>
        public ButtonCommandService()
        {
            this._context = new ApplicationDbContext();
            this._repo = new ApplicationRepository<ButtonCommand>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandService"/> class.
        /// </summary>
        /// <param name="repo">The ButtonCommand Repository.</param>
        public ButtonCommandService(ApplicationRepository<ButtonCommand> repo)
        {
            this._context = new ApplicationDbContext();
            this._repo = repo;
        }


        /// <summary>
        /// Gets the commands.
        /// </summary>
        public List<ButtonCommand> GetCommands()
        {
            return (List<ButtonCommand>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="commandId">The command identifier.</param>
        public ButtonCommand GetCommand(int commandId)
        {
            return _context.ButtonCommands.Where(x => x.CommandId == commandId).SingleOrDefault();
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public ButtonCommand GetCommand(string command)
        {
            return _context.ButtonCommands.Where(x => x.Command == command).SingleOrDefault();
        }

        //TODO: Add Create, CreateMany, Delete, and Update Methods
    }
}