using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Amoozeshgah.Common;


namespace Amoozeshgah.ViewModel
{

    public class EstateDto : Dto
    {
        public EstateDto()
        {
            PageTitle = "اطلاعات ملک";
        }

        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        [Display(Name = "نمازخانه")]

        public HaveNotHave? HavePrayerRoom { get; set; }

        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        [Display(Name = "کتابخانه")]

        public HaveNotHave? HaveLibrary { get; set; }

        [Display(Name = "تاییدیه اماکن")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HavePlaceConfirmation { get; set; }

        [Display(Name = "وضعیت ملک")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public int? EstateStatusId { get; set; }
        [ForeignKey(nameof(EstateStatusId))]
        public IEnumerable<SelectListItem> EstateStatus { get; set; }

        [Display(Name = "اجاره ماهیانه")]
        [Required(ErrorMessage = "اجاره ماهیانه را وارد کنید کنید")]
        public int? MonthlyRentCost { get; set; }

        [Display(Name = "متراژ عرصه")]
        [Required(ErrorMessage = "متراژ عرصه را وارد کنید")]
        public int? AreaArenaMeter { get; set; }

        [Display(Name = "متراژ اعیان")]
        [Required(ErrorMessage = "متراژ اعیان را وارد کنید")]
        public int? AreaLordMeter { get; set; }

        [Display(Name = "تعداد طبقات")]
        [Required(ErrorMessage = "تعداد طبقات را وارد نمایید")]
        public int? FloorCount { get; set; }

        [Display(Name = "نوع کاربری ملک")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public ApplicationType? ApplicationType { get; set; }

        [Display(Name = "لابراتور زبان")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveLanguageLaborator { get; set; }

        [Display(Name = "سیستم هوشمند")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveSmartSystem { get; set; }

        [Display(Name = "اتاق مشاور")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveAdvisorRoom { get; set; }

        [Display(Name = "سایت")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveSite { get; set; }

        [Display(Name = "بوفه مجزا")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveDedicatedBuffet { get; set; }

        [Display(Name = "آبخوری مجزا")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveDedicatedDrinking { get; set; }

        [Display(Name = "سرویس بهداشتی")]
        [Required(ErrorMessage = "یکی از گزینه ها را انتخاب کنید")]
        public HaveNotHave? HaveWarmWc { get; set; }

    }
}
