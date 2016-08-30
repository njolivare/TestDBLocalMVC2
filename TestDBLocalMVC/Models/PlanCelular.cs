//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestDBLocalMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class PlanCelular
    {
        public PlanCelular()
        {
            this.Cuenta = new HashSet<Cuenta>();
        }
    
        public int Id { get; set; }
        [Required()]
        [Display(Name = "Código Plan")]
        public string Codigo { get; set; }
        [Display(Name = "Descrippción Plan")]
        [MaxLength (100)]
        public string Nombre { get; set; }
        [Required()]
        [Display(Name = "Tarifa Básica")]
        public Nullable<decimal> TarifaBasica { get; set; }

        [Required()]
        [Display(Name = "Es Plan Actorlining")]
        public Nullable<bool> EsAL { get; set; }
    
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}