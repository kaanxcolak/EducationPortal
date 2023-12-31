﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class BaseNonNumericVM
    {
        [StringLength(11, MinimumLength = 11)]
        public virtual string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
