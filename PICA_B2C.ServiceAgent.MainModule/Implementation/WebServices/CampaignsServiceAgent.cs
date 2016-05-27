using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.ServiceAgent.MainModule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.ServiceAgent.MainModule.Implementation.WebServices
{
    /// <summary>
    /// Class service agent Campaign.
    /// </summary>
    public class CampaignsServiceAgent : ICampaignsServiceAgent
    {
        /// <summary>
        /// Get active campaigns.
        /// </summary>
        public List<Campaign> GetCampaigns()
        {
            var wsCampaigns = new wsAdministrarCampanasReference.administrarCampanasPortTypeClient();
            var resultService = wsCampaigns.wsConsultaCampana("A");

            wsAdministrarCampanasReference.CampanaCons c = resultService.First();
            var res2 = wsCampaigns.wsConsultarProductosXCampana(1, "A");

            List<Campaign> lstCampaigns = resultService == null ? new List<Campaign>() : (from cam in resultService
                                                                                          select new Campaign
                                                                                          {
                                                                                              CampaignId = Convert.ToInt32(cam.IDCAMPANA),
                                                                                              Name = cam.NOMBRE,
                                                                                              Description = cam.DESCRIPCION,
                                                                                              StartDate = cam.FECHAINI == null ? string.Empty : Convert.ToDateTime(cam.FECHAINI).ToString("yyyy/MM/dd"),
                                                                                              ExpirationDate = cam.FECHAVENCIMIENTO == null ? string.Empty : Convert.ToDateTime(cam.FECHAVENCIMIENTO).ToString("yyyy/MM/dd"),
                                                                                              State = cam.ESTADO
                                                                                          }).ToList();

            return lstCampaigns;
        }

        /// <summary>
        /// Get products of a campaign.
        /// </summary>
        /// <param name="campaignId">Campaign identifier.</param>
        /// <returns>Products.</returns>
        public List<Product> GetProductsOfCampaignById(int campaignId)
        {
            var wsCampaigns = new wsAdministrarCampanasReference.administrarCampanasPortTypeClient();
            var resultService = wsCampaigns.wsConsultarProductosXCampana(campaignId, "A");

            wsAdministrarCampanasReference.CampanaConXPro c = resultService.First();
            var res2 = wsCampaigns.wsConsultarProductosXCampana(1, "A");

            List<Product> lstProductos = resultService == null ? new List<Product>() : (from cam in resultService
                                                                                          select new Product
                                                                                          {
                                                                                              Id = Convert.ToInt32(cam.ID),
                                                                                              ProductId = Convert.ToInt32(cam.PRODUCTO_ID),
                                                                                              Name = cam.NOMBRE,
                                                                                              Description = cam.DESCRIPCION,
                                                                                              Category = cam.CATEGORIA,
                                                                                              ListPrice = Convert.ToInt32(cam.PRECIO_LISTA),
                                                                                              Producer = cam.FABRICANTE,
                                                                                              Image = cam.IMAGEN_URL
                                                                                          }).ToList();

            return lstProductos;
        }
    }
}
