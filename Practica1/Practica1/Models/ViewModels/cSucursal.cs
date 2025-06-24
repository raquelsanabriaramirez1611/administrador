using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica1.Models.ViewModels
{
    public class cSucursal : cListaSucursales
    {
        [Display(Name = "Sucursal ID")]
        public int SucursalID  {get;set;}

        [Display(Name = "Dirreción")]
        public string Direccion {get;set;}

    }
}