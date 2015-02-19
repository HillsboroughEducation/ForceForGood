using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HillsboroughEducation.Models;

namespace HillsboroughEducation.Controllers
{
    public class AdminController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Student
        public ActionResult Student(int sortBy = 1)
        {
            var students = from s in db.StudentProfiles
                           select s;
            #region Sorting
            switch (sortBy)
            {
                case 1:
                    students = students.OrderBy(s => s.LastName);
                    break;

                case 2:
                    students = students.OrderBy(s => s.FirstName);
                    break;

                case 3:
                    students = students.OrderBy(s => s.StudentNumber);
                    break;

                case 4:
                    students = students.OrderBy(s => s.UserName);
                    break;

                case 5:
                    students = students.OrderBy(s => s.BirthDate);
                    break;

                case 6:
                    students = students.OrderBy(s => s.AcademicYear);
                    break;

                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            #endregion

            return View(students);
        }

        //
        // POST: /Admin/Student
        [HttpPost]
        public ActionResult Student(string searchString)
        {

            var students = from s in db.StudentProfiles
                           select s;

            students = students.Where(s => (s.UserName.Contains(searchString)) ||
                                            (s.LastName.Contains(searchString)) ||
                                            (s.MiddleName.Contains(searchString)) ||
                                            (s.FirstName.Contains(searchString)) ||
                                            (s.StudentNumber.Contains(searchString)) ||
                                            (s.AcademicYear.Contains(searchString))).OrderBy(s => s.LastName);

            return View(students);
        }

        //
        // GET: /Admin/Scholarship
        public ActionResult Scholarship()
        {
            return View();
        }

        //
        // GET: /Admin/Reviewer
        public ActionResult Reviewer()
        {
            return View();
        }

        //
        // GET: /Admin/Donor
        public ActionResult Donor()
        {
            return View();
        }

    }
}
