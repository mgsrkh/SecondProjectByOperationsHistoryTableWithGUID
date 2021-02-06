using System.ComponentModel.DataAnnotations;

namespace SecondProjectByOperationsHistoryTableWithGUID.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string VendorId { get; set; }
        [Required]
        public string JsonResult { get; set; }
        [Required]
        [StringLength(128)]
        public string Operation { get; set; }
    }
}
