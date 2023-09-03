using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Models
{
    [Table("EducationalContents")]
    public class EducationalContent:BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Type { get; set; } //video,makale,...

        [Required]  
        public string FileWay { get; set; } 

    }
}
