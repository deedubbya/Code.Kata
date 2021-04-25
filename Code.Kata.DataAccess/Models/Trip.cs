using Code.Kata.DataAccess.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Kata.DataAccess.Models
{
    public class Trip : IBaseDataModel
    {
        public int ID { get; set; }
        public int DriverID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float MilesDriven { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
