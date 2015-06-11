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
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private UsersContext db = new UsersContext();
        private ScholarshipContext dbScholarship = new ScholarshipContext();
        private ReviewerContext dbReviewer = new ReviewerContext();
        private DonorContext dbDonor = new DonorContext();
        private CriteriaContext dbCriteria = new CriteriaContext();

        //
        // GET: /Admin/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Admin/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String UserName)
        {
            try
            {
                if (Roles.IsUserInRole(UserName, "Admin"))
                {
                    ViewBag.Message = "User already exists.";
                }
                else
                {
                    Roles.AddUserToRole(UserName, "Admin");
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
                scholarships = scholarships.Where(s => (s.TITLE.Contains(searchString)) ||
                                            (s.TYPE.Contains(searchString))).OrderBy(s => s.TITLE);

                if (scholarships.Count() == 0)
                {
                    scholarships = (from s in dbScholarship.ScholarshipProfiles
                                   select s).OrderBy(s => s.TITLE);
                }
            }

            #region Sorting
            switch (sortOrder)
            {
                case "scholarshipName_desc":
                    scholarships = scholarships.OrderByDescending(s => s.TITLE);
                    break;

                case "ScholarshipType":
                    scholarships = scholarships.OrderBy(s => s.TYPE);
                    break;

                case "scholarshipType_desc":
                    scholarships = scholarships.OrderByDescending(s => s.TYPE);
                    break;

                case "AcademicYear":
                    scholarships = scholarships.OrderBy(s => s.DATE_AVAILABLE.Year);
                    break;

                case "academicYear_desc":
                    scholarships = scholarships.OrderByDescending(s => s.DATE_AVAILABLE.Year);
                    break;

                case "NumOfApplicants":
                    scholarships = scholarships.OrderBy(s => s.AMOUNT_TYPE);
                    break;

                case "numOfApplicants_desc":
                    scholarships = scholarships.OrderByDescending(s => s.AMOUNT_TYPE);
                    break;

                case "Amount":
                    scholarships = scholarships.OrderBy(s => s.TOTAL_FUNDS);
                    break;

                case "amount_desc":
                    scholarships = scholarships.OrderByDescending(s => s.TOTAL_FUNDS);
                    break;

                default:
                    scholarships = scholarships.OrderBy(s => s.TITLE);
                    break;
            }
            #endregion

            return View(scholarships.ToList());
        }

        //
        // GET: /Admin/ScholarshipInfo
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
        public ActionResult CreateScholarship(ScholarshipModel scholarship)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbScholarship.ScholarshipProfiles.Add(scholarship);
                    dbScholarship.SaveChanges();              
                    return RedirectToAction("Scholarship", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(scholarship);
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
        // GET: /Admin/Reviewer
        public ActionResult Reviewer(String sortOrder, String searchString)
        {
            ViewBag.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            ViewBag.FirstNameSortParam = sortOrder == "FirstName" ? "firstName_desc" : "FirstName";
            ViewBag.AcademicYearSortParam = sortOrder == "AcademicYear" ? "academicYear_desc" : "AcademicYear";
            var reviewers = from r in dbReviewer.ReviewerProfiles
                           select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                reviewers = reviewers.Where(s => (s.LAST_NAME.Contains(searchString)) ||
                                            (s.FIRST_NAME.Contains(searchString)) ||
                                            (s.ACADEMIC_YEAR.Contains(searchString))).OrderBy(s => s.LAST_NAME);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "lastName_desc":
                    reviewers = reviewers.OrderByDescending(r => r.LAST_NAME);
                    break;

                case "FirstName":
                    reviewers = reviewers.OrderBy(s => s.FIRST_NAME);
                    break;

                case "firstName_desc":
                    reviewers = reviewers.OrderByDescending(r => r.FIRST_NAME);
                    break;

                case "AcademicYear":
                    reviewers = reviewers.OrderBy(r => r.ACADEMIC_YEAR);
                    break;

                case "academicYear_desc":
                    reviewers = reviewers.OrderByDescending(r => r.ACADEMIC_YEAR);
                    break;

                default:
                    reviewers = reviewers.OrderBy(r => r.LAST_NAME);
                    break;
            }
            #endregion

            return View(reviewers.ToList());
        }

        // GET: /Admin/CreateReviewer
        public ActionResult CreateReviewer()
        {
            return View();
        }

        // POST: /Admin/CreateReviewer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReviewer(Reviewers reviewer)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbReviewer.ReviewerProfiles.Add(reviewer);
                    dbReviewer.SaveChanges();
                    return RedirectToAction("Reviewer", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(reviewer);
        }

        public ActionResult ReviewerInfo(int id = 1)
        {
            Reviewers reviewer = dbReviewer.ReviewerProfiles.Find(id);

            if (reviewer == null)
            {
                return HttpNotFound();
            }

            return View(reviewer);
        }

        //
        // GET:  /Admin/EditReviewer
        public ActionResult EditReviewer(int id = 1)
        {
            Reviewers reviewer = dbReviewer.ReviewerProfiles.Find(id);

            if (reviewer == null)
            {
                return HttpNotFound();
            }

            return View(reviewer);
        }


        //
        // POST: /Admin/EditReviewer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReviewer(Reviewers reviewer)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbReviewer.Entry(reviewer).State = EntityState.Modified;
                    dbReviewer.SaveChanges();
                    return RedirectToAction("Reviewer", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(reviewer);
        }

        //
        // GET: /Admin/Donor
        public ActionResult Donor(String sortOrder, String searchString)
        {
            ViewBag.DonorIdSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DonorNameSortParam = sortOrder == "name" ? "name_desc" : "name";

            var donors = from d in dbDonor.DonorProfiles
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                donors = donors.Where(s => (s.NAME.Contains(searchString))).OrderBy(s => s.NAME);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "id_desc":
                    donors = donors.OrderByDescending(d => d.ID);
                    break;

                case "name":
                    donors = donors.OrderBy(d => d.NAME);
                    break;

                case "name_desc":
                    donors = donors.OrderByDescending(d => d.NAME);
                    break;

                default:
                    donors = donors.OrderBy(d => d.ID);
                    break;
            }
            #endregion

            return View(donors.ToList());
        }

        public ActionResult DonorInfo(int id = 1)
        {
            Donors donor = dbDonor.DonorProfiles.Find(id);

            if (donor == null)
            {
                return HttpNotFound();
            }

            return View(donor);
        }

        //
        // GET:  /Admin/CreateDonor
        public ActionResult CreateDonor()
        {
            return View();
        }

        //
        // POST: /Admin/CreateDonor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDonor(Donors donor)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbDonor.DonorProfiles.Add(donor);
                    dbDonor.SaveChanges();
                    return RedirectToAction("Donor", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(donor);
        }

        //
        // GET:  /Admin/EditDonor
        public ActionResult EditDonor(int id = 1)
        {
            Donors donor = dbDonor.DonorProfiles.Find(id);

            if (donor == null)
            {
                return HttpNotFound();
            }

            return View(donor);
        }


        //
        // POST: /Admin/EditDonor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDonor(Donors donor)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbDonor.Entry(donor).State = EntityState.Modified;
                    dbDonor.SaveChanges();
                    return RedirectToAction("Donor", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(donor);
        }

        //
        // GET:  /Admin/Criteria
        public ActionResult Criteria(String sortOrder, String searchString)
        {
            ViewBag.CriteriaIdSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DescrSortParam = sortOrder == "descr" ? "descr_desc" : "descr";

            var criterias = from c in dbCriteria.CriteriaProfiles
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                criterias = criterias.Where(s => (s.DESCR.Contains(searchString))).OrderBy(s => s.DESCR);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "id_desc":
                    criterias = criterias.OrderByDescending(c => c.ID);
                    break;

                case "descr":
                    criterias = criterias.OrderBy(c => c.DESCR);
                    break;

                case "descr_desc":
                    criterias = criterias.OrderByDescending(c => c.DESCR);
                    break;

                default:
                    criterias = criterias.OrderBy(c => c.ID);
                    break;
            }
            #endregion

            return View(criterias.ToList());
        }

        //
        // GET:  /Admin/CreateCriteria
        public ActionResult CreateCriteria()
        {
            return View();
        }

        //
        // POST: /Admin/CreateCriteria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCriteria(Criteria criteria)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbCriteria.CriteriaProfiles.Add(criteria);
                    dbCriteria.SaveChanges();
                    return RedirectToAction("Criteria", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(criteria);
        }

        //
        // GET:  /Admin/EditCriteria
        public ActionResult EditCriteria(int id = 1)
        {
            Criteria criteria = dbCriteria.CriteriaProfiles.Find(id);

            if (criteria == null)
            {
                return HttpNotFound();
            }

            return View(criteria);
        }


        //
        // POST: /Admin/EditCriteria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCriteria(Criteria criteria)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbCriteria.Entry(criteria).State = EntityState.Modified;
                    dbCriteria.SaveChanges();
                    return RedirectToAction("Criteria", "Admin");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                Console.WriteLine("Unable to save changes: " + dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(criteria);
        }

    }
}
