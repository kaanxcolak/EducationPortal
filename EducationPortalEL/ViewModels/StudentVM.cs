﻿using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class StudentVM : BaseNonNumericVM
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
        
        public int Age { get; set; }

        public int EducationRequestId { get; set; }
        
        public EducationRequest EducationRequest { get; set; }
        public string EducationInfoId { get; set; }
        public virtual EducationInfo EducationInfo { get; set; }




    }
}
