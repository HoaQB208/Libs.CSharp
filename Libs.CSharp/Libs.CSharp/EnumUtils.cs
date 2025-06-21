using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel;

namespace Libs.CSharp
{
    public static class EnumUtils
    {
        public static List<T> GetEnum<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static Dictionary<T, string> GetEnumValues<T>() where T : Enum
        {
            Dictionary<T, string> enumDictionary = new Dictionary<T, string>();
            foreach (T enumValue in Enum.GetValues(typeof(T)))
            {
                string value = enumValue.GetEnumDescription();
                enumDictionary.Add(enumValue, value);
            }
            return enumDictionary;
        }

        public static string GetEnumDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static List<string> GetEnumDescriptions(Type enumType)
        {
            var descs = new List<string>();
            var names = Enum.GetNames(enumType);
            foreach (var name in names)
            {
                var attributes = enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), true);
                DescriptionAttribute descriptionAttribute = attributes[0] as DescriptionAttribute;
                descs.Add(descriptionAttribute.Description);
            }
            return descs;
        }
    }
}
