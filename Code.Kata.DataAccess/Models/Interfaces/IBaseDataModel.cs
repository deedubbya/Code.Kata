using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Kata.DataAccess.Models.Interfaces
{
    interface IBaseDataModel
    {
        int ID { get; set; }
        DateTime CreatedDateTime { get; set; }
        DateTime UpdatedDateTime { get; set; }
    }
}
