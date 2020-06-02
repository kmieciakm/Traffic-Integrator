using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Data {
    public class SupplierData {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Api")]
        public string ApiUrl { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool Active { get; set; }
    }
}
