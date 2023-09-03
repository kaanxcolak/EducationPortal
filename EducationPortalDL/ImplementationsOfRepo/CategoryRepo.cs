using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalDL.ImplementationsOfRepo
{
    public class CategoryRepo : Repository<Category, int>, ICategoryRepo
    {
        public CategoryRepo(MyContext context) : base(context)
        {

        }
    }
}
