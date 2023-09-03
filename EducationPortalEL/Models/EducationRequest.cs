using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Models
{
    [Table("EducationRequests")]
    public class EducationRequest:BaseNonNumeric
    {
        [Required]
        public bool IsEducationRequested { get; set; } //Talep Edildi mi

        [Required]
        public bool IsEducationCanceled { get; set; } //İptal Edildi mi
    }
}
