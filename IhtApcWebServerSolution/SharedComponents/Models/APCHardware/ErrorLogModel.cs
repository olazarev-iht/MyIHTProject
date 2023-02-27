using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ErrorLogModel
    {
        public Guid Id { get; set; }
        public int? SlaveId { get; set; }
        public string? ErrorCode { get; set; }
        public string? Descritpion { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
