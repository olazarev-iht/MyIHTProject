using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ConstParamsModel
    {
        // may be delete the Id
        public Guid Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Step { get; set; }

        public ConstParamsModel() { }
        public ConstParamsModel(int? paramId, ushort[] constParamsValues)
        {
            if (paramId is null) throw new ArgumentNullException($"{nameof(paramId)}");

            var u16Idx = (ushort)paramId;

            var idx = (ushort)(u16Idx * 3);
            var minId = (ushort)(idx + 0);
            var maxId = (ushort)(idx + 1);
            var stepId = (ushort)(idx + 2);

            this.Id = Guid.NewGuid();
            this.Min = constParamsValues[minId];
            this.Max = constParamsValues[maxId];
            this.Step = constParamsValues[stepId];
        }
    }

}
