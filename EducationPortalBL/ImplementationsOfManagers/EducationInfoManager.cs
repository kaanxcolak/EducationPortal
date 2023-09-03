using AutoMapper;
using EducationPortalBL.InterfacesOfManagers;
using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.Models;
using EducationPortalEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalBL.ImplementationsOfManagers
{    
    public class EducationInfoManager : Manager<EducationInfoVM, EducationInfo, int>, IEducationInfoManager
    {
        public EducationInfoManager(IEducationInfoRepo repo, IMapper mapper)
            : base(repo, mapper, "Categor,Trainer")
        {
        }
    }
}
