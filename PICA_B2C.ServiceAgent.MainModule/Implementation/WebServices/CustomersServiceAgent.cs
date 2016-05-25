using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Infrastructure.CrossCutting.Core.Parameters;
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

        /// <summary>
        /// Register Customer.
        /// </summary>
        /// <param name="customer">customer to register.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool RegisterCustomer(Customer customer)
        {
            var wsCustomer = new wsInsertaClientesDSReference.insertaClientesDSPortTypeClient();

            var resultService = wsCustomer.wsInsertarCliente(
                customer.Identification,
                customer.Names,
                customer.LastNames,
                customer.Phone,
                customer.Email,
                customer.Password,
                customer.CrediCardType,
                customer.CreditCardNumber,
                customer.Status,
                customer.Street,
                customer.State,
                customer.Zip,
                customer.Country,
                customer.AddresType,
                customer.City);

            //resultService.wsInsertarCliente.customer customer = new resultService.wsInsertarCliente.customer();
            //resultService.wsInsertarCliente.RegisterCustomer(null);

            return true;
        }
    }
}
