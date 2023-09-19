using System.Security.Claims;
using SweetDate.Domain.Response;
using SweetDate.Domain.ViewModel;

namespace SweetDate.Service.Interfaces;

public interface IProfilService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

}