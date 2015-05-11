using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HillsboroughEducation.Models;
using System.Data;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Web.Security;

namespace HillsboroughEducation.Controllers
{
    [Authorize(Roles = "Reviewer")]
    public class ReviewerController : Controller
    {
        private UsersContext db = new UsersContext();
        private ScholarshipContext dbScholarship = new ScholarshipContext();

        //
        // GET: /Reviewer/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String UserName)
        {
            try
            {
                if (Roles.IsUserInRole(UserName, "Reviewer"))
                {
                    ViewBag.Message = "User already exists.";
                }
                else
                {
                    Roles.AddUserToRole(UserName, "Reviewer");
                    ViewBag.Message = "User created successfully.";
                }
            }
            catch (InvalidOperationException)
            {
                ViewBag.Message = "User does not exist.";
            }

            return View();
        }

        //
        // GET: /Reiewer/ReviewerInfo
        public ActionResult ReviewerInfo(int id = 1)
        {
            StudentModel Reviewer = db.StudentProfiles.Find(id);
            if (Reviewer == null)
            {
                return HttpNotFound();
            }
            return View(Reviewer);
        }

        //
        // GET: /Reviewer/Dashboard
        public ActionResult Dashboard(string sortOrder, string searchString)
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
        // GET: /Reviewer/ReviewApplications
        public ActionResult ReviewApplications()
        {
            return View();
        }
    }
}