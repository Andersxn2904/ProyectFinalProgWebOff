
using System.ComponentModel.DataAnnotations;


namespace DanderiTV.Layer.Application.Models.User
{
    public class SignInResponse
    {
        public string UserName { get; set; }
        public string Role {  get; set; }
        public string Password { get; set; }
       public bool? HasError { get; set; }
       public string? Error { get; set; }
    }
}
