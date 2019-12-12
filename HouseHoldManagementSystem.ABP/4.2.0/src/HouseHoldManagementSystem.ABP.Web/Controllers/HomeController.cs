using Microsoft.AspNetCore.Mvc;

namespace HouseHoldManagementSystem.ABP.Web.Controllers
{
    public class HomeController : ABPControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}