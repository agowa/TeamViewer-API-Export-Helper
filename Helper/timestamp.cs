using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Helper
{
    public static class timestamp
    {
        public static String GetTimestamp()
        {
            return GetTimestamp(DateTime.Now);
        }
        public static String GetTimestamp(this DateTime value)
        {
            //return value.ToString("yyyyMMddHHmmssfff");
            return value.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}
