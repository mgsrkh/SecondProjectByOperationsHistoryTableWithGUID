using SecondProjectByOperationsHistoryTableWithGUID.CustomAttributes;
using SecondProjectByOperationsHistoryTableWithGUID.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondProjectByOperationsHistoryTableWithGUID.DTOs.Vendors
{
    public class VendorUpdateDTO
    {
        public VendorUpdateDTO()
        {
            Tags = new List<TagDTO>();            
        }
        [Required]
        [StringLength(128)]
        public string Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [TagIcollectionAttributes]
        public List<TagDTO> Tags { get; set; }
    }
}
