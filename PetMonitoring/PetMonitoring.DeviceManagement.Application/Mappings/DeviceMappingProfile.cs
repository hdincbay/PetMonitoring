using AutoMapper;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Mappings
{
    public class DeviceMappingProfile : Profile
    {
        public DeviceMappingProfile()
        {
            CreateMap<DeviceRecord, DeviceRecordDTO>();
            CreateMap<DeviceRecordDTO, DeviceRecord>();
        }
    }
}
