using EducationPortalEL.IdentityModels;
using EducationPortalEL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalDL
{
    public class MyContext: IdentityDbContext<AppUser,AppRole,string>
    {
        public MyContext(DbContextOptions<MyContext> options) :base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<EducationalContent> EducationalContent { get; set; }
        public DbSet<EducationInfo> EducationInfo { get; set; }
        public DbSet<EducationRequest> EducationRequest { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<TrainerInfo> TrainerInfo { get; set; }
        
    }
}
