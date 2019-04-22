using Amoozeshgah.Domain.Attributes;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Amoozeshgah.Common;

namespace Amoozeshgah.ViewModel
{
    public class TeacherRegisterDto : Dto
    {
        public TeacherRegisterDto()
        {
            PageTitle = "ثبت نام معلم";
        }

        [Display(Name = "NationalCode", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherNationalCodeError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
       // [NationalCode("")]
        public string NationalCode { get; set; }


        public string Password { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherFirstNameError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherLastNameError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
        public string LastName { get; set; }


        [Display(Name = "BirthDate", ResourceType = typeof(TeacherRegisterResx))]
        [RegularExpression(@"^[1-9][0-9]{3}\/(0[1-9]|1[0-2])\/(0[1-9]|[1-2][0-9]|3[0-1])$", ErrorMessageResourceName = nameof(FirstName), ErrorMessageResourceType = typeof(TeacherRegisterResx))]
        public string BirthDateJalali { get; set; }



        [Display(Name = "SexId", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherSexIdError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
        public int SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Display(Name = "وضعیت تاهل")]
        [Required(ErrorMessage = "وضعیت تاهل را مشخص کنید")]
        public int MaritalStatusId { get; set; }
        public IEnumerable<SelectListItem> MaritalStatus { get; set; }

        [Display(Name = "مذهب")]
        [Required(ErrorMessage = "مذهب خود را انتخاب کنید")]
        public int ReligionId { get; set; }
        public IEnumerable<SelectListItem> Religions { get; set; }

        [Display(Name = "آخرین مدرک تحصیلی معتبر")]
        [Required(ErrorMessage = "آخرین مدرک تحصیلی معتبر")]
        public int EducationDegreeId { get; set; }
        public IEnumerable<SelectListItem> EducationDegrees { get; set; }

        [Display(Name = "وضعیت استخدام")]
        [Required(ErrorMessage = "وضعیت استخدام")]
        public int RecruitmentTypeId { get; set; }
        public IEnumerable<SelectListItem> RecruitmentTypes { get; set; }

        [Display(Name = "وضعیت نظام وظیفه")]
        [Required(ErrorMessage = "وضعیت نظام وظیفه")]
        public int MilitaryStatusId { get; set; }
        public IEnumerable<SelectListItem> MilitaryStatus { get; set; }


        [Display(Name = "رشته تحصیلی")]
        [Required(ErrorMessage = "رشته تحصیلی را وارد کنید")]
        public string EducationDegreeFieldName { get; set; }

        [Display(Name = "معدل")]
        [Required(ErrorMessage = "معدل")]

        [Range(0.0, 20.0, ErrorMessage = "معدل بین صفر تا بیست")]
        public float EducationDegreeGrade { get; set; }

        [Display(Name = "تاریخ اخذ مدرک")]
        [RegularExpression(@"^[1-9][0-9]{3}\/(0[1-9]|1[0-2])\/(0[1-9]|[1-2][0-9]|3[0-1])$", ErrorMessageResourceName = nameof(FirstName), ErrorMessageResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessage = "تاریخ اخذ مدرک")]
        public string EducationDegreeGetDateJalali { get; set; }


        [Display(Name = "نیروی آزاد- تاریخ آخرین استعلام گزینش نیروهای آزاد و بازنشسته")]
        [RegularExpression(@"^[1-9][0-9]{3}\/(0[1-9]|1[0-2])\/(0[1-9]|[1-2][0-9]|3[0-1])$", ErrorMessageResourceName = nameof(FirstName), ErrorMessageResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessage = "تاریخ آخرین استعلام")]
        public string FreeAndOldSelectionDateJalali { get; set; }


        [Display(Name = "نیروی آزاد- شماره آخرین استعلام گزینش نیروهای آزاد و بازنشسته")]
        [Required(ErrorMessage = "شماره آخرین استعلام")]
        public string FreeAndOldSelectionNumber { get; set; }

        [Display(Name = "آیا سابقه کار دارید؟")]
        [Required(ErrorMessage = "سابقه کار")]
        public int? HaveWorkExperienceId { get; set; }

        public IEnumerable<SelectListItem> HaveWorkExperiences { get; set; }

        [Display(Name = "سابقه آموزشی به سال")]
        [Range(0, 50, ErrorMessage = "تعداد 0 تا 50 ")]
        public int? TeachExperienceInYear { get; set; }


        [Display(Name = "سابقه اداری به سال")]
        [Range(0, 50, ErrorMessage = "تعداد 0 تا 50 ")]
        public int? WorkExperienceInYear { get; set; }


        [Display(Name = "آیا دوره ضمن خدمت را گذرانده اید؟")]
        [Required(ErrorMessage = "دوره ضمن خدمت")]
        public int? MidCareerTraining { get; set; }

        public IEnumerable<SelectListItem> MidCareerTrainings { get; set; }

        [Display(Name = "شماره بیمه")]
        [Required(ErrorMessage = "شماره بیمه")]
        public int? InsuranceNumber { get; set; }

        [Display(Name = "نام دانشگاه محل اخذ")]
        public string EducationDegreeUniversityName { get; set; }

        [Display(Name = "تعداد فرزند")]
        [Range(0, 9, ErrorMessage = "تعداد 0 تا 9 ")]
        public int? ChildCount { get; set; }

        [Display(Name = "FatherName", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherFatherNameError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
        public string FatherFirstName { get; set; }


        [Display(Name = "MobileNumber", ResourceType = typeof(TeacherRegisterResx))]
        [Required(ErrorMessageResourceName = "TeacherMobileNumberError", ErrorMessageResourceType = typeof(TeacherRegisterResxInvalid))]
        [RegularExpression(@"((\+98|0)?9\d{9})|(^$)", ErrorMessageResourceName = "MobileNumberInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string CellPhoneNumber { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(TeacherRegisterResx))]
        [RegularExpression(@"^0[1-8]\d{9}", ErrorMessage = "تلفن ثابت را صحیح وارد نمایید")]
        public string PhoneNumber { get; set; }
    }
}
