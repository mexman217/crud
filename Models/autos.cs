using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Autos.Models
{
    public class autos
    {
        [Key]
        public int idAlta { set; get; }
        [Required]
        [StringLength(50)]
        [Display (Name="Ingresa el modelo del auto")]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Ingresa la fecha")]
        public DateTime fechaAlta { get; set; }
    }
}
