using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using susFaceGen.Areas.Identity.Data;
using susFaceGen.Data;
using susFaceGen.Models;
using susFaceGen.Models.ViewModels;
using susFaceGen.Services;
using System.Net.Mime;

namespace susFaceGen.Controllers
{
    [Authorize(Roles = "user, admin")]
    public class StatementController(susFaceGenContext context, UserManager<susFaceGenUser> userManager, OpenAiServices openAiServices, BlobServiceClient blobServiceClient) : Controller
    {
        susFaceGenContext _context = context;
        UserManager<susFaceGenUser> _userManager = userManager;
        OpenAiServices _openAiServices = openAiServices;
        BlobServiceClient _blobServiceClient = blobServiceClient;

        public IActionResult GenerateImage() => View(new GenerateImageVIewModel() 
        {   
            Case = new Case(),
            Statement = new Statement()
        });


        /*
         * This method is used to submit a case. 
         * It checks if the case already exists in the database. 
         * If the case exists, it checks if the user is authorized to update the case. 
         * If the user is authorized, it updates the case. 
         * If the case does not exist, it creates a new case and saves it to the database.
         */
        [HttpPost]
        public async Task<IActionResult> CaseDetails([FromForm] Case model)
        {
            if (ModelState.IsValid)
            {
                // Get the current user
                var user = await _userManager.GetUserAsync(User);
                // Check if the case already exists
                var existingCase = await _context.Case.Include(c => c.User).FirstOrDefaultAsync(c => c.CaseRefNum == model.CaseRefNum);
                if (existingCase != null)
                {
                    // Check if the user is authorized to update the case
                    if (existingCase.User.Id != _userManager.GetUserId(User))
                    {
                        TempData["msg"] = "Case exists. You are not authorized to update this case!";
                        TempData["alertType"] = "warning";
                        return View("GenerateImage", new GenerateImageVIewModel() { Case = new Case(), Statement = new Statement() });
                    }
                    // Update the case
                    existingCase.CaseLocation = model.CaseLocation;
                    existingCase.Date = model.Date;
                    existingCase.Description = model.Description;
                    existingCase.Status = model.Status;
                    existingCase.LastUpdatedDate = DateTime.Now;
                    _context.Case.Update(existingCase);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = "Case is updated. You can proceed to generate the image.";
                    TempData["alertType"] = "info";
                    return View("GenerateImage", new GenerateImageVIewModel() { Case = model, Statement = new Statement() { _caseId = existingCase.Id, Case = existingCase }, IsCaseSubmitted = true });
                }
                // Create a new case
                model.User = user;
                model._userId = user.Id;
                model.CreatedDate = DateTime.Now;
                model.LastUpdatedDate = DateTime.Now;

                // Save the case to the database
                await _context.Case.AddAsync(model);
                var result = await _context.SaveChangesAsync();
                TempData["msg"] = "Case submitted successfully. You can proceed to generate the image.";
                TempData["alertType"] = "success";

                // Get the newly created case
                var newCase = await _context.Case.FirstOrDefaultAsync(c => c.CaseRefNum == model.CaseRefNum);
                var newModel = new GenerateImageVIewModel() { Case = newCase, Statement = new Statement() { _caseId = newCase.Id, Case = newCase }, IsCaseSubmitted = true };
                return View("GenerateImage", newModel);
            }
               
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            foreach (var error in errors)
            {
                if (error.Key == "Date")
                {
                    ModelState.Remove("Date");
                    ModelState.AddModelError("Date", "Please choose a date.");
                }
            }
            /*     model.Case = new Case();*/
            return View("GenerateImage", new GenerateImageVIewModel() { Case = model, Statement = new Statement()});
        }

