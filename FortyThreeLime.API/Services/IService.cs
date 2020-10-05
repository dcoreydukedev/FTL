/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/



namespace FortyThreeLime.API.Services
{
    /// <summary>
    /// Implemented by Service Classes
    /// </summary>
    internal interface IService
    {

    }

    /// <summary>
    /// Inherited by classes that provide or manipulate some piece of application data
    /// </summary>
    internal interface IDataService : IService
    {

    }

    /// <summary>
    /// Inherited by classes that provide or manipulate dat for an api controller
    /// </summary>
    internal interface IAPIService : IService { }

    /// <summary>
    ///  Implemented by controller services
    /// </summary>
    internal interface IControllerService<TController> : IService where TController : class
    {

    }

}