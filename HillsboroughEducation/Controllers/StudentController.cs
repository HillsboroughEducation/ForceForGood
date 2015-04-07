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

        //
        // GET: /Student/CreatePersonalInfo
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
                    return RedirectToAction("Index", "MyInfo");
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
        // GET: /Student/CreateFinancialInfo
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
                    return RedirectToAction("Index", "MyInfo");
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

        /*
        // GET: /Student/CreateAcademicInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAcademicInfo(CriteriaModel criteria)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbCriteria.CriteriaProfiles.Add(criteria);
                    dbCriteria.SaveChanges();
                    return RedirectToAction("Index", "MyInfo");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(criteria);
        } */

        //
        // Get: /Student/DeletePersonalInfo
        public ActionResult DeletePersonalInfo(int id, bool? concurrencyError)
        {
           StudentModel student = db.StudentProfiles.Find(id);

           if (concurrencyError.GetValueOrDefault())
           {
              if (student == null)
              {
                 ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                     + "was deleted by another user after you got the original values. "
                     + "Click the Back to List hyperlink.";
              }
              else
              {
                 ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                     + "was modified by another user after you got the original values. "
                     + "The delete operation was canceled and the current values in the "
                     + "database have been displayed. If you still want to delete this "
                     + "record, click the Delete button again. Otherwise "
                     + "click the Back to List hyperlink.";
              }
           }

           return View(student);
        }

        //
        // POST: /Student/DeletePeronalInfo/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePersonalInfo(StudentModel student)
        {
           try
           {
              db.Entry(student).State = EntityState.Deleted;
              db.SaveChanges();
              return RedirectToAction("MyInfo");
           }
           catch (DbUpdateConcurrencyException)
           {
              return RedirectToAction("DeletePersonalInfo", new { concurrencyError = true });
           }
           catch (DataException /* dex */)
           {
              //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
              ModelState.AddModelError(string.Empty, "Unable to delete. Try again, and if the problem persists contact your system administrator.");
              return View(student);
           }
        }

        //
        // Get: /Student/DeleteFinancialInfo
        public ActionResult DeleteFinancialInfo(int id, bool? concurrencyError)
        {
            StudentFinancialModel financial = db.FinancialInfoProfiles.Find(id);

            if (concurrencyError.GetValueOrDefault())
            {
                if (financial == null)
                {
                    ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                        + "was deleted by another user after you got the original values. "
                        + "Click the Back to List hyperlink.";
                }
                else
                {
                    ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                        + "was modified by another user after you got the original values. "
                        + "The delete operation was canceled and the current values in the "
                        + "database have been displayed. If you still want to delete this "
                        + "record, click the Delete button again. Otherwise "
                        + "click the Back to List hyperlink.";
                }
            }

            return View(financial);
        }

        //
        // POST: /Student/DeleteFinancialInfo/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFinancialInfo(StudentFinancialModel financial)
        {
            try
            {
                db.Entry(financial).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("MyInfo");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("DeleteFinancialInfo", new { concurrencyError = true });
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to delete. Try again, and if the problem persists contact your system administrator.");
                return View(financial);
            }
        }

        /*
        // Get: /Student/DeleteAcademicInfo
        public ActionResult DeleteAcademicInfo(int id, bool? concurrencyError)
        {
            Criteriamodel criteria = db.CriteriaProfiles.Find(id);

            if (concurrencyError.GetValueOrDefault())
            {
                if (criteria == null)
                {
                    ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                        + "was deleted by another user after you got the original values. "
                        + "Click the Back to List hyperlink.";
                }
                else
                {
                    ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                        + "was modified by another user after you got the original values. "
                        + "The delete operation was canceled and the current values in the "
                        + "database have been displayed. If you still want to delete this "
                        + "record, click the Delete button again. Otherwise "
                        + "click the Back to List hyperlink.";
                }
            }

            return View(criteria);
        }

 
        // POST: /Student/DeleteAcademicInfo/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAcademicInfo(CriteriaModel criteria)
        {
            try
            {
                db.Entry(criteria).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("MyInfo");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("DeleteAcademicInfo", new { concurrencyError = true });
            }
            catch (DataException */ /* dex */ /*)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to delete. Try again, and if the problem persists contact your system administrator.");
                return View(criteria);
            }
        } */

        //
        // GET: /Student/EditPersonalInfo/5

        public ActionResult EditPersonalInfo(int id = 0)
        {
            StudentModel student = db.StudentProfiles.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.StudentProfiles, "UserID", "FirstName", student.UserId);
            return View(student);
        }

        //
        // POST: /Student/EditPersonalInfo/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonalInfo([Bind(Include = "FirstName, LastName, SocialSecurity, StudentNumber, Country, Gender, Ethnicity, Date of Birth, Address1, Address2, City, State, County, PostalCode, HomePhone, WorkPhone, CellPhone, UserName")]StudentModel student)
        {
            try
            {
           //     if (ModelState.IsValid)
           //     {
           //         ValidateOneAdministratorAssignmentPerInstructor(student);
           //     }
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("MyInfo");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (StudentModel)entry.Entity;
                var databaseValues = (StudentModel)entry.GetDatabaseValues().ToObject();

                if (databaseValues.FirstName != clientValues.FirstName)
                    ModelState.AddModelError("FirtName", "Current value: "
                        + databaseValues.FirstName);
                if (databaseValues.LastName != clientValues.LastName)
                    ModelState.AddModelError("LastName", "Current value: "
                        + databaseValues.LastName);
                if (databaseValues.SocialSecurity != clientValues.SocialSecurity)
                    ModelState.AddModelError("SocialSecurity", "Current value: "
                        + databaseValues.SocialSecurity);
                if (databaseValues.StudentNumber != clientValues.StudentNumber)
                    ModelState.AddModelError("StudentNumber", "Current value: "
                        + databaseValues.StudentNumber);
                if (databaseValues.Country != clientValues.Country)
                    ModelState.AddModelError("Country", "Current value: "
                        + databaseValues.Country);
                if (databaseValues.Gender != clientValues.Gender)
                    ModelState.AddModelError("Gender", "Current value: "
                        + databaseValues.Gender);
                if (databaseValues.Ethnicity != clientValues.Ethnicity)
                    ModelState.AddModelError("Ethnicity", "Current value: "
                        + databaseValues.Ethnicity);
                if (databaseValues.BirthDate != clientValues.BirthDate)
                    ModelState.AddModelError("BirthDate", "Current value: "
                        + String.Format("{0:c}", databaseValues.BirthDate));
                if (databaseValues.Address1 != clientValues.Address1)
                    ModelState.AddModelError("Address1", "Current value: "
                        + databaseValues.Address1);
                if (databaseValues.Address2 != clientValues.Address2)
                    ModelState.AddModelError("Address2", "Current value: "
                        + databaseValues.Address2);
                if (databaseValues.City != clientValues.City)
                    ModelState.AddModelError("City", "Current value: "
                        + databaseValues.City);
                if (databaseValues.State != clientValues.State)
                    ModelState.AddModelError("State", "Current value: "
                        + databaseValues.State);
                if (databaseValues.County != clientValues.County)
                    ModelState.AddModelError("County", "Current value: "
                        + databaseValues.County);
                if (databaseValues.PostalCode != clientValues.PostalCode)
                    ModelState.AddModelError("PostalCode", "Current value: "
                        + databaseValues.PostalCode);
                if (databaseValues.HomePhone != clientValues.HomePhone)
                    ModelState.AddModelError("HomePhone", "Current value: "
                        + databaseValues.HomePhone);
                if (databaseValues.WorkPhone != clientValues.WorkPhone)
                    ModelState.AddModelError("WorkPhone", "Current value: "
                        + databaseValues.WorkPhone);
                if (databaseValues.CellPhone != clientValues.CellPhone)
                    ModelState.AddModelError("CellPhone", "Current value: "
                        + databaseValues.CellPhone);
                if (databaseValues.UserName != clientValues.UserName)
                    ModelState.AddModelError("UserName ", "Current value: "
                        + databaseValues.UserName);
                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                    + "was modified by another user after you got the original value. The "
                    + "edit operation was canceled and the current values in the database "
                    + "have been displayed. If you still want to edit this record, click "
                    + "the Save button again. Otherwise click the Back to List hyperlink.");
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

         //   ViewBag.UserID = new SelectList(db.StudentProfiles, "UserID ", "FirstName", student.UserID);
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