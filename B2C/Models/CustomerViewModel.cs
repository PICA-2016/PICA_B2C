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
        /// Customer email.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Correo electronico")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,4}$", ErrorMessage = "Digite solo letras y números")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Password, ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Clave")]
        [MaxLength(40, ErrorMessage = "Longitud maxima permitida de 40")]
        //[RegularExpression("^.*(?=.{8,}).*$", ErrorMessage = "Digite solo letras y números")]
        public string Password { get; set; }
    }
}