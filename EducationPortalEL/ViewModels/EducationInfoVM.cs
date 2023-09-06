using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class EducationInfoVM : BaseNonNumericVM
    {
        public string CategoryId { get; set; }
        public string TrainerTypeId { get; set; }
        public string StudentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        
        public int Kontenjan { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Time { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

       
        public virtual Category Category { get; set; }

        public virtual TrainerInfo Trainer { get; set; }
        public virtual Student Student { get; set; }

    }
}
