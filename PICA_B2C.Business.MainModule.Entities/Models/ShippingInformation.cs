using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// ShippingInformation entity.
    /// </summary>
    public class ShippingInformation
    {
        /// <summary>
        /// Credit Card Type.
        /// </summary>
        public string CrediCardType { get; set; }

        /// <summary>
        /// Credit Card Holder.
        /// </summary>
        public string CreditCardHolder { get; set; }

        /// <summary>
        /// Credit Card Number.
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Credi Card Expiration.
        /// </summary>
        public DateTime CrediCardExpiration { get; set; }

        /// <summary>
        /// Recipient Names.
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// Recipient Last Names.
        /// </summary>
        public string LastNames { get; set; }

        /// <summary>
        /// Shipping Address.
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

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
    }
}
