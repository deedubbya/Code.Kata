using Code.Kata.DataAccess;
using Code.Kata.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Kata.Repositories
{
    public class TripRepository
    {
        private DriverContext _dbContext = new DriverContext();

        public List<Trip> GetAll()
        {
            var trips = new List<Trip>();
            try
            {
                if (_dbContext.Drivers.Any())
                {
                    trips = _dbContext.Trips.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error fetching trips list.");
            }
            return trips;
        }

        public int Add(int driverId, DateTime startTime, DateTime endTime, float miles)
        {
            var id = 0;
            try
            {
                var trip = new Trip
                {
                    DriverID = driverId,
                    StartTime = startTime,
                    EndTime = endTime,
                    MilesDriven = miles,
                    CreatedDateTime = DateTime.Now
                };
                _dbContext.Add(trip);
                _dbContext.SaveChanges();
                id = trip.ID;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Error adding record for trip of driver '{driverId}'");
            }
            return id;
        }
    }
}
