using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Kata.Services.Classes
{
    public class DatabaseCommand
    {
        public string Command { get; set; }
        public List<string> Values { get; set; }
        public bool Successful { get; set; }

        public string ErrorMessage { get; set; }

        public DatabaseCommand()
        {
            Values = new List<string>();
        }
    }
}
