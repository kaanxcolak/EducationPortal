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
    public class TrainerInfoManager : Manager<TrainerInfoVM, TrainerInfo, string>, ITrainerInfoManager
    {
        public TrainerInfoManager(ITrainerInfoRepo repo, IMapper mapper)
            : base(repo, mapper, "SenderBranch,ReceiverBranch,Receiver,Sender")
        {
        }
    }
}
