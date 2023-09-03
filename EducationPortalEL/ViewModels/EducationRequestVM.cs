using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class EducationRequestVM : BaseNonNumericVM
    {
        public bool IsEducationRequested { get; set; } //Talep Edildi mi
        
        public bool IsEducationCanceled { get; set; } //İptal Edildi mi
    }
}
