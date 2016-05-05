using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.DataPersistence.MainModule.Contracts;
using PICA_B2C.Infrastructure.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Item.
    /// </summary>
    public class ItemsService : IItemsService
    {
        /// <summary>
        /// Get the items of a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>List items.</returns>
        public List<Item> GetItemsByCustomer(int customerId)
        {
            try
            {
                return IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
            }
            catch(Exception ex)
            {
                throw new Exception("Se produjo un error al consultar los items del cliente", ex);
            }
        }
    }
}
