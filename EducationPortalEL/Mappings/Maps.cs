using AutoMapper;
using EducationPortalEL.Models;
using EducationPortalEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.Maps
{
    public class Maps:Profile
    {
        public Maps()
        {
            //AutoMapper ile modellerimiz ile ViewModellerimizi birleştirdik
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<EducationalContent, EducationalContentVM>().ReverseMap();
            CreateMap<EducationInfo, EducationInfoVM>().ReverseMap();
            CreateMap<EducationRequest, EducationRequestVM>().ReverseMap();
            CreateMap<Student, StudentVM>().ReverseMap();
            CreateMap<TrainerInfo, TrainerInfoVM>().ReverseMap();
           
        }
    }
}
