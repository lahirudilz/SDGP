using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using susFaceGen.Areas.Identity.Data;
using susFaceGen.Data;
using susFaceGen.Models;

namespace susFaceGen.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController(UserManager<susFaceGenUser> userManager, susFaceGenContext dataContext) : Controller
    {

        UserManager<susFaceGenUser> _userManager = userManager;

        private readonly susFaceGenContext _db = dataContext;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserList(string query = "", int page = 1)
        {

            ViewData["page"] = page;
            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            if (query == "")
            {
                var users = await _userManager.Users.Skip(skip).Take(pageSize).ToListAsync();

                var count = (int)Math.Ceiling((double)_userManager.Users.Count() / pageSize);

                ViewData["totalPages"] = count;
                return View(users);
                /*return Json(users);*/
            }
            else
            {
                var users = _userManager.Users;

                var result = await users.Where(u => u.UserName.Contains(query) || u.Email.Contains(query)).Skip(skip).Take(pageSize).ToListAsync();


                if (result.Count() == 0)
                {
                    TempData["message"] = "No search results found!";

                    ViewData["totalPages"] = (int)Math.Ceiling((double)_userManager.Users.Count() / pageSize);
                    return View(users);
                    /*return Json(users);*/
                }

                ViewData["totalPages"] = (int)Math.Ceiling((double)users.Count() / pageSize);
                return View(result);
                /*return Json(users);*/

            }
        }

        /**
        * Get all the ongoing cases or get the queried results
        */

        [HttpGet]
        public async Task<IActionResult> CaseList(string query = "", int page = 1)
        {

            ViewData["page"] = page;
            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            if (query == "")
            {
                var caseList = await _db.Case.Include(c => c.StatementList).Where(x => x.IsDeleted == "N").Skip(skip).Take(pageSize).ToListAsync();

                var count = (int)Math.Ceiling((double)_db.Case.Include(c => c.StatementList).Where(x => x.IsDeleted == "N").Count() / pageSize);

                ViewData["totalPages"] = count;
                return View(caseList);
            }
            else
            {
                var caseList = await _db.Case.Include(c => c.StatementList).Where(x => x.IsDeleted == "N" && (x.CaseRefNum.Contains(query) || x.CaseLocation.Contains(query) || x.Description.Contains(query) || x.InvestigatingOfficerId.Contains(query) || x.Status.Contains(query))).Skip(skip).Take(pageSize).ToListAsync();

                var count = (int)Math.Ceiling((double)_db.Case.Include(c => c.StatementList).Where(x => x.IsDeleted == "N" && (x.CaseRefNum.Contains(query) || x.CaseLocation.Contains(query) || x.Description.Contains(query) || x.InvestigatingOfficerId.Contains(query) || x.Status.Contains(query))).Count() / pageSize);

                ViewData["totalPages"] = count;

                if (count == 0)
                {
                    TempData["msg"] = "No search results found!";
                    caseList = await _db.Case.Include(c => c.StatementList).Where(x => x.IsDeleted == "N").Skip(skip).Take(pageSize).ToListAsync();
                }

                return View(caseList);
            }
        }

        /**
        * View the case details
        */
        public async Task<IActionResult> ViewCase(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var caseFromDb = await _db.Case.Include(c => c.StatementList).Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);

            if (caseFromDb == null)
            {
                return NotFound();
            }

            foreach (var s in caseFromDb.StatementList)
            {
                s.ImgUrl = GenerateUriWithSas(s.ImgUrl);
            }

            return View(caseFromDb);
        }

        /**
        * Delete the case details
        */

        [HttpGet]
        public async Task<IActionResult> DeleteCase(int? id)
        {
            var _case = await _db.Case.FindAsync(id);

            if (_case == null)
            {
                return NotFound();
            }
            if (_case.IsDeleted.Equals("Y"))
            {
                TempData["msg"] = "Case already deleted.";
                return RedirectToAction("Index");
            }

            _case.IsDeleted = "Y";
            _case.LastUpdatedDate = DateTime.Now;

            _db.Case.Update(_case);
            _db.SaveChanges();

            TempData["msg"] = "Case deleted successfully.";

            return RedirectToAction("CaseList");

        }
        
        /**
        * Get the count of the cases
        */
        public async Task<IActionResult> GetCaseCount()
        {
            var caseCount = await _db.Case.Where(c => c.IsDeleted == "N").CountAsync();
            return Json(caseCount);
        }
        
        /**
        * Get the count of images
        */
        public async Task<IActionResult> GetImageCount()
        {
            var imageCount = await _db.Statement.CountAsync();
            return Json(imageCount);
        }
        private string GenerateUriWithSas(string uri)
        {
            var blob = new BlobClient(new Uri(uri));
            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };
            sasBuilder.SetPermissions(BlobSasPermissions.Read);
            var sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(Environment.GetEnvironmentVariable("storageaccount"), Environment.GetEnvironmentVariable("storagekey")));
            return blob.Uri + "?" + sasToken;
        }
    }
}
