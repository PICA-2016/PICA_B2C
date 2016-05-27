using Microsoft.Practices.Unity;
using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Services;
using PICA_B2C.Infrastructure.CrossCutting.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Infrastructure.CrossCutting.IoCBusiness
{
    /// <summary>
    /// Made with implementation of IoC, Unity for this deployment is used.
    /// </summary>
    public static class IoCFactoryBusiness
    {
        /// <summary>
        /// Dictionary container relations.
        /// </summary>
        private static IDictionary<string, IUnityContainer> containersDictionary;

        /// <summary>
        /// Static constructor which loads the dictionary relationships.
        /// </summary>
        static IoCFactoryBusiness()
        {
            InitContainers();
        }

        /// <summary>
        /// Return a requested instance according to the dictionary of interfaces.
        /// </summary>
        /// <typeparam name="T">Instance type to return.</typeparam>
        /// <returns>Instance of the requested type.</returns>
        public static T Resolve<T>()
        {
            string containerName = Parameter.NameIoCFactory;

            if (String.IsNullOrEmpty(containerName) || String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException("Default Container not found.");
            }

            return Resolve<T>(containerName);
        }

        /// <summary>
        /// Returns the implementation for the required interface.
        /// </summary>
        /// <typeparam name="T">Required interface.</typeparam>
        /// <param name="containerName">Container where the information.</param>
        /// <returns>Implementacion obtenida.</returns>
        public static T Resolve<T>(string containerName)
        {
            if (String.IsNullOrEmpty(containerName) || String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException("Default Container not found.");
            }

            if (!containersDictionary.ContainsKey(containerName))
            {
                throw new InvalidOperationException("Container Not Found");
            }

            IUnityContainer container = containersDictionary[containerName];
            return container.Resolve<T>();
        }

        /// <summary>
        /// Method that initializes the dictionary, to wire relations.
        /// </summary>
        private static void InitContainers()
        {
            containersDictionary = new Dictionary<string, IUnityContainer>();

            // Creates a parent container.
            IUnityContainer rootContainer = new UnityContainer();
            containersDictionary.Add("RootContext", rootContainer);

            // Create a real container, it is called so, by the time of testing put another container.
            IUnityContainer realAppContainer = rootContainer.CreateChildContainer();
            containersDictionary.Add("RealAppContext", realAppContainer);

            ConfigureRootContainer(rootContainer);
        }

        /// <summary>
        /// Sets the main container and logs data types.
        /// </summary>
        /// <param name="container">Container to configure.</param>
        private static void ConfigureRootContainer(IUnityContainer container)
        {
            RegisterServicesBusiness(container);
        }

        /// <summary>
        /// It records data types related to service agents.
        /// </summary>
        /// <param name="container">Container to configure.</param>
        private static void RegisterServicesBusiness(IUnityContainer container)
        {
            container.RegisterType<ICustomersService, CustomersService>(new TransientLifetimeManager());
            container.RegisterType<IItemsService, ItemsService>(new TransientLifetimeManager());
            container.RegisterType <IOrdersService, OrdersService> (new TransientLifetimeManager());
            container.RegisterType <IProductsService, ProductsService> (new TransientLifetimeManager());
            container.RegisterType<ICampaignsService, CampaignsService>(new TransientLifetimeManager());
        }

        
    }
}
