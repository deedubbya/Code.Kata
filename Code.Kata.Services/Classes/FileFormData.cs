using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Kata.Services.Classes
{
    public class FileFormData
    {
        public string FormName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
