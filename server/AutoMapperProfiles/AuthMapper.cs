using AutoMapper;
using CookBook.API.Requests.AuthController;
using CookBook.API.Responses.AuthController;
using CookBook.Domain;
using CookBook.Domain.AuthController;

namespace CookBook.AutoMapperProfiles
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            // Requests
            CreateMap<LoginRequest, LoginData>();
            CreateMap<ChangeCurrentUserPasswordRequest, PasswordChangeData>();
            CreateMap<LogoutRequest, LogoutData>();
            CreateMap<RefreshRequest, RefreshData>();
            CreateMap<RegisterRequest, RegisterData>();

            // Responses
            CreateMap<AuthResult, AuthSuccessResponse>();
            CreateMap<AuthResult, AuthFailedResponse>();
        }
    }
}