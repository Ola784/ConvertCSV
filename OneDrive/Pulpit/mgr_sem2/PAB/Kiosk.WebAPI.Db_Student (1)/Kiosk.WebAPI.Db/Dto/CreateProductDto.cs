using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.WebAPI.Dto
{
    public class CreateProductDto
    {
      //  [Required(ErrorMessage = "A product name is required")]
     //   [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
       // [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
