using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.ServiceAgent.MainModule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.ServiceAgent.MainModule.Implementation.WebServices
{
    public class CustomersServiceAgent : ICustomersServiceAgent
    {
        /// <summary>
        /// Register Customer.
        /// </summary>
        /// <param name="customer">customer to register.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool RegisterCustomer(Customer customer)
        {
            return true;
        }
    }
}
