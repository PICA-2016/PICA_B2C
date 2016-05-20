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
    /// Class service agent Order.
    /// </summary>
    public class OrdersServiceAgent : IOrdersServiceAgent
    {
        /// <summary>
        /// Get order by customer id.
        /// </summary>
        /// <param name="customerId">Identifier customer.</param>
        /// <param name="productsId">List of productIds.</param>
        /// <returns>Order.</returns>
        public Order GetOrderByCustomerId(int customerId, List<int> productsId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// process the order.
        /// </summary>
        /// <param name="order">Order to process.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool ProcessOrder(Order order)
        {
            var BPEL_KSRequest = new 
            {
                tipoTC = order.ShippingInformation.CrediCardType,
                tarjeta = new
                {
                    titularTC = order.ShippingInformation.CreditCardHolder,
                    numeroTC = order.ShippingInformation.CreditCardNumber,
                    expiracion = order.ShippingInformation.CrediCardExpiration,
                },
                clienteID = order.CustomerId,
                fechaOrden = DateTime.Now,
                montoOrden = order.Items.Sum(itm => itm.Product.ListPrice * itm.Quantity),
                estadoOrden = string.Empty,
                comentario = "Excelente producto",
                items = order.Items.Select(itm => new
                {
                    ProductoID = itm.Product.ProductId,
                    nombre = itm.Product.Name,
                    referencia = itm.Product.Category,  //TODO: verificar
                    precio = itm.Product.ListPrice,
                    cantidad = itm.Quantity,
                    ordenID = 0,
                    ItemID = itm.ItemId,
                }),
                datosEnvio = new
                {
                    destinatario = new
                    {
                        nombre = order.ShippingInformation.Names,
                        apellido = order.ShippingInformation.LastNames,
                    },
                    direccion = new
                    {
                        calle = order.ShippingInformation.ShippingAddress,
                        ciudad = order.ShippingInformation.City,
                        estado = order.ShippingInformation.State,
                        zip = order.ShippingInformation.Zip,
                        pais = order.ShippingInformation.Country
                    }
                }
            };

            return true;
        }
    }
}
