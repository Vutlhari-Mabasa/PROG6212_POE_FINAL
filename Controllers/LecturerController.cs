using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using PROG6212_Part1.Models;

namespace PROG6212_Part1.Controllers
{
    public class LecturerController : Controller
    {
        // Static list to store claims (shared between LecturerController and ProgrammeCoordinatorController)
        public static List<Claim> claims = new List<Claim>
        {
            new Claim { ClaimId = 1, Lecturer = "John Doe", HoursWorked = 8, HourlyRate = 50, Status = "Pending" },
            new Claim { ClaimId = 2, Lecturer = "Jane Smith", HoursWorked = 10, HourlyRate = 60, Status = "Pending" }
        };

        // Action to load the Submit and Track Claim page
        public IActionResult SubmitAndTrackClaim()
        {
            return View(claims); // Pass the claims data to the view
        }

        // POST: Action to handle claim submission
        [HttpPost]
        public IActionResult SubmitClaim(string lecturer, int hoursWorked, decimal hourlyRate, string notes, IFormFile document)
        {
            if (hoursWorked > 0 && hourlyRate > 0 && document != null)
            {
                // Generate a new claim ID based on the number of existing claims
                int newClaimId = claims.Count + 1;

                // Add new claim to the shared list
                claims.Add(new Claim
                {
                    ClaimId = newClaimId,
                    Lecturer = lecturer, // Store the lecturer's name
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    Notes = notes,
                    Status = "Pending" // Default status for new claims
                });

                // Redirect to the Submit and Track Claim page to show updated claims
                return RedirectToAction("SubmitAndTrackClaim");
            }
            else
            {
                // Return an error message if the input is invalid
                ViewBag.ErrorMessage = "Please enter valid hours, hourly rate, and upload a document.";
                return View("SubmitAndTrackClaim", claims);
            }
        }
    }
}

