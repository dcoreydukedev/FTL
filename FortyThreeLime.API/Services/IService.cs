/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/



namespace FortyThreeLime.API.Services
{
    /// <summary>
    /// Implemented by Service Classes
    /// </summary>
    public interface IService
    {

    }

    /// <summary>
    /// Inherited by classes that provide or manipulate some piece of application data
    /// </summary>
    public interface IDataService : IService
    {

    }

    /// <summary>
    /// Inherited by classes that provide or manipulate data for an api controller
    /// </summary>
    public interface IAPIService : IService { }

    /// <summary>
    ///  Implemented by controller services
    /// </summary>
    public interface IControllerService<TController> : IService where TController : class
    {

    }

}