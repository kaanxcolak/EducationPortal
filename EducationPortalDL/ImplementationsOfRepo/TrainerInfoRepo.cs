using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalDL.ImplementationsOfRepo
{
    public class TrainerInfoRepo : Repository<TrainerInfo, string>, ITrainerInfoRepo
    {
        public TrainerInfoRepo(MyContext context) : base(context)
        {
        }
    }
}
