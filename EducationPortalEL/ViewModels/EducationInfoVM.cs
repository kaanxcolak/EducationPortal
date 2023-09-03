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
        public int TrainerTypeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public int Kontenjan { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Time { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public Category Category { get; set; }

        public TrainerInfo Trainer { get; set; }


    }
}
