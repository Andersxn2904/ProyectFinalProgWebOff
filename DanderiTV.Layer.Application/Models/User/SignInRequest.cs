using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiTV.Layer.Application.Models.User
{
    public class SignInRequest
    {

        [Required(ErrorMessage = "Username can't be empty")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Text)]

        public string Password { get; set; }
    }
}
