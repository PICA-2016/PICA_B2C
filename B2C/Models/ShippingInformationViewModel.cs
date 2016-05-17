using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B2C.Models
{
    /// <summary>
    /// Shipping Information Model.
    /// </summary>
    public class ShippingInformationViewModel
    {
        /// <summary>
        /// Credi Card Type.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Tipo de tarjeta")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)", ErrorMessage = "Digite solo letras")]
        public string CrediCardType { get; set; }

        /// <summary>
        /// Credit Card Holder.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Titular de la tarjeta")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string CreditCardHolder { get; set; }

        /// <summary>
        /// Credit Card Number.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Número de tarjeta")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([ \s0-9]+)", ErrorMessage = "Digite solo números")]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Credi Card Expiration.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Fecha de expiración")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha incorrecto")]
        public DateTime CrediCardExpiration { get; set; }

        /// <summary>
        /// Recipient Names.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombres")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Names { get; set; }

        /// <summary>
        /// Recipient Last Names.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string LastNames { get; set; }

        /// <summary>
        /// Shipping Address.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Dirección de envio")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \- \# \. \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Ciudad")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string City { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Estado")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string State { get; set; }

        /// <summary>
        /// Zip.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Zip")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Zip { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Pais")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Country { get; set; }

        //[Required(ErrorMessage = "El campo es obligatorio")]
        //[Display(Name = "Tipo de envio")]
        //[MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        //[RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)", ErrorMessage = "Digite solo letras")]
        //public string ShippingType { get; set; }
    }
}