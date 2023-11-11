using Microsoft.AspNetCore.Mvc;

namespace BasicASP.NET.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
