using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class CategoryVM: BaseNumericVM
    {
        public string Name { get; set; } //online, sınıf içi eğitim, kitap, makale, sunum, mini proje...
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
