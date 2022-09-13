using BloodManagementSystem.Core.Interface;
using BloodManagementSystem.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IBlood _context;
        public BloodController(IBlood _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> DisplayAllDonars()
        {
            try
            {
                var result =_context.DisplayAllDonars();
                log.Info("Data is Displayed");
                return StatusCode(200,result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDonar(SchoolModel schoolModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddDonar(schoolModel);
                    log.Error("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
    }
}