using DanderiTV.Layer.Application.Helpers;
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.User;
using TrailersApp.Entity.Entities;


namespace DanderiTV.Layer.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrespository;
        private readonly sha256HashHelper Hasherpassword; 
        private readonly GetGUID getGUID;
        public UserService(IUserRepository repository) 
        { 
            getGUID = new();
            Hasherpassword = new();
            _userrespository = repository; 

        }

        public async Task<UserAppContext> Login(SignInRequest signInRequest)
        {
            UserAppContext UserResponse = new();
            UserResponse.HasError = false;
            signInRequest.Password = Hasherpassword.HashPassword( signInRequest.Password);


            var user = await _userrespository.GetUser(signInRequest);

            if (user == null)
            {
                UserResponse.Error = "This credentials was invalid, check it";
                UserResponse.HasError = true;
                return UserResponse;
            }

            UserResponse.ID = user.ID;
            UserResponse.UserName = user.UserName;
            UserResponse.Role = user.Role;

            return UserResponse;
        }


        public async Task<RegisterResponse> RegisterUserApp(RegisterRequest registerRequest)
        {
            RegisterResponse Response = new RegisterResponse();
            Response.HasError = false;

            bool UserExistByUsername = await _userrespository.GetUserByUsernameBOOLResponse(registerRequest.UserName);

            if (!UserExistByUsername)
            {
                Response.Error = "This username is already exist";
                Response.HasError = true;
                return Response;
            }

            User user = new()
            {
                ID = getGUID.GenerateGuidApp("#D@nd3rI"),
                UserName = registerRequest.UserName,
                Password = Hasherpassword.HashPassword(registerRequest.Password),
                Role = registerRequest.Role,
            };

            var userRegistered = await _userrespository.Add(user);

            return userRegistered != null ? Response : null;
        }

    }
}
