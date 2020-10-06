/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FortyThreeLime.API.Extensions
{
    public static class EnumExtensions
    {
        /*
         https://stackoverflow.com/questions/13099834/how-to-get-the-display-name-attribute-of-an-enum-member-via-mvc-razor-code
             */

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string GetDescription(this Enum enumValue)
        {
            Type genericEnumType = enumValue.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (_Attribs != null && _Attribs.Count() > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return enumValue.ToString();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}