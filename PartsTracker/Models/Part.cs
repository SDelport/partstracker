using System.ComponentModel.DataAnnotations;

namespace PartsTracker.Models
{
    public class Part
    {
        [Key]
        [Required]
        public string PartNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be equal or larger than 0")]
        public int QuantityOnHand { get; set; }
        [Required]
        [StringLength(20)]
        public string LocationCode { get; set; }
        [Required]
        public DateTime LastStockTake { get; set; }
    }
}
