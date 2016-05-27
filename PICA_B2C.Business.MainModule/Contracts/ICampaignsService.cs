using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Contracts
{
    /// <summary>
    /// Customer interface campaign.
    /// </summary>
    public interface ICampaignsService
    {
        /// <summary>
        /// Get active campaigns.
        /// </summary>
        List<Campaign> GetCampaigns();

        /// <summary>
        /// Get products of a campaign.
        /// </summary>
        /// <param name="campaignId">Campaign identifier.</param>
        /// <returns>Products.</returns>
        List<Product> GetProductsOfCampaignById(int campaignId);
    }
}
