using System.Collections.Generic;
using System.Linq;
using BlazoredRepairs.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazoredRepairs.Server.Controllers
{
    [Authorize]
    [ApiController, Route("api")]
    public class RepairsController : Controller
    {
        private static List<RepairModel> _repairs = new List<RepairModel>
        {
            new RepairModel{
                Name = "Jane Smith",
                Issue = "Broken boiler",
                Trade = "Gas",
                ContactNumber = "07656 545432",
                Complete = false
            },
            new RepairModel{
                Name = "Ron Jameson",
                Issue = "Fence panel missing",
                Trade = "Carpenter",
                ContactNumber = "07865 344223",
                Complete = false
            },
            new RepairModel{
                Name = "Terri Jones",
                Issue = "Leaking tap",
                Trade = "Plumber",
                ContactNumber = "01453 453423",
                Complete = false
            },
            new RepairModel{
                Name = "Andy Sturgen",
                Issue = "Roof blown off",
                Trade = "Roofer",
                ContactNumber = "01456 454534",
                Complete = true
            },
            new RepairModel{
                Name = "Brook Giles",
                Issue = "Cracked Window",
                Trade = "Window Fitter",
                ContactNumber = "01465 343558",
                Complete = true
            },
            new RepairModel{
                Name = "Billy Jenson",
                Issue = "Broken tap in bathroom",
                Trade = "Plumber",
                ContactNumber = "07865 344223",
                Complete = true
            },
            new RepairModel{
                Name = "Jim Kipson",
                Issue = "Plug socket not working",
                Trade = "Electrician",
                ContactNumber = "07465 343445",
                Complete = true
            },
            new RepairModel{
                Name = "Kim Fallon",
                Issue = "Shed collapsed",
                Trade = "Carpenter",
                ContactNumber = "01234 345678",
                Complete = true
            }

        };

        [HttpGet("repairs")]
        public IActionResult GetAllRepairs()
        {
            return Ok(_repairs.OrderBy(x => x.Complete));
        }

        [HttpPost("repairs")]
        public IActionResult NewRepair(RepairModel newRepair)
        {
            _repairs.Add(newRepair);
            return Ok();
        }
    }
}