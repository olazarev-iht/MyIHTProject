using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardwareMock;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;

namespace BlazorServerHost.Data
{
    public class APCHardwareMockDBHelper
    {

        public static void CreateAPCDefaultDataForDevice(ModelBuilder modelBuilder, int apcDevice)
        {
            var APCDefaultDataList = new List<APCDefaultData>();

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4000, Value = 264 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4001, Value = 14 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4002, Value = 256 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4003, Value = 65000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4004, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4005, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4006, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4007, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4008, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4009, Value = 0 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4010, Value = 4100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4011, Value = 16 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4012, Value = 4200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4013, Value = 72 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4014, Value = 4300 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4015, Value = 24 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4016, Value = 4400 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4017, Value = 42 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4018, Value = 4450 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4019, Value = 14 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4020, Value = 4500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4021, Value = 48 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4022, Value = 4550 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4023, Value = 16 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4024, Value = 4600 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4025, Value = 42 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4026, Value = 4650 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4027, Value = 14 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4028, Value = 4700 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4029, Value = 22 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4030, Value = 4800 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4031, Value = 11 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4032, Value = 4850 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4033, Value = 7 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4034, Value = 6000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4035, Value = 69 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4036, Value = 6100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4037, Value = 9 });

            // SetDevInfoSimulationData(ref UInt16[] au16DeviceInfo) Device Info
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4100, Value = 35653 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4101, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4102, Value = 12345 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4103, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4104, Value = 0 });
            int fwMinimumVersion = IhtDevices.GetFwMinimumVersion(isRobot: false);
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4105, Value = (UInt16)((fwMinimumVersion & 0xFFFF) >> 8) });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4106, Value = (UInt16)(fwMinimumVersion & 0xFF) });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4107, Value = 9430 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4108, Value = 2 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4109, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4110, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4111, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4112, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4113, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4114, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4115, Value = (UInt16)IhtDevices.TorchType.Propane });

            // SetTechnologySimulationData(ref UInt16[] au16TechnologyConst) Technology Const
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4200, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4201, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4202, Value = 5 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4203, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4204, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4205, Value = 5 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4206, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4207, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4208, Value = 5 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4209, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4210, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4211, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4212, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4213, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4214, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4215, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4216, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4217, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4218, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4219, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4220, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4221, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4222, Value = 10000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4223, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4224, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4225, Value = 10000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4226, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4227, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4228, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4229, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4230, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4231, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4232, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4233, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4234, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4235, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4236, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4237, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4238, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4239, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4240, Value = 3000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4241, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4242, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4243, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4244, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4245, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4246, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4247, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4248, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4249, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4250, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4251, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4252, Value = 30 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4253, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4254, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4255, Value = 30 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4256, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4257, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4258, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4259, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4260, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4261, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4262, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4263, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4264, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4265, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4266, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4267, Value = 2000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4268, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4269, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4270, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4271, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4272, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4273, Value = 65535 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4274, Value = 1 });

            // SetTechnologySimulationData(ref UInt16[] au16TechnologyDyn) Technology Dyn
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4300, Value = 80 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4301, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4302, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4303, Value = 2000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4304, Value = 2000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4305, Value = 4000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4306, Value = 2000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4307, Value = 1500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4308, Value = 6000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4309, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4310, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4311, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4312, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4313, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4314, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4315, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4316, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4317, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4318, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4319, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4320, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4321, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4322, Value = 460 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4323, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4324, Value = 0 });

            // SetProcessSimulationData(ref UInt16[] au16ProcessConst) Process Const
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4400, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4401, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4402, Value = 25 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4403, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4404, Value = 3 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4405, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4406, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4407, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4408, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4409, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4410, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4411, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4412, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4413, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4414, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4415, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4416, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4417, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4418, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4419, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4420, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4421, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4422, Value = 3 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4423, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4424, Value = 25 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4425, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4426, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4427, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4428, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4429, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4430, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4431, Value = 300 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4432, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4433, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4434, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4435, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4436, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4437, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4438, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4439, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4440, Value = 150 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4441, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4442, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4443, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4444, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4445, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4446, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4447, Value = 1 });

            // SetProcessSimulationData(ref UInt16[] au16ProcessDyn) Process Dyn 
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4450, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4451, Value = 2 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4452, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4453, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4454, Value = 80 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4455, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4456, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4457, Value = 2 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4458, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4459, Value = 25 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4460, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4461, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4462, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4463, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4464, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4465, Value = 1 });

            // SetConfigSimulationData(ref UInt16[] au16ConfigConst) Config Const
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4500, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4501, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4502, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4503, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4504, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4505, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4506, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4507, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4508, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4509, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4510, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4511, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4512, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4513, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4514, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4515, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4516, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4517, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4518, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4519, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4520, Value = 0 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4521, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4522, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4523, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4524, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4525, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4526, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4527, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4528, Value = 20000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4529, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4530, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4531, Value = 30 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4532, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4533, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4534, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4535, Value = 5 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4536, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4537, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4538, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4539, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4540, Value = 240 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4541, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4542, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4543, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4544, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4545, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4546, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4547, Value = 1 });

            // SetConfigSimulationData(ref UInt16[] au16ConfigDyn) Config Dyn
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4550, Value = 90 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4551, Value = 45 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4552, Value = 65 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4553, Value = 45 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4554, Value = 35 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4555, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4556, Value = 43 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4557, Value = 95 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4558, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4559, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4560, Value = 1500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4561, Value = 5 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4562, Value = 2500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4563, Value = 240 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4564, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4565, Value = 0 });

            // SetServiceSimulationData(ref UInt16[] au16ServiceConst) Service Const
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4600, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4601, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4602, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4603, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4604, Value = 3000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4605, Value = 100 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4606, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4607, Value = 20 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4608, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4609, Value = 500 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4610, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4611, Value = 250 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4612, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4613, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4614, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4615, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4616, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4617, Value = 1 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4618, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4619, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4620, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4621, Value = 10 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4622, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4623, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4624, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4625, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4626, Value = 10 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4627, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4628, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4629, Value = 50 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4630, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4631, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4632, Value = 50 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4633, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4634, Value = 5000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4635, Value = 50 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4636, Value = 1200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4637, Value = 1800 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4638, Value = 50 });

            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4639, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4640, Value = 1 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4641, Value = 1 });

            // SetServiceSimulationData(ref UInt16[] au16ServiceDyn) Service Dyn
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4650, Value = 4 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4651, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4652, Value = 7 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4653, Value = 1000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4654, Value = 100 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4655, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4656, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4657, Value = 50 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4658, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4659, Value = 3200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4660, Value = 200 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4661, Value = 3000 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4662, Value = 1400 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4663, Value = 0 });

            // SetProcessInfoSimulationData(ref UInt16[] au16ProcInfo) Process Info
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4700, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4701, Value = 2369 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4702, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4703, Value = 64 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4704, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4705, Value = 4 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4706, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4707, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4708, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4709, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4710, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4711, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4712, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4713, Value = 240 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4714, Value = 239 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4715, Value = 241 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4716, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4717, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4718, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4719, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4720, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4721, Value = (UInt16)IhtModbusData.ePassword.Level_2 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4722, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4723, Value = 0 });

            // SetCmdExecSimulationData(ref UInt16[] au16CmdExec) Cmd Exec
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4800, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4801, Value = 4 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4802, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4803, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4804, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4805, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4806, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4807, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4808, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4809, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4810, Value = 0 });

            // SetSetupExecSimulationData(ref UInt16[] au16SetupExec) Setup Exec
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4850, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4851, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4852, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4853, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4854, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4855, Value = 0 });
            APCDefaultDataList.Add(new APCDefaultData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4856, Value = 0 });

            // 

            modelBuilder.Entity<APCDefaultData>().HasData(APCDefaultDataList);
        }
    }
}
