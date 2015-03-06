using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blogit.dal;


namespace blogit.web.Controllers
{
    public class BuildDBController : Controller
    {
        // GET: BuildDB
        public ActionResult Index()
        {
            CreateDB cDB = new CreateDB();
            cDB.Database();

            return View();
        }
    }
}