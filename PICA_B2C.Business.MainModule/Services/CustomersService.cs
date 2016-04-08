﻿using PICA_B2C.Business.MainModule.Contracts;
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
                    Names = "Juan",
                    LastNames = "Giraldo",
                    Order = new Order()
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
    }
}
