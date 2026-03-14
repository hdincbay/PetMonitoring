using PetMonitoring.Movement.Domain.Enums;
namespace PetMonitoring.Movement.Domain.Entities
{
    public class MovementRecord
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public int StepCount { get; private set; }
        public double DistanceInMeters { get; private set; }
        public ActivityLevel ActivityLevel { get; private set; }

        public int ActiveMinutes { get; private set; }
        public int InactiveMinutes { get; private set; }

        protected MovementRecord() { }
        public static MovementRecord Create(string deviceSerialNumber, int stepCount, double distanceInMeters, ActivityLevel activityLevel, int activeMinutes, int inActiveMinutes)
        {
            return new MovementRecord
            {
                DeviceSerialNumber = deviceSerialNumber,
                CreatedDate = DateTime.Now,
                StepCount = stepCount,
                DistanceInMeters = distanceInMeters,
                ActivityLevel = activityLevel,
                ActiveMinutes = activeMinutes,
                InactiveMinutes = inActiveMinutes
            };
        }
    }
}
