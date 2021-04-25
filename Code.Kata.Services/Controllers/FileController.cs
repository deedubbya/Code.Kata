using Code.Kata.Repositories;
using Code.Kata.Services.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Kata.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private DriverRepository _DriverRepository;
        private TripRepository _TripRepository;
       
        public FileController()
        {
            _DriverRepository = new DriverRepository();
            _TripRepository = new TripRepository();
        }

        [HttpPost]
        [Route("FileUpload")]
        public async Task<IActionResult> FileUpload([FromForm]FileFormData formData)
        {
            try
            {
                FileUploadResponse response = new FileUploadResponse();
                List<DatabaseCommand> commands = new List<DatabaseCommand>();
                using (var reader = new StreamReader(formData.FormFile.OpenReadStream()))
                {
                    while(reader.Peek() >= 0)
                    {
                        var str = await reader.ReadLineAsync();
                        if (str.Length > 0)
                        {
                            var strParts = str.Split(" ");
                            commands.Add(new DatabaseCommand {
                                Command = strParts[0],
                                Values = strParts.Skip(1).Take(4).ToList()
                            });
                        }
                    }
                }

                commands.OrderByDescending(c => c.Command.ToLower() == "driver").ThenBy(c => c.Command).ToList().ForEach(c =>
                {
                    if (c.Command.ToLower() == "driver" && c.Values.Any())
                    {
                        string errors = getDriverCommandErrors(c.Values);
                        if (errors.Length > 0)
                        {
                            c.Successful = false;
                            c.ErrorMessage = errors;
                        }
                        else
                        {
                            c.Successful = _DriverRepository.AddByName(c.Values[0]) > 0;
                        }
                    }
                    else if (c.Command.ToLower() == "trip" && c.Values.Any() && c.Values.Count() >= 4)
                    {
                        int driverId;
                        float miles;
                        DateTime startTime;
                        DateTime endTime;
                        string errors = getTripCommandErrors(c.Values, out driverId, out startTime, out endTime, out miles);
                        
                        if (errors.Length > 0)
                        {
                            c.Successful = false;
                            c.ErrorMessage = errors;
                        }
                        else
                        {
                            c.Successful = _TripRepository.Add(driverId, startTime, endTime, miles) > 0;
                        }
                    }
                });

                response.Commands = commands;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }

        private string getDriverCommandErrors(List<string> commandValues)
        {
            StringBuilder errors = new StringBuilder();
            if (_DriverRepository.GetIdByName(commandValues[0]) > 0)
            { 
                errors.AppendLine($"Driver '{commandValues[0]}' is already in the database.");
            }
            return errors.ToString();
        }

        private string getTripCommandErrors(List<string> commandValues, out int driverId, out DateTime startTime, out DateTime endTime, out float miles)
        {
            StringBuilder errors = new StringBuilder();
            driverId = _DriverRepository.GetIdByName(commandValues[0]);

            if(driverId <= 0)
            {
                errors.AppendLine($"Driver '{commandValues[0]}' does not exist in database.");
            }

            if (!DateTime.TryParse(commandValues[1], out startTime))
            {
                errors.AppendLine($"Start time '{commandValues[1]}' is in bad format.");
            }

            if (!DateTime.TryParse(commandValues[2], out endTime))
            {
                errors.AppendLine($"End time '{commandValues[2]}' is in bad format.");
            }

            if (float.TryParse(commandValues[3], out miles))
            {
                if (miles < 5f || miles > 100f) errors.AppendLine($"Miles must be in range between 5-100.");
            }
            else
            {
                errors.AppendLine($"Miles '{commandValues[3]}' is in bad format.");
            }

            return errors.ToString();
        }
    }
}
