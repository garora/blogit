using System.Web.Mvc;
using BlogIT.Dal;

namespace BlogIT.Web.Controllers
{
    public class BuildDBController : Controller
    {
        // GET: BuildDB
        public ActionResult Index()
        {
            var cDB = new CreateDB();
            cDB.Database();

            return View();
        }
    }
}