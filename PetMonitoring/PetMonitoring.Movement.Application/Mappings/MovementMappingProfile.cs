using AutoMapper;
using PetMonitoring.Movement.Application.DTOs;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Mappings
{
    public class MovementMappingProfile : Profile
    {
        public MovementMappingProfile()
        {
            CreateMap<MovementRecord, MovementRecordDTO>();
            CreateMap<MovementRecordDTO, MovementRecord>();
        }

    }
}
