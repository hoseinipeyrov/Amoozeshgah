using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Controllers
{
    public class ImageViewerController : Controller
    {
        // GET: ImageViewer
        public ActionResult Index(string id)
        {
            var file = id.Split('.')[0];
            var words = file.Split('-');
            if (words[0] == "dscnt")
            {
                var courseId = words[1];
                var studentId= words[2];
                


                var imageFile = Server.MapPath($"/wwwroot/images/uploaded/discount/{words[1]}/{words[2]}/{id}");
                var srcImage = Image.FromFile(imageFile);
                using (var streak = new MemoryStream())
                {
                    srcImage.Save(streak, ImageFormat.Png);
                    return File(streak.ToArray(), "image/png");
                }
            }

            return View();

        }
    }
}