using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalDL.ImplementationsOfRepo
{
    public class StudentRepo : Repository<Student, string>, IStudentRepo
    {
        public StudentRepo(MyContext context) : base(context)
        {
        }
    }
}
