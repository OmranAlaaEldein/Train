using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using AutoMapper;
using CoreTrain.Dto;
using DomainTrain.model;

namespace CoreTrain_Dto.Mapper
{
    public class Mappingprofile : Profile
    {
        public Mappingprofile() {
            CreateMap<Activity, Activity_Dto>();
            CreateMap<Activeuser, Activeuser_Dto>();
            
            CreateMap<Course,Course_Dto>()
                 .ForMember(x => x.duration, y => y.MapFrom(z =>(z.end_time - z.start_time).ToString(@"hh\:mm")));
            CreateMap<Course_Dto,Course>();


            CreateMap < Courseregistration, Courseregistration_Dto>();
            CreateMap < Job, Job_Dto >();
            CreateMap < Suggestions, Suggestion_Dto >();

            CreateMap < Trainer, Trainer_Dto >()
                .ForMember(x=>x.NameCourse,y=>y.MapFrom(z=>z.Course.Select(x=>x.title)));
            CreateMap<Trainer_Dto, Trainer>();

        }
    }
}
