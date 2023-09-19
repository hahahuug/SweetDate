using SweetDate.Domain.Entity;
using SweetDate.Domain.Response;
using SweetDate.Domain.ViewModel;

namespace SweetDate.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<User>> Create(UserViewModel model);

    Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        
    Task<IBaseResponse<bool>> DeleteUser(long id);
}