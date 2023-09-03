using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalDL.ImplementationsOfRepo
{
    public class EducationalContentRepo : Repository<EducationalContent, int>, IEducationalContentRepo
    {
        public EducationalContentRepo(MyContext context) : base(context)
        {
        }
    }
}
