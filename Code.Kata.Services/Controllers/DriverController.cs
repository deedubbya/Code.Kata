using Code.Kata.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Kata.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private DriverRepository _repository;

        public DriverController()
        {
            _repository = new DriverRepository();
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var drivers = _repository.GetAll();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetDriverReportData")]
        public IActionResult GetDriverReportData()
        {
            try
            {
                var reportDataList = _repository.GetDriverReportData();
                return Ok(reportDataList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("AddByName")]
        public IActionResult AddByName(string name)
        {
            try
            {
                var driverId = _repository.UpsertByName(name);
                return Ok(driverId);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }
    }
}
