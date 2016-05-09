using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.DataPersistence.MainModule.Contracts;
using PICA_B2C.Infrastructure.CrossCutting.Core.Parameters;
using PICA_B2C.Infrastructure.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Customer.
    /// </summary>
    public class CustomersService : ICustomersService
    {
        /// <summary>
        /// Validate credentials.
        /// </summary>
        /// <param name="userName">Customer user name.</param>
        /// <param name="password">Customer password.</param>
        /// <returns>Returns true if the credentials are valid.</returns>
        public Customer Authenticate(string userName, string password)
        {
            try
            {
                if (Parameter.CustomerUserName.Equals(userName) && Parameter.CustomerPassword.Equals(password))
                {
                    Customer customer = new Customer()
                    {
                        CustomerId = 1,
                        Names = "Liliana",
                        LastNames = "Giraldo",
                        Order = new Order
                        {
                            Items = new List<Item>()
                        },
                    };

                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Se produjo un error al autenticar el cliente", ex);
            }
        }
    }
}
