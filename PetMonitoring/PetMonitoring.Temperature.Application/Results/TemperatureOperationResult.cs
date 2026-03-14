using PetMonitoring.Temperature.Application.DTOs;
using PetMonitoring.Temperature.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.Results
{
    public class TemperatureOperationResult
    {
        public string? Message { get; set; }
        public RequestStatus Status { get; set; }
        public TemperatureRecordDTO Temperature { get; set; } = new TemperatureRecordDTO();
        public IEnumerable<TemperatureRecordDTO> TemperatureList { get; set; } = new List<TemperatureRecordDTO>();
        public TemperatureOperationResult(string message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public TemperatureOperationResult(string message, RequestStatus status, TemperatureRecordDTO temperature)
        {
            Message = message;
            Status = status;
            Temperature = temperature;
        }
        public TemperatureOperationResult(string message, RequestStatus status, IEnumerable<TemperatureRecordDTO> temperatureList)
        {
            Message = message;
            Status = status;
            TemperatureList = temperatureList;
        }

    }
}