        /*
         * Ths method is used to generate an image based on the face features entered by the user.
         * The face features are passed to the OpenAI API to generate the image.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateImage(Statement model)
        {
            // Get the current user
            var existingCase = await _context.Case.FirstOrDefaultAsync(c => c.Id == model._caseId);
            if (ModelState.IsValid)
            {
                // Get the face features
                string faceFeatures = GetFaceFeatures(model);

                // Check if the face features are empty
                if (faceFeatures == "")
                {
                    return Json(new { success = false, message = "Please enter at least one feature to generate the image." });
                }
                else
                {
                    // Generate the image
                    string? imageUrl = await GetGeneretedImageUri(faceFeatures);
                    
                    if (imageUrl != null)
                    {
                        return Json(new { success = true, message = "Image generated successfully.", imageUrl = imageUrl });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Image generation failed. Please try again." });
                    }
                }

            }
            return Json(new { success = false, message = "Image generation failed. Please try again." });
        }

        /*
         * This method is used to search for a case in the database.
         */
        [HttpGet]
        public async Task<IActionResult> SearchCase(string query = "")
        {
            // If the query is not empty, search for the case in the database
            if (query != "")
            {
                // Get the case
                var existingCase = await _context.Case.Include(c => c.User).FirstOrDefaultAsync(c => c.CaseRefNum.ToLower() == query.ToLower() && c.IsDeleted == "N");
                if (existingCase != null)
                {
                    if (existingCase.User.Id != _userManager.GetUserId(User))
                    {
                        // Check if the user is authorized to view the case
                        TempData["msg"] = "You are not authorized to view this case.";
                        TempData["alertType"] = "warning";
                        return View("GenerateImage", new GenerateImageVIewModel() { Case = new Case(), Statement = new Statement() });
                    }
                    // Display the case details
                    TempData["msg"] = "Case found. You can proceed to generate the image.";
                    TempData["alertType"] = "info";
                    return View("GenerateImage", new GenerateImageVIewModel() { Case = existingCase, Statement = new Statement() { _caseId = existingCase.Id, Case = existingCase }, IsCaseSubmitted = true });
                }
            }
            // Display an error message if the case is not found
            TempData["msg"] = "Case not found. Please enter a valid case reference number or submit a new case.";
            TempData["alertType"] = "warning";
            return View("GenerateImage", new GenerateImageVIewModel() { Case = new Case(), Statement = new Statement() });
        }


        /*
         * This method is used to save the statement to the database.
         */
        [HttpPost]
        public async Task<IActionResult> Save(Statement model)
        {
            var statement = model;
            statement.Id = 0;
            var existingCase = await _context.Case.FirstOrDefaultAsync(c => c.Id == model._caseId);
            statement.Case = existingCase;
            statement._caseId = existingCase.Id;

            //auto generate a statement reference number
            statement.StatementRefNo = "STMT" + DateTime.Now.ToString("yyyyMMddHHmmss");

            statement.CreatedAt = DateTime.Now;

            // Save image to blob
            var image = await GetImageFromUri(model.ImgUrl);
            if (image != null)
            {
                var imageUrl = await UploadImageToBlob(image);
                if (imageUrl != null)
                {
                    statement.ImgUrl = imageUrl;
                }
            }

            // Save statement to database
            await _context.Statement.AddAsync(statement);
            await _context.SaveChangesAsync();

            TempData["imgUrl"] = GenerateUriWithSas(statement.ImgUrl);
            
            return Json(new { success = true, message = "Statement saved successfully." });


        }

