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
        [HttpGet]
        public ActionResult Student(int sortBy = 1, bool isAsc = true)
        {
            IEnumerable<StudentModel> students;
            var studentlist = db.StudentProfiles.ToList();
            
            #region Sorting
            switch (sortBy)
            {
                case 1:
                    students = isAsc ? studentlist.OrderBy(s => s.LastName) : studentlist.OrderByDescending(s => s.LastName);
                    break;

                case 2:
                    students = isAsc ? studentlist.OrderBy(s => s.FirstName) : studentlist.OrderByDescending(s => s.FirstName);
                    break;

                case 3:
                    students = isAsc ? studentlist.OrderBy(s => s.StudentNumber) : studentlist.OrderByDescending(s => s.StudentNumber);
                    break;

                case 4:
                    students = isAsc ? studentlist.OrderBy(s => s.UserName) : studentlist.OrderByDescending(s => s.UserName);
                    break;

                case 5:
                    students = isAsc ? studentlist.OrderBy(s => s.BirthDate) : studentlist.OrderByDescending(s => s.BirthDate);
                    break;

                case 6:
                    students = isAsc ? studentlist.OrderBy(s => s.AcademicYear) : studentlist.OrderByDescending(s => s.AcademicYear);
                    break;

                default:
                    students = isAsc ? studentlist.OrderBy(s => s.LastName) : studentlist.OrderByDescending(s => s.LastName);
                    break;
            }
            #endregion

            ViewBag.SortBy = sortBy;
            ViewBag.IsAsc = isAsc;

            return View(students);
        }

        //
        // POST: /Admin/Student
        [HttpPost]
        public ActionResult Student(string searchString)
        {
            var students = from s in db.StudentProfiles select s;
            students = students.Where(s => (s.UserName.Contains(searchString)) || 
                                           (s.LastName.Contains(searchString)) ||
                                           (s.MiddleName.Contains(searchString)) ||
                                           (s.FirstName.Contains(searchString)) ||
                                           (s.StudentNumber.Contains(searchString))).OrderBy(s => s.LastName);

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
