using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Helpers
{
    public class CommonConstants
    {
		//Operation types
        public const string IGNITION = "Ignition";
        public const string PRE_HEAT = "Preheat";
        public const string PIERCING = "Piercing";
        public const string CUTTING = "Cutting";
        public const string HEATTING = "Heating";

		//Max number of rows in the application log
		public const int MaxErrolLogRowsNum = 5000;

		//Max number of rows we show from the business log
		public const int MaxErrolLogRowsToShow = 150;
	}
}
