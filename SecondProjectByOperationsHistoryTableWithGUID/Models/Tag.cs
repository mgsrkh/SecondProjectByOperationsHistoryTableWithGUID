using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondProjectByOperationsHistoryTableWithGUID.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Value { get; set; }
        [Required]
        [ForeignKey("VendorId")]
        [StringLength(128)]
        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
