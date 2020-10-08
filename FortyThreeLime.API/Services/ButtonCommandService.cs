/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FortyThreeLime.API.Services
{
    public interface IButtonCommandService : IAPIService, IDataService
    {
        Task CreateButtonCommand(ButtonCommand cmd);
        Task DeleteButtonCommand(int id);
        Task<ButtonCommand> GetButtonCommand(int commandId);
        Task<ButtonCommand> GetButtonCommandAsync(string command);
        Task<List<ButtonCommandCategory>> GetButtonCommandCategories();
        Task<List<ButtonCommand>> GetButtonCommands();
    }


    /// <summary>
    /// Service to Provide ButtonCommand Data to An API Controller
    /// </summary>
    public sealed class ButtonCommandService : IButtonCommandService
    {

        private ApplicationDbContext _context;
        private Repository<ButtonCommand> _buttonCommandRepo;
        private Repository<ButtonCommandCategory> _buttonCommandCategoryRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandService"/> class.
        /// </summary>
        public ButtonCommandService()
        {
            this._context = ApplicationDbContext.Create();
            this._buttonCommandRepo = new Repository<ButtonCommand>();
            this._buttonCommandCategoryRepo = new Repository<ButtonCommandCategory>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonCommandService"/> class.
        /// </summary>
        public ButtonCommandService(ApplicationDbContext context, Repository<ButtonCommand> repo, Repository<ButtonCommandCategory> repo2)
        {
            this._context = context;
            this._buttonCommandRepo = repo;
            this._buttonCommandCategoryRepo = repo2;
        }

        /// <summary>
        /// Gets the button commands asynchronously.
        /// </summary>
        public async Task<List<ButtonCommand>> GetButtonCommands()
        {
            return (List<ButtonCommand>)await _buttonCommandRepo.GetAllAsync();
        }

        /// <summary>
        /// Gets the button command asynchronously.
        /// </summary>
        /// <param name="commandId">The command identifier.</param>
        public async Task<ButtonCommand> GetButtonCommand(int commandId)
        {
            return await _context.ButtonCommands.SingleAsync(x => x.CommandId == commandId);
        }

        /// <summary>
        /// Gets the button command asynchronously.
        /// </summary>
        /// <param name="command">The Command</param>
        public async Task<ButtonCommand> GetButtonCommandAsync(string command)
        {
            return await _context.ButtonCommands.SingleAsync(x => x.Command == command);
        }

        /// <summary>
        /// Gets the button command categories.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ButtonCommandCategory>> GetButtonCommandCategories()
        {
            return (List<ButtonCommandCategory>)await _buttonCommandCategoryRepo.GetAllAsync();
        }

        /// <summary>
        /// Creates a button command.
        /// </summary>
        public async Task CreateButtonCommand(ButtonCommand cmd)
        {
            await _buttonCommandRepo.AddAsync(cmd);
        }

        /// <summary>
        /// Deletes the button command.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteButtonCommand(int id)
        {
            await _buttonCommandRepo.DeleteAsync(id);
        }
    }
}