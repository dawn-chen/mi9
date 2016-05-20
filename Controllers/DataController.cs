using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mi9.Controllers
{

    public class DataController : Controller
    {
        private const string JsonParseError = "Could not decode request: JSON parsing failed";

        [HttpPost]
        public JsonResult FilterData(PayLoadRequest request)
        {
            if (request == null || request.PayLoad == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = JsonParseError });
            }
            try
            {
                var filterResult = request.PayLoad.Where(p => p.Drm && p.EpisodeCount > 0).Select(p => new
                {
                    image = p.Image.ShowImage,
                    slug = p.Slug,
                    title = p.Title
                }).ToList();
                return Json(new { response = filterResult });
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = JsonParseError });
            }

        }

    }
}
