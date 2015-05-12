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
 //   [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private UsersContext db = new UsersContext();
        private StudentContext dbStudent = new StudentContext();
        private ScholarshipContext dbScholarship = new ScholarshipContext();
        private FinancialContext dbFinancial = new FinancialContext();

        //
        // GET: /Student/MyInfo
        public ActionResult MyInfo()
        {
                return View();
        }

        //
        // GET: /Student/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Student/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String UserName)
        {
            try
            {
                if (Roles.IsUserInRole(UserName, "Student"))
                {
                    ViewBag.Message = "User already exists.";
                }
                else
                {
                    Roles.AddUserToRole(UserName, "Student");
                    ViewBag.Message = "User created successfully.";
                }
            }
            catch (InvalidOperationException)
            {
                ViewBag.Message = "User does not exist.";
            }

            return View();
        }

        // GET: /Student/CreatePersonalInfo
        public ActionResult CreatePersonalInfo()
        {
            return View();
        }

        //
        // POST: /Student/CreatePersonalInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePersonalInfo(StudentModel student)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbStudent.StudentProfiles.Add(student);
                    dbStudent.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        private IEnumerable<ModelError> GetRealErrors(IEnumerable<KeyValuePair<string, ModelState>> modelStateDictionary)
        {
            var errorMessages = new List<ModelError>();
            foreach (var keyValuePair in modelStateDictionary)
            {
                if (keyValuePair.Value.Errors.Count > 0)
                {
                    foreach (var error in keyValuePair.Value.Errors)
                    {
                        if (!error.ErrorMessage.Contains("Info"))
                        {
                            errorMessages.Add(error);
                        }
                    }
                }

            }
            return errorMessages;
        }

        //
        // GET: /Student/EditPersonalInfo
        public ActionResult EditPersonalInfo(int id = 1)
        {
            StudentModel student = dbStudent.StudentProfiles.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //
        // POST: /Student/EditPersonalInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonalInfo(StudentModel student)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbStudent.Entry(student).State = EntityState.Modified;
                    dbStudent.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        //
        // GET: /Student/CreateFinancialInfo
        public ActionResult CreateFinancialInfo()
        {
            return View();
        }

        //
        // POST: /Student/CreateFinancialInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFinancialInfo(StudentFinancialModel financial)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbFinancial.FinancialInfoProfiles.Add(financial);
                    dbFinancial.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(financial);
        }

        //
        // GET: /Student/EditFinancialInfo
        public ActionResult EditFinancialInfo(int id = 1)
        {
            StudentFinancialModel Financial = dbFinancial.FinancialInfoProfiles.Find(id);

            if (Financial == null)
            {
                return HttpNotFound();
            }

            return View(Financial);
        }

        //
        // POST: /Student/EditFinancialInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFinancialInfo(StudentFinancialModel student)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbStudent.Entry(student).State = EntityState.Modified;
                    dbStudent.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        // GET: /Student/CreateAcademicInfo
        public ActionResult CreateAcademicInfo()
        {
            return View();
        }

        //
        // POST: /Student/CreateAcademicInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAcademicInfo(ScholarshipModel Academic)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbScholarship.ScholarshipProfiles.Add(Academic);
                    dbScholarship.SaveChanges();
                    return RedirectToAction("Index", "MyInfo");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(Academic);
        }

        //
        // GET: /Student/EditAcademicInfo
        public ActionResult EditAcademicInfo(int id = 1)
        {
            StudentModel student = dbStudent.StudentProfiles.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //
        // POST: /Student/EditAcademicInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAcademicInfo(StudentModel student)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbStudent.Entry(student).State = EntityState.Modified;
                    dbStudent.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
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
        public ActionResult ScholarshipApplication()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}