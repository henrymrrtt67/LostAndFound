using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Enums
{
    public enum CategoryEnum
    {
        SPORTS_GEAR,
        JEWELLERY,
        ELECTRONICS,
        CLOTHING,
        SHOES
    }


    public static class MappingExtensions
    {
        private static Dictionary<string, CategoryEnum> CodeToEnumMapping =>
            new Dictionary<string, CategoryEnum>
            {
                { "Sports Gear",  CategoryEnum.SPORTS_GEAR },
                { "Jewellery", CategoryEnum.JEWELLERY },
                { "Electronics", CategoryEnum.ELECTRONICS },
                { "Clothing", CategoryEnum.CLOTHING },
                { "Shoes", CategoryEnum.SHOES }
            };

        public static CategoryEnum CodeToEnum(this string code)
        {
            return CodeToEnumMapping[code];
        }

        public static string EnumToCode(this CategoryEnum category)
        {
            var enumToCodeMapping = CodeToEnumMapping.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            return enumToCodeMapping[category];
        }
    }
}
