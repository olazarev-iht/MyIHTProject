using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Extensions;
using Newtonsoft.Json;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.MqttModel.Exec.DataBase;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCWorkerService;
using SharedComponents.ViewModels;
using Microsoft.AspNetCore.Components;




namespace SharedComponents.Models.APCHardware
{
    public class ParamSettingsModel
    {
        public Guid Id { get; set; }
        public string ParamId { get; set; } = string.Empty;
        public SettingParamIds SettingParam
        { 
            get
            {
                return (SettingParamIds)Enum.Parse(typeof(SettingParamIds), ParamId);
            }
            set { }
        }
        public Enum? paramModbusEnumType
        {
            get
            {
                return ParamGroupHelper.SettingParamsProperties[SettingParam].paramModbusEnumType;
            }
            set { }
        }
        public string ParamType { get; set; } = string.Empty;
        public string ParamName { get; set; } = string.Empty;
        public string DisplayName
        {
            get
            {
                return SettingParam.GetDescription() ?? string.Empty;
            }
            set { }
        }
        public string Format
        {
            get
            {
                return ParamGroupHelper.SettingParamsProperties[SettingParam].Format;
            }
            set { }
        }

        public string ClientId { get; set; } = string.Empty;
        public int PasswordLevel { get; set; }
        public string? ParamViewGroupId { get; set; }
        public ParamViewGroupModel? ParamViewGroup { get; set; }
        public int ParamOrder { get; set; }

        private IAPCWorker? _apcWorker { get; set; }

        public ParamSettingsModel()
        {
            _apcWorker = ExecDataBaseRequest.InstanceAPCWorker();
        }

        //public ParamSettingsModel()

        public ViewParameter ViewParameter
        {
            get
            {
                if (this.Format == null) return new ViewParameter();

                var formatDetails = JsonConvert.DeserializeObject<ViewParameter>(this.Format);

                return new ViewParameter
                {
                    Name = formatDetails?.Name != null ? formatDetails.Name : string.Empty,
                    Mode = formatDetails?.Mode != null ? formatDetails.Mode : string.Empty,
                    Values = formatDetails?.Values != null ? formatDetails.Values : Array.Empty<string>(),
                    ReadOnly = formatDetails?.ReadOnly != null ? formatDetails.ReadOnly : false,
                    Unit = formatDetails?.Unit != null ? formatDetails.Unit : false,
                };
            }
        }

        public async Task<bool> WriteAsync(IhtDevices ihtDevices, int SlaveId, ushort u16Data, bool updateRegister = true)
        {
            bool result = true;

            try
            {
                //var enumType = ParamGroupHelper.ParamGroupToEnumType[ParamGroup];

                //var eIdx = Enum.Parse(enumType, ParamId);

                //eIdx = Convert.ChangeType(eIdx, enumType);

                var eIdx = paramModbusEnumType;

                if (eIdx != null)
                {
                    var paramStartAddress = await ihtDevices.ihtModbusCommunic.ihtModbusCmdParam.WriteAsync(SlaveId, (dynamic?)eIdx, u16Data, updateRegister);

                    if (paramStartAddress != null && paramStartAddress != 0)
                    {
                        //It might make sense to move the database update out of this method.
                        //Then you will need to create a dictionary depending on the address of the parameter group.
                        //var modbusData = ihtDevices.ihtModbusCommunic.GetConnectedModbusData(SlaveId);
                        //ushort paramStartAddress = modbusData.GetAddrInfo((dynamic)eIdx)?.u16StartAddr ?? 0;

                        if (_apcWorker != null)
                        {
                            await _apcWorker.RefreshDynamicDataAsync(SlaveId, paramStartAddress, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
