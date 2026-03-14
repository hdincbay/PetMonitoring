using AutoMapper;
using PetMonitoring.Temperature.Application.DTOs;
using PetMonitoring.Temperature.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.Mappings
{
    public class TemperatureMappingProfile : Profile
    {
        public TemperatureMappingProfile()
        {
            CreateMap<TemperatureRecord, TemperatureRecordDTO>();
            CreateMap<TemperatureRecordDTO, TemperatureRecord>();
        }
    }
}
