using LearningProject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningProject.Helpers
{
    public class EnumHelper { 
        public static  EnumInfo Get(int i, Type eType)
        {
            return new EnumInfo
            {
                Id = i,
                EnumType = eType,
                Name = Enum.GetName(eType, i)
            };
        }

        public static IList<EnumInfo> GetList(Type enumType)
        {
            var enums = new List<EnumInfo>();

            if (!enumType.IsEnum)
                return enums;

            enums.AddRange(from object v in Enum.GetValues(enumType)
                           select new EnumInfo()
                           {
                               Id = (int)v,
                               Name = Enum.GetName(enumType, v)
                           });

            return enums;
        }
    }
}
