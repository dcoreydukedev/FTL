/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/



namespace FortyThreeLime.Web.Services
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
    ///  Implemented by controller services
    /// </summary>
    internal interface IControllerService<TController> : IService where TController : class
    {

    }

    /// <summary>
    /// Implemented by controller services
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    /// <seealso cref="IControllerService{TController}" />
    internal interface IAPIControllerService<TController> : IControllerService<TController> where TController : class
    {

    }

    /// <summary>
    /// Implemented by services that serve 2 controllers
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    /// <typeparam name="TController2">The type of the controller2.</typeparam>
    /// <seealso cref="IControllerService{TController}" />
    internal interface IAPIControllerService<TController, TController2> : IControllerService<TController>
        where TController : class
        where TController2 : class
    {

    }

}