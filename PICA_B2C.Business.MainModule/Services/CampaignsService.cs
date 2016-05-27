using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Infrastructure.CrossCutting.IoC;
using PICA_B2C.ServiceAgent.MainModule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Campaign.
    /// </summary>
    public class CampaignsService : ICampaignsService
    {
        /// <summary>
        /// Get active campaigns.
        /// </summary>
        public List<Campaign> GetCampaigns()
        {
            try
            {
                return IoCFactory.Resolve<ICampaignsServiceAgent>().GetCampaigns();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener las campañas", ex);
            }
        }

        /// <summary>
        /// Get products of a campaign.
        /// </summary>
        /// <param name="campaignId">Campaign identifier.</param>
        /// <returns>Products.</returns>
        public List<Product> GetProductsOfCampaignById(int campaignId)
        {
            try
            {
                return IoCFactory.Resolve<ICampaignsServiceAgent>().GetProductsOfCampaignById(campaignId);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener los productos de la campaña", ex);
            }
        }
    }
}
