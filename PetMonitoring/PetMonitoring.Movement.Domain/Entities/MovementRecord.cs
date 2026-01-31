using PetMonitoring.Movement.Domain.Enums;
namespace PetMonitoring.Movement.Domain.Entities
{
    public class MovementRecord
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public Guid DeviceId { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public int StepCount { get; private set; }
        public double DistanceInMeters { get; private set; }
        public ActivityLevel ActivityLevel { get; private set; }

        public int ActiveMinutes { get; private set; }
        public int InactiveMinutes { get; private set; }

        protected MovementRecord() { }

        public MovementRecord(
            Guid petId,
            Guid deviceId,
            int stepCount,
            double distanceInMeters,
            ActivityLevel activityLevel,
            int activeMinutes,
            int inactiveMinutes)
        {
            Id = Guid.NewGuid();
            PetId = petId;
            DeviceId = deviceId;
            CreatedDate = DateTime.UtcNow;
            StepCount = stepCount;
            DistanceInMeters = distanceInMeters;
            ActivityLevel = activityLevel;
            ActiveMinutes = activeMinutes;
            InactiveMinutes = inactiveMinutes;
        }
    }
}
