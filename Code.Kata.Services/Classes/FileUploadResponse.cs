using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Kata.Services.Classes
{
    public class FileUploadResponse
    {
        public List<DatabaseCommand> Commands { get; set; }

        public FileUploadResponse()
        {
            Commands = new List<DatabaseCommand>();
        }
    }
}
