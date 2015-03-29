using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HillsboroughEducation.Models;
using System.Data;
using System.Data.Objects;

namespace HillsboroughEducation.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private UsersContext db = new UsersContext();
        private ScholarshipContext dbScholarship = new ScholarshipContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Student
        public ActionResult Student(string sortOrder, string searchString)
        {
            ViewBag.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            ViewBag.FirstNameSortParam = sortOrder == "FirstName" ? "firstName_desc" : "FirstName";
            ViewBag.StudentNumberSortParam = sortOrder == "StudentNumber" ? "studentNumber_desc" : "StudentNumber";
            ViewBag.UserNameSortParam = sortOrder == "UserName" ? "userName_desc" : "UserName";
            ViewBag.BirthDateSortParam = sortOrder == "BirthDate" ? "birthDate_desc" : "BirthDate";
            ViewBag.AcademicYearSortParam = sortOrder == "AcademicYear" ? "academicYear_desc" : "AcademicYear";
            var students = from s in db.StudentProfiles
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => (s.UserName.Contains(searchString)) ||
                                            (s.LastName.Contains(searchString)) ||
                                            (s.MiddleName.Contains(searchString)) ||
                                            (s.FirstName.Contains(searchString)) ||
                                            (s.StudentNumber.Contains(searchString)) ||
                                            (s.AcademicYear.Contains(searchString))).OrderBy(s => s.LastName);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "lastName_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;

                case "FirstName":
                    students = students.OrderBy(s => s.FirstName);
                    break;

                case "firstName_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;

                case "StudentNumber":
                    students = students.OrderBy(s => s.StudentNumber);
                    break;

                case "studenNumber_desc":
                    students = students.OrderByDescending(s => s.StudentNumber);
                    break;

                case "UserName":
                    students = students.OrderBy(s => s.UserName);
                    break;

                case "userName_desc":
                    students = students.OrderByDescending(s => s.UserName);
                    break;

                case "BirthDate":
                    students = students.OrderBy(s => s.BirthDate);
                    break;

                case "birthDate_desc":
                    students = students.OrderByDescending(s => s.BirthDate);
                    break;

                case "AcademicYear":
                    students = students.OrderBy(s => s.AcademicYear);
                    break;

                case "academicYear_desc":
                    students = students.OrderByDescending(s => s.AcademicYear);
                    break;

                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            #endregion

            return View(students.ToList());
        }

        //
        // GET: /Admin/StudentInfo
        public ActionResult StudentInfo(int id = 1)
        {
            StudentModel student = db.StudentProfiles.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult StudentFinancialInfo(int id = 1)
        {
            StudentFinancialModel financialInfo = db.FinancialInfoProfiles.Find(id);
            if (financialInfo.FinancialNeedEligible.Equals("y"))
            {
                financialInfo.FinancialNeedEligible = "Yes";
            }
            else if (financialInfo.FinancialNeedEligible.Equals("n"))
            {
                financialInfo.FinancialNeedEligible = "No";
            }

            if (financialInfo.ReceivedSSCard.Equals("y"))
            {
                financialInfo.ReceivedSSCard = "Yes";
            }
            else if (financialInfo.ReceivedSSCard.Equals("n"))
            {
                financialInfo.ReceivedSSCard = "No";
            }
            if (financialInfo == null)
            {
                return HttpNotFound();
            }
            return View(financialInfo);
        }

        public ActionResult StudentScholarship(int id = 1)
        {
            ScholarshipModel scholarshipInfo = dbScholarship.ScholarshipProfiles.Find(id);

            if (scholarshipInfo == null)
            {
                return HttpNotFound();
            }

            return View(scholarshipInfo);
        }

        //
        // GET: /Admin/Scholarship
        public ActionResult Scholarship(string sortOrder, string searchString)
        {
            ViewBag.ScholarShipNameSortParam = String.IsNullOrEmpty(sortOrder) ? "scholarshipName_desc" : "";
            ViewBag.ScholarShipTypeSortParam = sortOrder == "ScholarshipType" ? "scholarshipType_desc" : "ScholarshipType";
            ViewBag.AcademicYearSortParam = sortOrder == "AcademicYear" ? "academicYear_desc" : "AcademicYear";
            ViewBag.NumOfApplicantsSortParam = sortOrder == "NumOfApplicants" ? "numOfApplicants_desc" : "NumOfApplicants";
            ViewBag.AmountSortParam = sortOrder == "Amount" ? "amount_desc" : "Amount";
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

                case "NumOfApplicants":
                    scholarships = scholarships.OrderBy(s => s.AcademicYear);
                    break;

                case "numOfApplicants_desc":
                    scholarships = scholarships.OrderByDescending(s => s.AcademicYear);
                    break;

                case "Amount":
                    scholarships = scholarships.OrderBy(s => s.AcademicYear);
                    break;

                case "amount_desc":
                    scholarships = scholarships.OrderByDescending(s => s.AcademicYear);
                    break;

                default:
                    scholarships = scholarships.OrderBy(s => s.ScholarshipName);
                    break;
            }
            #endregion

            return View(scholarships.ToList());
        }

        public ActionResult ScholarshipInfo(int id = 1)
        {
            ScholarshipModel scholarship = dbScholarship.ScholarshipProfiles.Find(id);

            if (scholarship == null)
            {
                return HttpNotFound();
            }

            return View(scholarship);
        }

        //
        // GET:  /Admin/CreateScholarship
        public ActionResult CreateScholarship()
        {
            return View();
        }

        //
        // POST: /Admin/CreateScholarship
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateScholarship([Bind(Include = "ScholarshipName, ScholarshipType, AcademicYear, NumOfApplicants, Amount")] ScholarshipModel scholarship)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbScholarship.ScholarshipProfiles.Add(scholarship);
                    dbScholarship.SaveChanges();                   
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(scholarship);
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
