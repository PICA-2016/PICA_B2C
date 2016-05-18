using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.ServiceAgent.MainModule.Contracts
{
    public interface ICustomersServiceAgent
    {
        /// <summary>
        /// Register Customer.
        /// </summary>
        /// <param name="customer">customer to register.</param>
        /// <returns>True if the operation was successful.</returns>
        bool RegisterCustomer(Customer customer);
    }
}
