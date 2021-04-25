using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Kata.Repositories.Classes
{
    public class DriverReportData
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public double Miles { get; set; }
        public double MilesPerHour { get; set; }
        public DriverReportData() {
            DriverId = 0;
            DriverName = string.Empty;
            Miles = 0;
            MilesPerHour = 0;
        }
    }
}
