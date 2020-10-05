/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: IViewModel Interface and Interfaces Implementing IViewModel
 ************************************************************************/
using FortyThreeLime.API.Controllers;
namespace FortyThreeLime.API.ViewModels
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
    /// A View Model Class for use in controller ops
    /// </summary>
    /// <seealso cref="FortyThreeLime.API.ViewModels.IViewModel" />
    public interface IControllerViewModel : IViewModel
    {

    }

    /// <summary>
    /// A View Model Class for use in controller ops
    /// </summary>
    /// <seealso cref="FortyThreeLime.API.ViewModels.IViewModel" />
    public interface IControllerViewModel<TController> : IViewModel where TController : ApiControllerBase
    {

    }

}
