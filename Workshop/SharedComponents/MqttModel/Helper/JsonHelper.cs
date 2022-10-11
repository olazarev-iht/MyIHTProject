// ** Article and associated source code originally published by Graeme Grant @ https://www.codeproject.com/Articles/1201466/Working-with-JSON-in-Csharp-VB

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharedComponents.MqttModel.Helper
{
  public static class JsonHelper
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="isEmptyToNull"></param>
    /// <param name="jsonSettings"></param>
    /// <returns></returns>
    public static string FromClass<T>(T data, bool isEmptyToNull = false, JsonSerializerSettings? jsonSettings = null)
    {
        string response = string.Empty;

        if (!EqualityComparer<T>.Default.Equals(data, default(T)))
            response = JsonConvert.SerializeObject(data, jsonSettings);

        return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="jsonSettings"></param>
    /// <returns></returns>
    public static T ToClass<T>(string data, JsonSerializerSettings? jsonSettings = null)
    {
        var response = default(T);

        if (!string.IsNullOrEmpty(data))
        {
            response = jsonSettings == null
                ? JsonConvert.DeserializeObject<T>(data)
                : JsonConvert.DeserializeObject<T>(data, jsonSettings);
        }

        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal static JsonSerializerSettings CreateSerializerSettings(ErrorContext errorContext)
    {
      JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
      {
        Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
          errorContext = args.ErrorContext;
          args.ErrorContext.Handled = true;
        }
      };
      return jsonSerializerSettings;
    }
  }
}