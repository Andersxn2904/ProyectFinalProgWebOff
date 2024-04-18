using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiTV.Layer.Application.Models.User
{
    public class RegisterResponse
    {
        public string Username { get; set; }
        public bool HasError { get; set; }
        public string Error{ get; set; }
    }
}
