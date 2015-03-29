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
        private ScholarshipContext dbScholarship = new ScholarshipContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Student/MyInfo
        public ActionResult MyInfo(int id = 1)
        {
            StudentModel studentinfo = db.StudentProfiles.Find(id);
            if (studentinfo == null)
            {
                return HttpNotFound();
            }
            return View(studentinfo);
        }

        public ActionResult FinancialInfo(int id = 1)
        {
            StudentFinancialModel financialinfo = db.FinancialInfoProfiles.Find(id);
            if (financialinfo == null)
            {
                return HttpNotFound();
            }
            return View(financialinfo);
        }

        //
        // GET: /Student/Scholarship
        public ActionResult Scholarship(string sortOrder, string searchString)
        {
            ViewBag.ScholarShipNameSortParam = String.IsNullOrEmpty(sortOrder) ? "scholarship Name_desc" : "";
            ViewBag.ScholarShipTypeSortParam = sortOrder == "Scholarship Type" ? "scholarship Type_desc" : "Scholarship Type";
            ViewBag.AcademicYearSortParam = sortOrder == "Academic Year" ? "academic Year_desc" : "Academic Year";
            var scholarships = from s in dbScholarship.ScholarshipProfiles
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
                case "scholarship Name_desc":
                    scholarships = scholarships.OrderByDescending(s => s.ScholarshipName);
                    break;

                case "Scholarship Type":
                    scholarships = scholarships.OrderBy(s => s.ScholarshipType);
                    break;

                case "scholarship Type_desc":
                    scholarships = scholarships.OrderByDescending(s => s.ScholarshipType);
                    break;

                case "Academic Year":
                    scholarships = scholarships.OrderBy(s => s.AcademicYear);
                    break;

                case "academic Year_desc":
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

        public ActionResult testmyinfo()
        {
            return View();
        }
    }
}