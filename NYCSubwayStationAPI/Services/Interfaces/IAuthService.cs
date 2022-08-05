using Microsoft.AspNetCore.Mvc;
using NYCSubwayStationAPI.Models;

namespace NYCSubwayStationAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<object> Login(LoginModel model);
        public Task<bool> Register(RegistrationModel model);
        public Task<bool> RegisterAdmin(RegistrationModel model);
    }
}
