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
    public class TripController : Controller
    {
        private TripRepository _repository;

        public TripController()
        {
            _repository = new TripRepository();
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var trips = _repository.GetAll();
                return Ok(trips);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add(int driverId, DateTime startTime, DateTime endTime, float miles)
        {
            try
            {
                var tripId = _repository.Add(driverId, startTime, endTime, miles);
                return Ok(tripId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }
    }
}
