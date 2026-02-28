using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Results
{
    public record DeviceOperationResult
    {
        public string? SerialNumber { get; set; }
        public string? Message { get; set; }
        public RequestStatus Status { get; set; }
        public DeviceRecordDTO Device { get; set; } = new DeviceRecordDTO();
        public IEnumerable<DeviceRecordDTO> DeviceList { get; set; } = new List<DeviceRecordDTO>();
        public DeviceOperationResult(string? message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public DeviceOperationResult(string? message, RequestStatus status, DeviceRecordDTO device)
        {
            Message = message;
            Status = status;
            Device = device;
        }
        public DeviceOperationResult(string? message, RequestStatus status, IEnumerable<DeviceRecordDTO> deviceList)
        {
            Message = message;
            Status = status;
            DeviceList = deviceList;
        }
        public DeviceOperationResult(string? serialNumber, string? message, RequestStatus status)
        {
            SerialNumber = serialNumber;
            Message = message;
            Status = status;
        }
    }
}
