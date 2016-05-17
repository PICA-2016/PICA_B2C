using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Contracts
{
    /// <summary>
    /// Customer interface service.
    /// </summary>
    public interface ICustomersService
    {
        /// <summary>
        /// Validate credentials.
        /// </summary>
        /// <param name="userName">Customer user name.</param>
        /// <param name="password">Customer password.</param>
        /// <returns>Returns true if the credentials are valid.</returns>
        Customer Authenticate(string userName, string password);

        /// <summary>
        /// Register Customer.
        /// </summary>
        /// <param name="customer">customer to register.</param>
        /// <returns>Registered customer.</returns>
        Customer RegisterCustomer(Customer customer);
    }
}
