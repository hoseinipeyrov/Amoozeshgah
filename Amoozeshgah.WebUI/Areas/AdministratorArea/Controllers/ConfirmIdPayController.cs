using Amoozeshgah.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common;
using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class ConfirmIdPayController : Controller
    {
        private readonly AppContext _db = new AppContext();

        // private readonly int _areaId = WebUserInfo.SiteId;
        private const int _areaId = 1111;

        [HttpGet]
        public ActionResult Index()
        {
            //   var accounts=_db.Set<EducationalCenter>().Include("AccountInformations").Where(ec=>ec.AreaId== _areaId).
            var accounts = _db.Set<AccountInformation>().Include(account => account.EducationalCenter.Site)
                .Where(account => account.EducationalCenter.AreaId == _areaId).ToList().Select(account =>
                    new AreaConfirmIdPayDto
                    {
                        EducationalCenterCode = account.EducationalCenterId,
                        EducationalCenterName = account.EducationalCenter.Site.Name,
                        EducationalCenterCategory = account.EducationalCenter.Category,
                        IdPay = account.IdPay,
                        IdPayStatus = account.IsConfermed.ToIdPayStatus(),
                        IdPayButtons = account.IsConfermed.GenerateButtons(account.EducationalCenterId)
                    });

            return View(accounts);
        }

        [HttpPost]
        public ActionResult Index(int? Agree, int? DisAgree)
        {
            if (Agree.HasValue)
            {
                var account = _db.Set<AccountInformation>().First(ai => ai.EducationalCenterId == Agree.Value);
                account.IsConfermed = true;
                account.ConfermedBy = WebUserInfo.UserId.ToString();
                account.ConfermedDate = DateTime.Now;
                account.ConfermedDateJalali = DateTime.Now.ToJalalDateTime(DateFormat.FullDateTime);
                _db.Entry(account).State = EntityState.Modified;


            }
            else if (DisAgree.HasValue)
            {
                var account = _db.Set<AccountInformation>().First(ai => ai.EducationalCenterId == DisAgree.Value);
                account.IsConfermed = false;
                account.ConfermedBy = WebUserInfo.UserId.ToString();
                account.ConfermedDate = DateTime.Now;
                account.ConfermedDateJalali = DateTime.Now.ToJalalDateTime(DateFormat.FullDateTime);
                _db.Entry(account).State = EntityState.Modified;
               
            }

            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
