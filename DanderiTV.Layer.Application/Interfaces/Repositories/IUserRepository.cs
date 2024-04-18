
using DanderiTV.Layer.Application.Models.User;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> GetUserByUsernameBOOLResponse(string Username);
        Task<User> GetUser(SignInRequest loginModel);
    }
}
