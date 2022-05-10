using System;
using System.Collections;

namespace SharedComponents.Models
{
    public class SingletonDataModel
    {
        public IEnumerable<HardwareAPCModel> HardwareAPCList { get; set; } = new List<HardwareAPCModel>();


        //public SortedList<string, HardwareAPCModel> HardwareAPCs1 {
        //    get { return this.HardwareAPCs1; }
        //    set {
        //        value.Select(vp => new DictionaryEntry(vp.Value?.DeviceId, vp.Value));
        //    }
        //} 
    }
}
