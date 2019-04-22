using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amoozeshgah.Common.Enums;

namespace Amoozeshgah.Common
{
    public static class EducationalCenterCodeGenetrator
    {
        public static int GenerateNew(int AreaCode, int sexCode, int typeCode, int stepNo)
        {
            return Convert.ToInt32($"{AreaCode}{sexCode}{typeCode}{stepNo}");
        }
    }
}
