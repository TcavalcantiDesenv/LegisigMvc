using PlatinDashboard.Application.Interfaces;
using PlatinDashboard.Presentation.MVC.MvcFilters;
using System.Linq;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Controllers
{
    public class VideosController : BaseController
    {
        private readonly IVideoAppService _videoAppService;
        public VideosController(IUserAppService userAppService,
                                  ICompanyAppService companyAppService,
                                  IVideoAppService videoAppService)
                                  : base(userAppService, companyAppService)
        {
            _videoAppService = videoAppService;
        }

        [HttpGet]
        [ClaimsAuthorize("ChartMeusVideos", "Allowed")]
        public ActionResult MeusVideos()
        {
            var videoViewModels = _videoAppService.GetByCompany(CompanyUser.CompanyId).ToList();
            for (int i = 0; i < videoViewModels.Count(); i++)
            {
                if (!System.IO.File.Exists(Server.MapPath(videoViewModels[i].FileName)))
                {
                    videoViewModels.RemoveAt(i);
                }
            }
            videoViewModels = videoViewModels.OrderBy(v => v.Title).ToList();
            ViewBag.Cliente = (Session["userId"] == null ? "" : LoggedUser.Name);
            return View(videoViewModels);
        }

        [HttpGet]
        [ClaimsAuthorize("ChartVideosPlatin", "Allowed")]
        public ActionResult VideosPlatin()
        {
            var videoViewModels = _videoAppService.GetPublicVideos().ToList();
            for (int i = 0; i < videoViewModels.Count(); i++)
            {
                if (!System.IO.File.Exists(Server.MapPath(videoViewModels[i].FileName)))
                {
                    videoViewModels.RemoveAt(i);
                }
            }
            videoViewModels = videoViewModels.OrderBy(v => v.Title).ToList();
            return View(videoViewModels);
        }
    }
}