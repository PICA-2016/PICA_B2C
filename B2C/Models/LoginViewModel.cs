using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B2C.Models
{
    /// <summary>
    /// Login Model.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name ="Nombre Usuario")]
        public string UserName { get; set; }

        /// <summary>
        /// Clave del usuario.
        /// </summary>
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Password, ErrorMessage =  "El campo es obligatorio")]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        /// <summary>
        /// Recordar clave del usuario.
        /// </summary>
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}