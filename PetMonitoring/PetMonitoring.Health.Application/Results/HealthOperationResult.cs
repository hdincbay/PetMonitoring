using PetMonitoring.Health.Application.DTOs;
using PetMonitoring.Health.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Results
{
    public record HealthOperationResult
    {
        public string? Message { get; set; }
        public RequestStatus Status { get; set; }
        public HeartRateRecordDTO HeartRate { get; set; } = new HeartRateRecordDTO();
        public IEnumerable<HeartRateRecordDTO> HeartRateList { get; set; } = new List<HeartRateRecordDTO>();
        public HealthOperationResult(string? message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public HealthOperationResult(string? message, RequestStatus status, HeartRateRecordDTO heartRate)
        {
            Message = message;
            Status = status;
            HeartRate = heartRate;
        }
        public HealthOperationResult(string? message, RequestStatus status, IEnumerable<HeartRateRecordDTO> heartRateList)
        {
            Message = message;
            Status = status;
            HeartRateList = heartRateList;
        }
    }
}
