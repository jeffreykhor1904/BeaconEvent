using System;
namespace BeaconEvent.Models
{
	public class MiscModels
	{
	}

    public class DeviceCandidate
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
    }

    public class DeviceUuid
    {
        public static Guid[] DeviceServiceUuids { get; set; }
        public static Guid DeviceServiceUuid { get; set; }
        public static Guid DeviceMeasurementCharacteristicUuid { get; set; }
        public static Guid BatteryLevelServiceUuid { get; set; }
        public static Guid BatteryLevelCharacteristicUuid { get; set; }
    }

    //public class 
}