using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Infrastructure.CrossCutting.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service User.
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
            if (Parameter.CustomerUserName.Equals(userName) && Parameter.CustomerPassword.Equals(password))
            {
                Customer customer = new Customer()
                {
                    CustomerId = 1,
                    Names = "Andres",
                    LastNames = "Fernandez",
                    Order = new Order()
                    {
                        Items = new List<Item>()
                    },
                    //Orders = new List<Order>(),
                };

                //TODO: quitar, solo para prueba.
                customer.Order.Items.Add(new Item { ItemId = 1, ProductId = 1, Quantity = 1 });
                customer.Order.Items.Add(new Item { ItemId = 2, ProductId = 2, Quantity = 3 });

                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}
