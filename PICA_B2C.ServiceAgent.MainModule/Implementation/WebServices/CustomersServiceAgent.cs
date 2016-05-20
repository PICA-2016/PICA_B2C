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
            var wsInsertarCliente = new
            {
                CUSTOMERCEDULA_IN = customer.Identification,
                FNAME_IN = customer.Names,
                LNAME_IN = customer.LastNames,
                PHONENUMBER_IN = customer.Phone,
                EMAIL_IN = customer.Email,
                PASSWORD_IN = customer.Password,
                CREDITCARDTYPE_IN = customer.CrediCardType,
                CREDITCARDNUMBER_IN = customer.CreditCardNumber,
                STATUS_IN = customer.Status,
                STREET_IN = customer.Street,
                STATE_IN = customer.State,
                ZIP_IN = customer.Zip,
                COUNTRY_IN = customer.Country,
                ADDRESTYPE_IN = customer.AddresType,
                CITY_IN = customer.City          
            };

            return true;
        }
    }
}
