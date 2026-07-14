using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingApi.Models;

public class Product
{
    [Key] public int Id { get; set; }
    [Required] [StringLength(100)] public string Name { get; set; } = string.Empty;
    [Required] [StringLength(50)] public string Barcode { get; set; } = string.Empty;
    [Required] [Column(TypeName = "decimal(18, 2)") ] public decimal Price { get; set; }
    [Required] public int Stock { get; set; }
}