        /*
         * This method is used to download the image from the URL and return it to the user.
         */
        [HttpPost]
        public async Task<IActionResult> Download(string url, string filetype)
        {
            // HttpClient is used to download the image from the URL
            var httpClient = new HttpClient();
            try
            {
                // Download the image
                var imageByte = await httpClient.GetByteArrayAsync(url);
                var contentDisposition = new ContentDisposition()
                {
                    FileName = "suspect_face_" + DateTime.Now + "." + filetype,
                    Inline = false
                };

                // Add the image to the response
                Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
                if (filetype == "jpg")
                    return File(imageByte, MediaTypeNames.Image.Jpeg);
                else
                    return File(imageByte, MediaTypeNames.Image.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Json(new { success = false, message = "Download failed. Please try again." });
            }
        }

        public IActionResult Success() => View();

        /*
         * This method is used to display the recent cases submitted by the user.
         */

        [HttpGet]
        public async Task<IActionResult> Recents(string query = "", int page = 1)
        {
            // Set the page size and skip
            ViewData["page"] = page;
            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (query == "")
            {
                // Get the recent cases
                var recents = await _context.Case.Include(c => c.StatementList).Skip(skip).Take(pageSize).Where(c => c.User == user && c.IsDeleted == "N").ToListAsync();
                // Get the total number of pages
                ViewData["totalPages"] = (int) Math.Ceiling((float) _context.Case.Count() / pageSize);
                return View(GetCasesWithSas(recents));
            }
            else
            {
                // Search for the case
                string sql = "SELECT * FROM [Case] WHERE (CaseRefNum LIKE '%" + query + "%' OR CaseLocation LIKE '%" + query + "%' OR Description LIKE '%" + query + "%' OR InvestigatingOfficerId LIKE '%" + query + "%') AND UserId = '"+ user.Id +"' AND IsDeleted = 'N'";
                var recents = await _context.Case.FromSqlRaw(sql).Include(c => c.StatementList).Skip(skip).Take(pageSize).ToListAsync();
                if (recents.Count == 0)
                {
                    // Display a message if the case is not found
                    TempData["message"] = "No search results found!";
                    recents = await _context.Case.Include(c => c.StatementList).Include(c => c.User).Skip(skip).Take(pageSize).Where(c => c.User == user && c.IsDeleted == "N").ToListAsync();
                    ViewData["totalPages"] = (int) Math.Ceiling((float) _context.Case.Count() / pageSize);
                    return View(GetCasesWithSas(recents));
                }
                ViewData["totalPages"] = 1;
                return View(GetCasesWithSas(recents));
            }
        }

        /*
         * This method is used to get the face features entered by the user.
         */
        private static string GetFaceFeatures(Statement model)
        {
            string faceFeatures = "";
            faceFeatures += model.Age == null ? "" : model.Age + " years old, ";
            faceFeatures += model.Gender == null ? "" : model.Gender + ", ";
            faceFeatures += model.Mouth == null ? "" : model.Mouth + " mouth, ";
            faceFeatures += model.Nose == null ? "" : model.Nose + " nose, ";
            faceFeatures += model.ShapeOfEyes == null ? "" : model.ShapeOfEyes + " eyes, ";
            faceFeatures += model.EyeBrows == null ? "" : model.EyeBrows + " eyebrows, ";
            faceFeatures += model.ColorTypeOfEyes == null ? "" : model.ColorTypeOfEyes + " eyecolor, ";
            faceFeatures += model.Face == null ? "" : model.Face + " face, ";
            faceFeatures += model.Complexion == null ? "" : model.Complexion + " complexion, ";
            faceFeatures += model.HairOnHead == null ? "" : model.HairOnHead + " hair, ";
            faceFeatures += model.FacialHair == null ? "" : model.FacialHair + " facial hair, ";
            faceFeatures += model.ColorOfHair == null ? "" : model.ColorOfHair + " hair color, ";
            faceFeatures += model.Forhead == null ? "" : model.Forhead + " forehead, ";
            faceFeatures += model.Ears == null ? "" : model.Ears + " ears, ";
            faceFeatures += model.Chin == null ? "" : model.Chin + " chin, ";
            faceFeatures += model.Teeth == null ? "" : model.Teeth + " teeth, ";
            faceFeatures += model.AdditionalDetails == null ? "" : " Additional details: " + model.AdditionalDetails;
            return faceFeatures;
        }

        /*
        * This method is used to generate an image based on the face features entered by the user.
        */
        private async Task<string?> GetGeneretedImageUri(string faceFeatures)
        {
            ImageGenService imageGenService = new ImageGenService(_openAiServices);
            var result = await imageGenService.GenerateImageAsync(faceFeatures);
           
            return result;
        }

        /*
        * This method is used to get the image from the URI.
        */
        private async Task<Stream?> GetImageFromUri(string uri)
        {
            var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(uri);
                return await response.Content.ReadAsStreamAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /*
         * This method is used to upload the image to the blob storage.
         */
        private async Task<string?> UploadImageToBlob(Stream image)
        {
            var container = _blobServiceClient.GetBlobContainerClient("generatedimages");
            var blob = container.GetBlobClient(Guid.NewGuid().ToString());
            try
            {
                await blob.UploadAsync(image);
                return blob.Uri.AbsoluteUri;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /*
         * This method is used to generate a URI with a Shared Access Signature (SAS) token.
         */
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

        /*
         * This method is used to get the cases with the SAS token.
         */
        private List<Case> GetCasesWithSas(List<Case> cases)
        {
            foreach (var c in cases)
            {
                foreach (var s in c.StatementList)
                {
                    s.ImgUrl = GenerateUriWithSas(s.ImgUrl);
                }
            }
            return cases;
        }
    }
}
