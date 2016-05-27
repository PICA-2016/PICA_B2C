using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B2C.Models
{
    /// <summary>
    /// Customer Model.
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer Identification.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Número de Identificación")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Identification { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombres")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Names { get; set; }

        /// <summary>
        /// Customer lastname.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string LastNames { get; set; }

        /// <summary>
        /// Customer Phone.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Telefono")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite solo números")]
        public string Phone { get; set; }

        /// <summary>
        /// Customer email.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Correo electronico")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,4}$", ErrorMessage = "Formato de correo invalido")]
        public string Email { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre usuario")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Password, ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Clave")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        public string Password { get; set; }

        /// <summary>
        /// Credit Card Type.
        /// </summary>
        [Display(Name = "Tipo de tarjeta")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)", ErrorMessage = "Digite solo letras")]
        public string CrediCardType { get; set; }

        /// <summary>
        /// Credit Card Number.
        /// </summary>
        [Display(Name = "Número de tarjeta")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([ \s0-9]+)", ErrorMessage = "Digite solo números")]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        [Display(Name = "Status")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Status { get; set; }

        /// <summary>
        /// Street.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Dirección")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Street { get; set; }

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
        [Display(Name = "País")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string Country { get; set; }

        /// <summary>
        /// Addres Type.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Tipo dirección")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string AddresType { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Ciudad")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression(@"([A-Za-zÑñáéíóúÁÉÍÓÚ \s0-9]+)", ErrorMessage = "Digite solo letras y números")]
        public string City { get; set; }
    }
}