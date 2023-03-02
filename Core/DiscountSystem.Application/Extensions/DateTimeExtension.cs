using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Extensions
{
    public static class DateTimeExtension
    {
        public static string DateToString(this DateTime date) => date.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
