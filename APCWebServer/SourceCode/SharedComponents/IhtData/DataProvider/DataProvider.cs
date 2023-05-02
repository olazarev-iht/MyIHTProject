using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData.DataProvider
{
  /// <summary>
  /// 
  /// </summary>
  internal class DataProvider
  {
  }

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>  
  public class ProcessInfoEventArgs<T> : EventArgs
  {
    public ProcessInfoEventArgs(T? oldValue, T? newValue)
    {
      OldValue = oldValue;
      NewValue = newValue;
    }

    public T? OldValue { get; set; }
    public T? NewValue { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataProvider<T>
  {
		public event EventHandler<ProcessInfoEventArgs<T>>? DataChanged;

    public virtual void OnDataChanged(ProcessInfoEventArgs<T> e)
    {
      DataChanged?.Invoke(this, e);
    }
  }
}
