using DanderiTV.Layer.Application.Models.Director;
using DanderiTV.Layer.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<RegisterResponse> RegisterUserApp(RegisterRequest registerRequest);
        Task<UserAppContext> Login(SignInRequest signInRequest);

       
    }
}
