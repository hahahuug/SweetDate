using Microsoft.AspNetCore.Http;
using SweetDate.Domain.Entity;
using SweetDate.Domain.Response;
using SweetDate.Domain.ViewModel;

namespace SweetDate.Service.Interfaces;

public interface IPersonService
{

    Task<IBaseResponse<PersonViewModel>> GetPerson(string userName);

    Task<BaseResponse<Person>> Save(PersonViewModel model);

    IEnumerable<PersonViewModel> SearchPerson(SearchViewModel searchParameters);
}