using System.ComponentModel.DataAnnotations;

namespace DynamicFormApi.Models
{
    public class VentilationFormModel
    {
        [Required]
        public string SupplierRef { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string EDREFERER { get; set; } = string.Empty;
        [Required]
        public int wsdd { get; set; }
    }
}
