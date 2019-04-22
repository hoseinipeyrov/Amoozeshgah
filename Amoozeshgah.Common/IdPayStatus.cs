using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common
{
    public static class IdPayStatus
    {
        public static string ToIdPayStatus(this bool? status)
        {
            if (!status.HasValue)
            {

                return "<span class='label label-default'>در حال بررسی</span>";
            }

            if (status.Value)
            {
                return "<span class='label label-default'>تایید شده</span>";
            }
            return "<span class='label label-default'>عدم تایید</span>";
        }

        public static string GenerateButtons(this bool? status, int educationalCenterId)
        {
            var tag = "";
            if (!status.HasValue)
            {
                tag += $"<button type='submit'  class='btn btn-success btn-sm' name='Agree' value='{educationalCenterId}'>&nbsp;&nbsp;&nbsp;تایید&nbsp;&nbsp;&nbsp;</button>";
                tag += $"<button type='submit' class='btn btn-warning btn-sm' name='DisAgree' value='{educationalCenterId}'>عدم تایید</button>";
                return tag;
            }

            if (status.Value)
            {
                
                tag += "<button type='submit'  class='btn btn-sm' name='Agree' disabled>&nbsp;&nbsp;&nbsp;تایید&nbsp;&nbsp;&nbsp;</button>";
                tag += $"<button type='submit' class='btn btn-warning btn-sm' name='DisAgree' value='{educationalCenterId}'>عدم تایید</button>";
                return tag;
            }

            tag += $"<button type='submit'  class='btn btn-success btn-sm' name='Agree' value='{educationalCenterId}'>&nbsp;&nbsp;&nbsp;تایید&nbsp;&nbsp;&nbsp;</button>";
            tag += "<button type='submit' class='btn btn-sm' name='DisAgree' disabled>عدم تایید</button>";
            return tag;
        }

    }
}
