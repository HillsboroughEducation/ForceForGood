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

namespace HillsboroughEducation.Controllers {

 //   [Authorize(Roles = "Reviewer")]
    public class ReviewerController : Controller
    {
        private UsersContext db = new UsersContext();
        private ScholarshipContext dbScholarship = new ScholarshipContext();
        private ReviewerContext dbReviewer = new ReviewerContext();

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
        // GET: /Reviewer/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Reviewer/Index
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
        // GET: /Reviewer/ReviewerInfo
        public ActionResult ReviewerInfo()
        {
            return View();
        }

        //
        //POST: /Reviewer/ReviewerInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewerInfo(Reviewers reviewer)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbReviewer.ReviewerProfiles.Add(reviewer);
                    dbReviewer.SaveChanges();
                    return RedirectToAction("Index", "Reviewer");
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
        // GET: /Reviewer/EditReviewerInfo
        public ActionResult EditReviewerInfo(int id = 1)
        {
            Reviewers reviewer = dbReviewer.ReviewerProfiles.Find(id);

            if (reviewer == null)
            {
                return HttpNotFound();
            }

            return View(reviewer);
        }

        //
        // POST: /Reviewer/EditReviewerInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReviewerInfo(Reviewers reviewer)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbReviewer.Entry(reviewer).State = EntityState.Modified;
                    dbReviewer.SaveChanges();
                    return RedirectToAction("Index", "Reviewer");
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
        // GET: /Reviewer/CreateReviewerInfo
        public ActionResult CreateReviewerInfo()
        {
            return View();
        }

        //
        //POST: /Reviewer/CreateReviewerInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReviewerInfo(Reviewers reviewer)
        {
            var errors = GetRealErrors(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    dbReviewer.Entry(reviewer).State = EntityState.Modified;
                    dbReviewer.SaveChanges();
                    return RedirectToAction("Index", "Reviewer");
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
                scholarships = scholarships.Where(s => (s.TITLE.Contains(searchString)) ||
                                            (s.TYPE.Contains(searchString))).OrderBy(s => s.TITLE);
            }

            #region Sorting
            switch (sortOrder)
            {
                case "scholarship Name_desc":
                    scholarships = scholarships.OrderByDescending(s => s.TITLE);
                    break;

                case "Scholarship Type":
                    scholarships = scholarships.OrderBy(s => s.TYPE);
                    break;

                case "scholarship Type_desc":
                    scholarships = scholarships.OrderByDescending(s => s.TYPE);
                    break;

                case "Academic Year":
                    scholarships = scholarships.OrderBy(s => s.DATE_AVAILABLE.Year);
                    break;

                case "academic Year_desc":
                    scholarships = scholarships.OrderByDescending(s => s.DATE_AVAILABLE.Year);
                    break;

                default:
                    scholarships = scholarships.OrderBy(s => s.TITLE);
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