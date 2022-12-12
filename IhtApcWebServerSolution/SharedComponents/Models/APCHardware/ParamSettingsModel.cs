using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;
using SharedComponents.ViewModels;


namespace SharedComponents.Models.APCHardware
{
    public class ParamSettingsModel <T> where T : System.Enum
    {
        public Guid Id { get; set; }
        public string ParamId { get; set; } = string.Empty;
        public string ParamType { get; set; } = string.Empty;
        public ParamGroup ParamGroup { get; set; }
        public string ParamName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public int PasswordLevel { get; set; }
        public string? ParamViewGroupId { get; set; }
        public ParamViewGroupModel? ParamViewGroup { get; set; }
        public int ParamOrder { get; set; }

        public T? ParamGroupType { get; set; }

        public System.Enum? Enum { get; set; }

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
            Type enumType = ParamGroupHelper.ParamGroupToEnumType[ParamGroup]; //.GetElementType();
            //dynamic value3 = Convert.ChangeType(Enum, enumType);

            //var u16Data = ((ParamGroup[])Enum.GetValues(typeof(ParamGroup))).Where(x => x.ToString() != null).ToArray();

            //var paramTypeValues = (int[])ParamGroupHelper.ParamGroupToEnumType[ParamGroup].GetEnumValues();

            //var paramTypeNames = ParamGroupHelper.ParamGroupToEnumType[ParamGroup].GetEnumNames();

            //Array.IndexOf(paramTypeNames, ParamId);




            var eIdx = Enum.Parse(ParamGroupHelper.ParamGroupToEnumType[ParamGroup], ParamId);

            eIdx = Convert.ChangeType(eIdx, enumType);

            return await ihtDevices.ihtModbusCommunic.ihtModbusCmdParam.WriteAsync(SlaveId, (dynamic)eIdx, u16Data, updateRegister);
        }
    }
}
