using SecondProjectByOperationsHistoryTableWithGUID.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondProjectByOperationsHistoryTableWithGUID.Models
{
    public class Vendor
    {
        public Vendor()
        {
            Tags = new HashSet<Tag>();
        }
        [Key]
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
        public ICollection<Tag> Tags { get; set; }
    }
}
