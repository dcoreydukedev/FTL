/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: IViewModel Interface and Interfaces Implementing IViewModel
 ************************************************************************/
namespace FortyThreeLime.Web.ViewModels
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
    /// A View Model Class for use in the Reporting App
    /// </summary>
    /// <seealso cref="FortyThreeLime.Web.ViewModels.IViewModel" />
    public interface IReportViewModel : IViewModel
    {

    }

    /// <summary>
    /// A View Model Class for use in the Admin App
    /// </summary>
    /// <seealso cref="FortyThreeLime.Web.ViewModels.IViewModel" />
    public interface IAdminViewModel : IViewModel
    {

    }

    /// <summary>
    /// A View Model Class for use in controller ops
    /// </summary>
    /// <seealso cref="FortyThreeLime.Web.ViewModels.IViewModel" />
    public interface IControllerViewModel : IViewModel
    {

    }
}
