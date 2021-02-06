using System.ComponentModel.DataAnnotations;

namespace SecondProjectByOperationsHistoryTableWithGUID.DTOs.Vendors
{
    public class VendorInsertResponseDTO : VendorInsertDTO
    {
        [Required]
        [StringLength(128)]
        public string Id { get; set; }
    }
}
