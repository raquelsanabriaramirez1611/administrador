using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica1.Models.ViewModels
{
    public class createSucursal
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre de la sucursal")]
        public string Nombre { get; set; }
        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "La dirección no puede exceder más de 100 caracteres")]
        public string Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}