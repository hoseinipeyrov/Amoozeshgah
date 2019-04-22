using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Amoozeshgah.ViewModel;
using Amoozeshgah.WebUI.Domain;
using Amoozeshgah.Services;
using Amoozeshgah.WebUI.Filters;

namespace Amoozeshgah.WebUI.Controllers
{
    public class LanguagesController : Controller
    {
        ILanguageService languageService;

        public LanguagesController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }
        public ActionResult Index()
        {
            return View(new LanguageDto());
        }
        [HttpGet, AjaxOnly]
        public JsonResult GetLanguages()
        {

            var languages = languageService.GetLanguagesDto(WebUserInfo.UserBranchId);

            return Json(new { data = languages }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet, AjaxOnly]
        public ActionResult Add()
        {
            return View(new LanguageDto());
        }
        [HttpPost]
        public ActionResult Add(LanguageDto model)
        {
            try
            {
                languageService.CreateNewLanguageDto(model);

                var successMessage = $"نوع دپارتمان {model.NameFa} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                failMessage += $" {ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Languages/Create
        //public ActionResult CreateCustomLanguage()
        //{
        //    return View();
        //}

        //// POST: Languages/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateCustomLanguage(CustomLanguageTypeDto viewModel)
        //{
        //    var userBranchId = WebUserInfo.UserBranchId;
        //    var languageCenterId = db.LanguageCentershierarchies.FirstOrDefault(lch => lch.BrancheId == userBranchId).LanguageCenterId;


        //    if (ModelState.IsValid)
        //    {
        //        var language = new Language
        //        {
        //            Name = viewModel.Name,
        //            NameFa = viewModel.NameFa,
        //            EducationalLanguageCenterId = languageCenterId
        //        };
        //        db.Languages.Add(language);
        //        db.SaveChanges();
        //        return RedirectToAction("CreateCustomLanguage");
        //    }

        //    return View(viewModel);
        //}

        //// GET: Languages/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Language language = db.Languages.Find(id);
        //    if (language == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EducationalLanguageCenterId = new SelectList(db.EducationalLanguageCenters, "Id", "Id", language.EducationalLanguageCenterId);
        //    return View(language);
        //}

        //// POST: Languages/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,NameFa,EducationalLanguageCenterId")] Language language)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(language).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EducationalLanguageCenterId = new SelectList(db.EducationalLanguageCenters, "Id", "Id", language.EducationalLanguageCenterId);
        //    return View(language);
        //}

        //// GET: Languages/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Language language = db.Languages.Find(id);
        //    if (language == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(language);
        //}

        //// POST: Languages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Language language = db.Languages.Find(id);
        //    db.Languages.Remove(language);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
