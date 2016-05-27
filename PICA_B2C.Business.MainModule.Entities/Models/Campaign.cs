using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// Campaign entity.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// Campaign Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Campaign Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Start Date.
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Expiration Date.
        /// </summary>
        public string ExpirationDate { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }
    }
}
