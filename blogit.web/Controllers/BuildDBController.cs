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
            using (var session = blogit.dal.NHibernatecfg.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var CountryObj = new Country { CountryName = "IRAN" };
                    session.Save(CountryObj);
                    transaction.Commit();
                    Console.WriteLine("Country was inserted : " + CountryObj.CountryName);
                }

            } 
            return View();
        }
    }
}