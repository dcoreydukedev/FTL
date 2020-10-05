/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: IViewModel Interface and Interfaces Implementing IViewModel
 ************************************************************************/
namespace FortyThreeLime.Models.ViewModels
{

    /// <summary>
    /// A View Model Class          
    /// </summary>
    public interface IViewModel
    {
    }


    /// <summary>
    /// A View Model Class for the specific model
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IViewModel<TModel> : IViewModel
    {

    }

    /// <summary>
    /// A View Model Class or use in the Reporting App
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.ViewModels.IViewModel" />
    public interface IReportViewModel : IViewModel
    {

    }

    /// <summary>
    /// A View Model Class or use in the Admin App
    /// </summary>
    /// <seealso cref="FortyThreeLime.Models.ViewModels.IViewModel" />
    public interface IAdminViewModel : IViewModel
    {

    }
}
