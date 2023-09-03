using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Models
{
    [Table("Categories")]
    public class Category:BaseNumeric
    {       
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } //online, sınıf içi eğitim, kitap, makale, sunum, mini proje...
        public string Description { get; set; } 
        public bool Status { get; set; }




    }
}
