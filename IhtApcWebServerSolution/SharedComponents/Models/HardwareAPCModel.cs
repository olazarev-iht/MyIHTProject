namespace SharedComponents.Models
{
	public class HardwareAPCModel
	{
		public Guid? DeviceId { get; set; }
		public string? DeviceName { get; set; }
		public Guid? DynamicParamsId { get; set; }
		public DynamicParamsInfo? DynamicParams { get; set; }
		public Guid? LiveParamsId { get; set; }
		public LiveParamsInfo? LiveParams { get; set; }
		public Guid? ConstParamsId { get; set; }
		public ConstParamsInfo? ConstParams { get; set; }
	}

	public class DynamicParamsInfo
	{
		public Guid? Id { get; set; }
		public double DynamicParam1 { get; set; } = 0;
		public double DynamicParam2 { get; set; } = 0;
		public double DynamicParam3 { get; set; } = 0;
	}

	public class LiveParamsInfo
	{
		public Guid? Id { get; set; }
		public double LiveParam1 { get; set; } = 0;
		public double LiveParam2 { get; set; } = 0;
		public double LiveParam3 { get; set; } = 0;
	}

	public class ConstParamsInfo
	{
		public Guid? Id { get; set; }
		public double ConstParam1 { get; set; } = 0;
		public double ConstParam2 { get; set; } = 0;
		public double ConstParam3 { get; set; } = 0;
	}
}

