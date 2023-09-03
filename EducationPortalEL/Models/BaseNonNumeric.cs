using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Models
{
    public class BaseNonNumeric
    {
        [Key] //PK
        [Column(Order =1)]
        [StringLength(11,MinimumLength =11)]
        public virtual string Id { get; set; }

        [Column(Order =2)]
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
