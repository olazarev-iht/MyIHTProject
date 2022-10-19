using System.Reflection;
using System.ComponentModel;

namespace IhtApcWebServer.Extensions
{
    public static class EnumExtentions
    {
        public static string? GetDescription(this Enum value)
        {
            var type = value.GetType();
            string? name = Enum.GetName(type, value);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static string? GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null) return null;
            
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
