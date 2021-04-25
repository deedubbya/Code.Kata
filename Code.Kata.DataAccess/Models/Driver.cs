using Code.Kata.DataAccess.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Code.Kata.DataAccess.Models
{
    public class Driver: IBaseDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
