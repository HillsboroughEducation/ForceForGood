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
        public ActionResult Scholarship(string sortOrder, string searchString)
        {
            ViewBag.ScholarShipNameSortParam = String.IsNullOrEmpty(sortOrder) ? "scholarshipName_desc" : "";
            ViewBag.ScholarShipTypeSortParam = sortOrder == "ScholarshipType" ? "scholarshipType_desc" : "ScholarshipType";
            ViewBag.AcademicYearSortParam = sortOrder == "AcademicYear" ? "academicYear_desc" : "AcademicYear";
            var scholarships = from s in db.ScholarshipProfiles
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                scholarships = scholarships.Where(s => (s.ScholarshipName.Contains(searchString)) ||
                                            (s.ScholarshipType.Contains(searchString)) ||
                                            (s.AcademicYear.Contains(searchString))).OrderBy(s => s.ScholarshipName);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "scholarshipName_desc":
                    scholarships = scholarships.OrderByDescending(s => s.ScholarshipName);
                    break;

                case "ScholarshipType":
                    scholarships = scholarships.OrderBy(s => s.ScholarshipType);
                    break;

                case "scholarshipType_desc":
                    scholarships = scholarships.OrderByDescending(s => s.ScholarshipType);
                    break;

                case "AcademicYear":
                    scholarships = scholarships.OrderBy(s => s.AcademicYear);
                    break;

                case "academicYear_desc":
                    scholarships = scholarships.OrderByDescending(s => s.AcademicYear);
                    break;

                default:
                    scholarships = scholarships.OrderBy(s => s.ScholarshipName);
                    break;
            }
            #endregion

            return View(scholarships.ToList());
        }

        //
        // GET: /Student/Application
        public ActionResult Application()
        {
            return View();
        }

    }

}