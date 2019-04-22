
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Services;
using Amoozeshgah.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Amoozeshgah.Common.Enums;
using System.Data.Entity;
using Amoozeshgah.Common;
using Amoozeshgah.Common.DateConverter;

namespace Amoozeshgah.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserWithDetailService _userWithDetailService;
        private readonly ISexService _sexService;
        private AppContext _db;



        public AccountController(IUserWithDetailService userWithDetailService,
            ISexService sexService, AppContext db)
        {
            _userWithDetailService = userWithDetailService;
            _sexService = sexService;
            _db = db;
        }

        public IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // GET: Account
        [HttpGet, AllowAnonymous]
        public ActionResult Index()
        {
            Authentication.SignOut();
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult SelectLoginType()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult OragnizationSignIn()
        {
            return View("SignIn");
        }

        [HttpGet, AllowAnonymous]
        public ActionResult SiteSignIn()
        {
            return View("SignIn");
        }

        #region Admin SignIn

        [HttpGet, AllowAnonymous]
        public ActionResult Administrator()
        {
            Authentication.SignOut();
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult Administrator(SignInDto model)
        {
            Authentication.SignOut();
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>().Include(u => u.UsersRoles)
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "کاربری با این مشخصات یافت نشد");
                return View("SignIn", model);
            }

            if (user.UsersRoles == null || !user.UsersRoles.Any(ur => ur.RoleId == 1))
            {
                ModelState.AddModelError("error", "کاربری با این مشخصات یافت نشد");
                return View("SignIn", model);
            }


            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("UserId", user.Id.ToString()),
                new Claim("RoleId", "1")
            }, DefaultAuthenticationTypes.ApplicationCookie);
            Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            }, identity);
            return RedirectToAction("Index", "ManageProvinceUsers", new { area = "AdministratorArea" });
        }

        #endregion



        #region Province SignIn

        [HttpGet, AllowAnonymous]
        public ActionResult ProvinceSignIn()
        {
            Authentication.SignOut();
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult ProvinceSignIn(SignInDto model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>().Include(u => u.UsersRoles)
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "یافت نشد");
                return View("SignIn", model);
            }

            var userRole = user.UsersRoles.FirstOrDefault(sur => sur.RoleId == 2);
            if (userRole == null)
            {
                ModelState.AddModelError("error", "یافت نشد");
                return View("SignIn", model);
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("SiteId", userRole.SiteId.ToString()),
                    new Claim("RoleId", "2")
                }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                return RedirectToAction("ProvinceUser", "AdminsDashboard", new { area = "AdministratorArea" });
            }
        }

        #endregion





        #region Area SignIn

        [HttpGet, AllowAnonymous]
        public ActionResult AreaSignIn()
        {
            Authentication.SignOut();
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult AreaSignIn(SignInDto model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>().Include(u => u.UsersRoles)
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "یافت نشد");
                return View("SignIn", model);
            }

            var userRole = user.UsersRoles.FirstOrDefault(sur => sur.RoleId == 3);
            if (userRole == null)
            {
                ModelState.AddModelError("error", "یافت نشد");
                return View("SignIn", model);
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("SiteId", userRole.SiteId.ToString()),
                    new Claim("RoleId", "3")
                }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                return RedirectToAction("AreaUser", "AdminsDashboard", new { area = "AdministratorArea" });
            }
        }

        #endregion




        #region EducationalCenterUser SignIn

        [HttpGet, AllowAnonymous]
        public ActionResult EducationalCenterUserSignIn()
        {
            Authentication.SignOut();
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult EducationalCenterUserSignIn(SignInDto model)
        {
            Authentication.SignOut();
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>().FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "notfound!");
                return View("SignIn", model);
            }

            var userId = user.Id;
            var surs = db.Set<SiteUserRole>()
                .Where(sur => sur.UserId == userId && sur.Role.Code == (int)RoleCode.EducationalCenterUser).ToList();
            if (surs.Count == 0)
            {
                ModelState.AddModelError("error", "notfound!");
                return View("SignIn", model);
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, surs.First().User.UserName),
                    new Claim("UserId", surs.First().UserId.ToString()),
                    new Claim("RoleId", "4"),
                    new Claim("SiteId", surs.First().SiteId.ToString())
                }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                return RedirectToAction("Index", "Dashboard", new { area = "EducationalCenterUserArea" });
            }
        }

        #endregion

        #region Teacher SignIn

        [HttpGet, AllowAnonymous]
        public ActionResult TeacherSignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult TeacherSignIn(SignInDto model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>()
                .Include(u => u.Teacher)
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "کاربری با این مشخصات یافت نشد");
                return View("SignIn", model);
            }
            if (user.Teacher != null)
            {
                const string roleId = "5"; 

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("RoleId", roleId)
                }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                return RedirectToAction("Index", "TeacherDashboard", new { area = "TeacherArea" });
            }

            ModelState.AddModelError("error", "یافت نشد");
            return View("SignIn", model);
        }

        #endregion

        #region Student SignIn

        // /Account/StudentSignIn
        [HttpGet, AllowAnonymous]
        public ActionResult StudentSignIn()
        {
            Authentication.SignOut();
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult StudentSignIn(SignInDto model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "مجموع اشتباه است");
                return View("SignIn", model);
            }

            var db = new AppContext();
            var user = db.Set<User>().Include(u => u.Student)
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("error", "کاربری با این مشخصات یافت نشد");
                return View("SignIn", model);
            }

            //var userId = user.Id;
            //var surs = db.Set<Student>().Where(sur => sur.UserId == userId && sur.Role.Code == (int)RoleCode.Student).ToList();
            if (user.Student != null)
            {
                const string roleId = "6"; //((int)RoleCode.Student).ToString();

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("RoleId", roleId)
                }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                return RedirectToAction("Index", "StudentDashboard", new { area = "StudentArea" });
            }

            ModelState.AddModelError("error", "یافت نشد");
            return View("SignIn", model);

        }

        #endregion



        [HttpPost, AllowAnonymous]
        public ActionResult Index(string returnUrl, int type = 0)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Url.Action("Index", "Account"));

            }

            ViewBag.ReturnUrl = returnUrl;
            if (type == 2)
            {

            }

            return View("Login", new LoginDto { RoleId = type });
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return Redirect(Url.Action("Index", "Account"));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AjaxLogin(LoginDto model)
        {
            if (!Request.IsAjaxRequest())
            {
                return Redirect(Url.Action("Login", "Account"));
            }

            if (!ModelState.IsValid)
            {
                return Json("نام کاربری و گذرواژه را وارد نمایید ", JsonRequestBehavior.AllowGet);
            }

            if (model.RoleId == 1)
            {
                var sitesUsersRoles = _userWithDetailService.FindSiteUser(model.RoleId, model.UserName, model.Password);

                var cnt = sitesUsersRoles.Count();
                if (cnt == 0)
                {
                    return Json("نام کاربری و یا گذرواژه صحیح نیست", JsonRequestBehavior.AllowGet);
                }

                if (cnt == 1)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, sitesUsersRoles.First().User.UserName),
                        new Claim("UserId", sitesUsersRoles.First().User.Id.ToString()),
                        new Claim("RoleId", sitesUsersRoles.First().Role.Id.ToString()),
                        new Claim("SiteId", sitesUsersRoles.First().Site.Id.ToString()),
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    //return RedirectToAction("Index", "Home");
                    return Json("Authenticated", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("نام کاربری و یا گذرواژه صحیح نیست", JsonRequestBehavior.AllowGet);

                }
            }

            return Json("نام کاربری و یا گذرواژه صحیح نیست", JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //public ActionResult RegisterNewStudent()
        //{
        //    var registerStudentDto = new RegisterStudentDto
        //    {
        //        Sexes = new SelectList(_sexService.GetAll(), "Id", "Name"),
        //        Provinces = new SelectList(_organizationService.GetAllProvincess(), "Code", "Name"),
        //        Areas = new SelectList(_organizationService.GetAllAreas(), "Code", "Name")
        //    };

        //    return View(registerStudentDto);
        //}

        [HttpGet]
        public ActionResult RegisterNewStudent()
        {
            return View(new StudentRegisterDto
            {

                Provinces = _db.Set<Province>().ToList().Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }),
                Sexes = _db.Set<Sex>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterNewStudent(StudentRegisterDto model)
        {
            var nationalCode = model.NationalCode;
            var person = _db.Set<Person>().Include(p => p.User.Student).FirstOrDefault(p => p.NationalCode == nationalCode);


            if (person == null)
            {
                var newstudent = new Student
                {
                    User = new User
                    {
                        Person = new Person
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            NationalCode = model.NationalCode,
                            MobileNo = model.CellPhoneNumber,
                            BirthDate = model.BirthDateJalali.ToGeorgianDateTime(),
                            BirthDateJalali = model.BirthDateJalali,
                            SexId = model.SexId,
                            FatherFirstName = model.FatherFirstName,
                        },
                        UserName = model.NationalCode,
                        Password = model.Password,
                        Status = true
                    },
                    ParentFirstName = model.ParentFirstName,
                    ParentLastName = model.ParentLastName,
                    CityOfBirthId = model.CityOfBirthId.Value,
                    CellPhoneNumber = model.CellPhoneNumber,
                    PhoneNumber = model.PhoneNumber,
                    CityOfHomeId = model.CityOfLocationId.Value
                };
                _db.Entry(newstudent).State = EntityState.Added;
                _db.SaveChanges();
            }
            else
            {
                if (person.User.Student == null)
                {
                    person.User.Student = new Student
                    {
                        ParentFirstName = model.ParentFirstName,
                        ParentLastName = model.ParentLastName,
                        CityOfBirthId = model.CityOfBirthId.Value,
                        CellPhoneNumber = model.CellPhoneNumber,
                        PhoneNumber = model.PhoneNumber,
                        CityOfHomeId = model.CityOfLocationId.Value
                    };
                    _db.Entry(person).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "دانش آموزی با این کد ملی از قبل وجود دارد. در صورتی که کد ملی را صحیح وارد نموده اید به بخش بازیابی رمز عبور مراجعه نمایید");
                    return View(new StudentRegisterDto
                    {

                        Provinces = _db.Set<Province>().ToList().Select(p => new SelectListItem
                        {
                            Value = p.Id.ToString(),
                            Text = p.Name
                        }),
                        Sexes = _db.Set<Sex>().ToList().Select(s => new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.Id.ToString()
                        }),

                    });
                }
            }
            return View();
        }






        [HttpGet]
        public ActionResult RegisterNewTeacher()
        {

            return View(new TeacherRegisterDto
            {
                Sexes = _db.Set<Sex>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                MaritalStatus = _db.Set<MaritalStatus>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                Religions = _db.Set<Religion>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                EducationDegrees = _db.Set<EducationDegree>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                MilitaryStatus = _db.Set<MilitaryStatus>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                RecruitmentTypes = _db.Set<RecruitmentType>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                HaveWorkExperiences = new List<SelectListItem>
                {
                    new SelectListItem{Text ="بله" ,Value = "1"},
                    new SelectListItem{Text ="خیر" ,Value = "0"}

                },
                MidCareerTrainings = new List<SelectListItem>
                {
                    new SelectListItem{Text ="بله" ,Value = "1"},
                    new SelectListItem{Text ="خیر" ,Value = "0"}

                }
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterNewTeacher(TeacherRegisterDto model)
        {
            var nationalCode = model.NationalCode;
            var person = _db.Set<Person>().Include(p => p.User.Student).FirstOrDefault(p => p.NationalCode == nationalCode);


            if (person == null)
            {
                var newsteacher = new Teacher
                {
                    User = new User
                    {
                        Person = new Person
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            NationalCode = model.NationalCode,
                            MobileNo = model.CellPhoneNumber,
                            BirthDate = model.BirthDateJalali.ToGeorgianDateTime(),
                            BirthDateJalali = model.BirthDateJalali,
                            SexId = model.SexId,
                            FatherFirstName = model.FatherFirstName,
                        },
                        UserName = model.NationalCode,
                        Password = model.Password,
                        Status = true
                    },
                    MaritalStatusId = model.MaritalStatusId,
                    ReligionId = model.ReligionId,
                    EducationDegreeId = model.EducationDegreeId,
                    RecruitmentTypeId = model.RecruitmentTypeId,
                    MilitaryStatusId = model.MilitaryStatusId,
                    EducationDegreeFieldName = model.EducationDegreeFieldName,
                    EducationDegreeGrade = model.EducationDegreeGrade,
                    EducationDegreeGetDateJalali = model.EducationDegreeGetDateJalali,
                    EducationDegreeGetDate = model.EducationDegreeGetDateJalali.ToGeorgianDateTime(),
                    FatherName = model.FatherFirstName,

                    FreeAndOldSelectionDateJalali = model.FreeAndOldSelectionDateJalali,
                    FreeAndOldSelectionNumber = model.FreeAndOldSelectionNumber,
                    HaveWorkExperience = model.HaveWorkExperienceId > 0,
                    TeachExperienceInYear = model.TeachExperienceInYear,
                    WorkExperienceInYear = model.WorkExperienceInYear,
                    MidCareerTraining = model.MidCareerTraining > 0,
                    InsuranceNumber = model.InsuranceNumber,
                    EducationDegreeUniversityName = model.EducationDegreeUniversityName,
                    ChildCount = model.ChildCount,

                };
                _db.Entry(newsteacher).State = EntityState.Added;
                _db.SaveChanges();
            }
            //else
            //{
            //    if (person.User.Student == null)
            //    {
            //        person.User.Student = new Student
            //        {
            //            ParentFirstName = model.ParentFirstName,
            //            ParentLastName = model.ParentLastName,
            //            CityOfBirthId = model.CityOfBirthId.Value,
            //            CellPhoneNumber = model.CellPhoneNumber,
            //            PhoneNumber = model.PhoneNumber,
            //            CityOfHomeId = model.CityOfLocationId.Value
            //        };
            //        _db.Entry(person).State = EntityState.Modified;
            //        _db.SaveChanges();
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "دانش آموزی با این کد ملی از قبل وجود دارد. در صورتی که کد ملی را صحیح وارد نموده اید به بخش بازیابی رمز عبور مراجعه نمایید");
            //        return View(new StudentRegisterDto
            //        {

            //            Provinces = _db.Set<Province>().ToList().Select(p => new SelectListItem
            //            {
            //                Value = p.Id.ToString(),
            //                Text = p.Name
            //            }),
            //            Sexes = _db.Set<Sex>().ToList().Select(s => new SelectListItem
            //            {
            //                Text = s.Name,
            //                Value = s.Id.ToString()
            //            }),

            //        });
            //    }
            //}
            return RedirectToAction("/Account/TeacherSignIn");
        }







        [HttpPost]
        [AllowAnonymous]
        public ActionResult AjaxProvinceCities(int provinceId = 0)
        {
            var cities = _db.Set<Province>().Include(p => p.Cities).ToList().First(p => p.Id == provinceId).Cities.ToList().Select(c => new
            {
                Id = c.Id.ToString(),
                Text = c.Name
            });
            return Json(cities, JsonRequestBehavior.AllowGet);

        }

    }
}