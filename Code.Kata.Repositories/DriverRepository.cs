using Code.Kata.DataAccess;
using Code.Kata.DataAccess.Models;
using Code.Kata.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Kata.Repositories
{
    public class DriverRepository
    {
        private DriverContext _dbContext = new DriverContext();

        public List<Driver> GetAll()
        {
            var drivers = new List<Driver>();
            try
            {
                if (_dbContext.Drivers.Any())
                {
                    drivers = _dbContext.Drivers.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error fetching drivers list.");
            }
            return drivers;
        }

        public List<DriverReportData> GetDriverReportData()
        {
            var reportDataList = new List<DriverReportData>();

            _dbContext.Drivers.ToList().ForEach(d =>
            {
                try
                {
                    var reportData = new DriverReportData() { DriverId = d.ID, DriverName = d.Name, Miles = 0d, MilesPerHour = 0d };
                    var trips = _dbContext.Trips.Where(t => t.DriverID == d.ID).ToList();
                    if (trips.Any())
                    {
                        var hours = 0d;

                        reportData.Miles = Math.Round(trips.Sum(t => t.MilesDriven), 1);

                        trips.ForEach(t =>
                        {
                            hours += (t.EndTime - t.StartTime).TotalHours;
                        });

                        reportData.MilesPerHour = Math.Round((reportData.Miles / hours), 1);
                    }
                    reportDataList.Add(reportData);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("Error fetching driver report data.");
                }
            });

            return reportDataList.OrderByDescending(d => d.Miles).ToList();
        }

        public int GetIdByName(string name)
        {
            var id = 0;
            var driver = _dbContext.Drivers.Where(d => d.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if(driver != null)
            {
                id = driver.ID;
            }
            return id;
        }

        public int UpsertByName(string name)
        {
            var id = 0;
            var driver = _dbContext.Drivers.Where(d => d.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if(driver != null)
            {
                id = UpdateByName(name);
            }
            else
            {
                id = AddByName(name);
            }
            return id;
        }

        public int AddByName(string name)
        {
            var id = 0;
            try
            {
                var driver = new Driver { Name = name, CreatedDateTime = DateTime.Now };
                _dbContext.Add(driver);
                _dbContext.SaveChanges();
                id = driver.ID;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Error adding record for driver '{name}'.");
            }
            return id;
        }

        public int UpdateByName(string name)
        {
            var id = 0;
            try
            {
                var driver = _dbContext.Drivers.Where(d => d.Name.ToLower() == name.ToLower()).FirstOrDefault();
                driver.Name = name;
                driver.UpdatedDateTime = DateTime.Now;
                _dbContext.SaveChanges();
                id = driver.ID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Error updating record for driver '{name}'.");
            }
            return id;
        }

        public bool DeleteByName(string name)
        {
            try
            {
                var driver = _dbContext.Drivers.Where(d => d.Name.ToLower() == name.ToLower()).FirstOrDefault();
                _dbContext.Drivers.Remove(driver);
                _dbContext.SaveChanges();
            }   
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Error deleting record for driver '{name}'.");
            }
            return true;
        }
    }
}
