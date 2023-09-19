using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SweetDate.DAL.Interfaces;
using SweetDate.Domain.Entity;
using SweetDate.Domain.Enum;
using SweetDate.Domain.Response;
using SweetDate.Domain.ViewModel;
using SweetDate.Service.Interfaces;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SweetDate.Service.Implementations;

public class PersonService : IPersonService
{
    private readonly ILogger<PersonService> _logger;
    private readonly IBaseRepository<Person> _personRepository;


    public PersonService(IBaseRepository<Person> personRepository, ILogger<PersonService> logger)
    {
        _personRepository = personRepository;
        _logger = logger;
    }

    public async Task<IBaseResponse<PersonViewModel>> GetPerson(string userName)
    {
        try
        {
            var person = await _personRepository.GetAll()
                .Select(x => new PersonViewModel()
                {
                    Id = x.Id,
                    Gender = x.Gender,
                    LookingGender = x.LookingGender,
                    Age = x.Age,
                    Description = x.Description,
                    City = x.City,
                    Country = x.Country,
                    Avatar = x.Avatar,
                    UserName = x.User.Username
                })
                .FirstOrDefaultAsync(x => x.UserName == userName);

            return new BaseResponse<PersonViewModel>()
            {
                Data = person,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[ProfileService.GetProfile] error: {ex.Message}");
            return new BaseResponse<PersonViewModel>()
            {
                StatusCode = StatusCode.InternalServerError,
                Description = $"Внутренняя ошибка: {ex.Message}"
            };
        }
    }

    public async Task<BaseResponse<Person>> Save(PersonViewModel model)
        {
            try
            {
                var person = await _personRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);
                
                person.Description = model.Description;
                person.Age = model.Age;
                person.Gender = model.Gender;
                person.Tg = model.Tg;
                person.City = model.City;
                person.LookingGender = model.LookingGender;
                person.Country = model.Country;
                person.Avatar = model.Avatar;

                /*
                if (imageData != null)
                {
                    person.Avatar = imageData;
                }*/

                await _personRepository.Update(person);

                return new BaseResponse<Person>()
                {
                    Data = person,
                    Description = "Data updated",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ProfileService.Save] error: {ex.Message}");
                return new BaseResponse<Person>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    
    public IEnumerable<PersonViewModel> SearchPerson(SearchViewModel searchParameters)
    {
        var query = _personRepository.GetAll();

        if (!string.IsNullOrEmpty(searchParameters.LookingGender))
        {
            
            query = query.Where(x => x.Gender == searchParameters.LookingGender);
        }

        if (searchParameters.AgeFrom > 0)
        {
            query = query.Where(x => x.Age <= searchParameters.AgeTo && x.Age >= searchParameters.AgeFrom);
        }

        if (!string.IsNullOrEmpty(searchParameters.City))
        {
            query = query.Where(x => x.City.Contains(searchParameters.City));
        }
        
        Debug.WriteLine("LookingGender: " + searchParameters.LookingGender);
        Debug.WriteLine("AgeFrom: " + searchParameters.AgeFrom);
        Debug.WriteLine("AgeTo: " + searchParameters.AgeTo);
        Debug.WriteLine("City: " + searchParameters.City);
        Debug.WriteLine("SQL Query: " + query.ToQueryString());
        
        var searchResults = query.Select(x => new PersonViewModel
        {
            Name = x.User.Name,
            Age = x.Age,
            City = x.City,
            Country = x.Country,
            Description = x.Description,
            Avatar = x.Avatar
        }).ToList();

        return searchResults;
    }





        // public List<Person> GetLatestUsers(int count)
        // {
        //     var latestUsers = _personRepository.GetAll()
        //         .OrderByDescending(user => user.DateCreate) 
        //         .Take(count) 
        //         .ToList();
        //
        //     return latestUsers;
        // }
}