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

        //
        // GET: /Admin/Scholarship
        public ActionResult Scholarship(string sortOrder, string searchString)
        {
            ViewBag.ScholarShipNameSortParam = String.IsNullOrEmpty(sortOrder) ? "scholarshipName_desc" : "";
            ViewBag.ScholarShipTypeSortParam = sortOrder == "ScholarshipType" ? "scholarshipType_desc" : "ScholarshipType";
            ViewBag.AcademicYearSortParam = sortOrder == "AcademicYear" ? "academicYear_desc" : "AcademicYear";
            ViewBag.NumOfApplicantsSortParam = sortOrder == "NumOfApplicants" ? "numOfApplicants_desc" : "NumOfApplicants";
            ViewBag.AmountSortParam = sortOrder == "Amount" ? "amount_desc" : "Amount";
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
