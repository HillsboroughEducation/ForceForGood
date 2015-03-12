using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HillsboroughEducation.Models;

namespace HillsboroughEducation.Controllers
{
    public class StudentController : Controller
    {

        private UsersContext db = new UsersContext();
        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Student/MyInfo
        public ActionResult MyInfo()
        {
            return View();
        }

        //
        // GET: /Student/Scholarship
        public ActionResult Scholarship()
        {
            return View();
        }

        //
        // GET: /Student/Applications
        public ActionResult Application()
        {
            return View();
        }

    }

}