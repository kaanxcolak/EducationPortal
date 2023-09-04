using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Models
{
    [Table("Students")]
    public class Student:BaseNonNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string TcNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public int Age { get; set; }

        public string EducationRequestId { get; set; }

        //FK Katılım talebi olacak
        [ForeignKey("EducationRequestId")]
        public virtual EducationRequest EducationRequest { get; set; }



    }
}
