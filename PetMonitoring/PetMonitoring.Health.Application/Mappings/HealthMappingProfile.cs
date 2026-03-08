using AutoMapper;
using PetMonitoring.Health.Application.DTOs;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Mappings
{
    public class HealthMappingProfile : Profile
    {
        public HealthMappingProfile()
        {
            CreateMap<HeartRateRecord, HeartRateRecordDTO>();
            CreateMap<HeartRateRecordDTO, HeartRateRecord>();
        }
    }
}
