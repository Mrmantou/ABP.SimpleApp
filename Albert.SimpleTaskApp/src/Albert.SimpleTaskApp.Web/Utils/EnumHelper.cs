using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Web.Utils
{
    public class EnumHelper
    {
        public static List<SelectListItem> GetSelectList<T>()
        {
            var enumType = typeof(T);
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var value in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem
                {
                    Text = Enum.GetName(enumType, value),
                    Value = value.ToString()
                });
            }

            return selectList;
        }
    }
}
