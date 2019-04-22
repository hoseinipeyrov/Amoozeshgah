using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Controllers
{
    public class EducationalCentersInformatinsController : Controller
    {
        private readonly AppContext _db;

        public EducationalCentersInformatinsController()
        {
            _db = new AppContext();
        }
        [HttpGet]
        public ActionResult SearchEducationalCenters()
        {
            var searchEducationalCenterDto = new SearchEducationalCenterDto
            {
                Provinces = _db.Set<Province>().ToList().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }),
                Areas = new List<SelectListItem>
                {

                    new SelectListItem
                    {
                        Text = "همه ناحیه ها",
                        Value = "1"
                    }
                },
                Sexes = _db.Set<Sex>().ToList().Select(p => new SelectListItem
                {
                    Text = p.Title,
                    Value = p.Id.ToString()
                }),
                EducationalCenterCategories = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "مرکز زبان خارجه",
                        Value = "مرکز زبان خارجه"
                    },
                    new SelectListItem
                    {
                        Text = "مرکز علمی آزاد",
                        Value = "مرکز علمی آزاد"
                    }
                }
            };
            return View(searchEducationalCenterDto);
        }

        [HttpPost]
        public ActionResult SearchEducationalCenters(SearchEducationalCenterDto model)
        {
            var allEducationalCenters = _db.Set<EducationalCenter>()
                .Include(ec => ec.Site)
                .Include(ec => ec.Area.Province)
                .Include(ec => ec.Area.Site)
                .Include(ec => ec.Sex)
                .Where(ec => ec.SexId == model.SexId)
                .Where(ec=>ec.Category==model.EducationalCenterCategory)
                .Where(ec=> model.EducationalCenterCode==null || ec.Id==model.EducationalCenterCode)
                .Where(ec => model.EducationalCenterName==null || ec.Site.Name.Contains(model.EducationalCenterName))

                .AsQueryable();

            var educationalCenters = model.AreaId <= 0 ?
                allEducationalCenters.Where(ec => ec.Area.ProvinceId == model.ProvinceId) :
                allEducationalCenters.Where(ec => ec.AreaId == model.AreaId);

            var r = educationalCenters.ToList().Select(ec => new
            {
                EducationalCenterName = ec.Site.Name,
                EducationalCenterCode = ec.Id,
                Province = ec.Area.Province.Name,
                Area = ec.Area.Site.Name,
                Category = ec.Category,
                Sex = ec.Sex.Title
            });
            return Json(r, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]

        public ActionResult AjaxEducationalCenterDetails(int educationalCenterCode)
        {
            var educationalCenter = _db.Set<EducationalCenter>()
                                           .Include(ec => ec.Area.Province)
                                           .Include(ec => ec.Area.Site)
                                          .Include(ec => ec.Site)
                                          .Include(ec => ec.Sex)
                                          .First(ec => ec.Id == educationalCenterCode);
            var detail = $@"مشخصات مرکز آموزشی 
                                <strong>{educationalCenter.Site.Name}</strong>
                                <hr />
                                <div class='row'>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>ناحیه: </label>
                                     <strong>{educationalCenter.Area.Site.Name}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>استان: </label>
                                     <strong>{educationalCenter.Area.Province.Name}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>نشانی: </label>
                                     <strong>{educationalCenter.Site.Address}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>تلفن تماس: </label>
                                     <strong>{educationalCenter.Site.PhoneNo1}</strong>
                                     &nbsp;&nbsp;&nbsp;
                                     <strong>{educationalCenter.Site.PhoneNo2}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>جنسیت: </label>
                                     <strong>{educationalCenter.Sex.Title}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>نوع: </label>
                                     <strong>{educationalCenter.Category}</strong>
                                </div>
                            </div>
                            ";
            return Json(detail, JsonRequestBehavior.AllowGet);
        }
    }
}