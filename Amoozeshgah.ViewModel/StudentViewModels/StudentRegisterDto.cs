using Amoozeshgah.Domain.Attributes;
using Amoozeshgah.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class StudentRegisterDto:Dto
    {
        public StudentRegisterDto()
        {
            PageTitle = "ثبت نام دانش آموز";
        }
        [Display(Name = "NationalCode", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "NationalCodeInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        //[NationalCode("")]
        public string NationalCode { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "FirstNameInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "LastNameInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string LastName { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(StudentRegisterResx))]
        [RegularExpression(@"^[1-9][0-9]{3}\/(0[1-9]|1[0-2])\/(0[1-9]|[1-2][0-9]|3[0-1])$", ErrorMessageResourceName = "BirthDateInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        [Required(ErrorMessage = "تاریخ تولد")]
        public string BirthDateJalali { get; set; }

        [Display(Name = "SexId", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "SexIdInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public int SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Display(Name = "FatherName", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "FatherNameInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string FatherFirstName { get; set; }

        [Display(Name = "ParentName", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "ParentNameInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string ParentFirstName { get; set; }

        [Display(Name = "ParentFamily", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "ParentFamilyInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public string ParentLastName { get; set; }

        [Display(Name = "استان محل تولد")]
        [Required(ErrorMessage = "استان محل تولد را انتخاب کنید")]
        public int ProvinceOfBirthId { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }


        [Display(Name = "PlaceOfBirthId", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessage = "شهر محل تولد را انتخاب کنید")]
        public int? CityOfBirthId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
            = new List<SelectListItem>();

        [Display(Name = "MobileNumber", ResourceType = typeof(StudentRegisterResx))]
        [RegularExpression(@"((\+98|0)?9\d{9})|(^$)", ErrorMessageResourceName = "MobileNumberInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        [Required(ErrorMessage = "تلفن همراه را وارد کنید")]

        public string CellPhoneNumber { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(StudentRegisterResx))]
        [RegularExpression(@"^0[1-8]\d{9}", ErrorMessageResourceName = "PhoneNumberInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        [Required(ErrorMessage = "تلفن ثابت را وارد کنید")]
        public string PhoneNumber { get; set; }

        public IEnumerable<SelectListItem> CityOfLocation { get; set; }
        [Display(Name = "CityOfLocationId", ResourceType = typeof(StudentRegisterResx))]
        [Required(ErrorMessageResourceName = "CityOfLocationIdInvalid", ErrorMessageResourceType = typeof(StudentRegisterResxInvalid))]
        public int? CityOfLocationId { get; set; }

        [Display(Name = "استان محل اقامت")]
        [Required(ErrorMessage = "استان محل اقامت را انتخاب کنید")]
        public string ProvinceOfLocationId { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        public string Password { get; set; }
        [Display(Name = "کپچا")]
        [Required(ErrorMessage = "حاصل جمع صحیح نیست")]
        public string Captcha { get; set; }
    }
}
