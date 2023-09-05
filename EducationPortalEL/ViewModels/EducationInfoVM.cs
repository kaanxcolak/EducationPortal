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
    public class EducationInfoVM : BaseNumericVM
    {
        public int CategoryId { get; set; }
        public string TrainerTypeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        public int Kontenjan { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Time { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public decimal PricePerDay { get; set; }

       
        public virtual Category Category { get; set; }

        public virtual TrainerInfo Trainer { get; set; }

    }
}
