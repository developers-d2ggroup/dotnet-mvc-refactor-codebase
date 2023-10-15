using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Refactoring.Web.Models {
    public class OrderFormModel {
        public IEnumerable<SelectListItem> Districts { get; set; }

        [Required(ErrorMessage = "Please select a district")]
        public string SelectedDistrict { get; set; }
        [Required(ErrorMessage = "Order Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Order Amount must be greater than 0")]
        public decimal OrderAmount { get; set; }
    }
}