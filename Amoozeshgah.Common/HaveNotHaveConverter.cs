using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common
{
  public static class HaveNotHaveConverter
    {
        public static bool TooBool(this HaveNotHave? value)
        {
            return value == HaveNotHave.Have;
        }


        public static HaveNotHave? ToHaveNotHave(this bool? value)
        {
            if (!value.HasValue)
                return null;
           
            return value==true ? HaveNotHave.Have : HaveNotHave.NotHave;
        }
        public static ApplicationType? ToApplicationType(this bool? value)
        {
            if (!value.HasValue)
                return null;

            return value == true ? ApplicationType.Learning : ApplicationType.NoneLearning;
        }

        

    }
}
