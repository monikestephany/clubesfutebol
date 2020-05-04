using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Itau.Case.ClubesFutebol.Infrastructure.Utils
{
    public static class EnumMethods
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var memInfo = type.GetMember(value.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return value.ToString();
        }
        public static T GetValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return (T)type.GetField("Nenhum").GetValue(null);
        }
    }
}
