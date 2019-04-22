using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common
{
    public static class IsDisableOrEnable
    {
        public static string ToEnableOrDisabe(this bool isDisable)
        {
            return isDisable ? "<span class='label label-warning'>غیرفعال</span> " 
                             : "<span class='label label-success'>فعال</span> ";
        }
    }
}
