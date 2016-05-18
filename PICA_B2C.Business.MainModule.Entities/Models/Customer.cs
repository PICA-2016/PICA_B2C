using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// Customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer Identification.
        /// </summary>
        public string Identification { get; set; }

        /// <summary>
        /// Customer Name.
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// Customer Lastname.
        /// </summary>
        public string LastNames { get; set; }

        /// <summary>
        /// Customer Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Customer Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Credit Card Type.
        /// </summary>
        public string CrediCardType { get; set; }

        /// <summary>
        /// Credit Card Number.
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Zip.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Addres Type.
        /// </summary>
        public string AddresType { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Identifier order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public virtual Order Order { get; set; }

        ///// <summary>
        ///// Identifiers orders.
        ///// </summary>
        //public List<int> OrdersId { get; set; }

        ///// <summary>
        ///// List orders.
        ///// </summary>
        //public virtual ICollection<Order> Orders { get; set; }



    }
}
