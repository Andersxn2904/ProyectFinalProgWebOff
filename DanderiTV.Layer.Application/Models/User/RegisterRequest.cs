
namespace DanderiTV.Layer.Application.Models.User
{
    public class RegisterRequest
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
