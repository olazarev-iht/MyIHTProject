using Newtonsoft.Json;
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
        public string? Description { get; set; }
		public string? Params { get; set; }
		public DateTime? TimeStamp { get; set; }

		//Use Args to not work with Params directly
		public string[]? Args
		{
			get
			{
				if (this.Params == null) return null;

				var args = JsonConvert.DeserializeObject<string[]>(this.Params);

				return args;
			}

			set
			{
				Params = JsonConvert.SerializeObject(value);
			}
		}
	}
}
