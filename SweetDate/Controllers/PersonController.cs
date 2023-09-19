using Microsoft.AspNetCore.Mvc;
using SweetDate.DAL.Interfaces;
using SweetDate.Domain.Entity;
using SweetDate.Domain.ViewModel;
using SweetDate.Service.Interfaces;

namespace SweetDate.Controllers;

public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<IActionResult> Save(PersonViewModel model)
    {
        ModelState.Remove("Id");
        ModelState.Remove("UserName");
        if (ModelState.IsValid)
        {
            var response = await _personService.Save(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Json(new { description = response.Description });
            }
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
        
    public async Task<IActionResult> Detail()
    {
        var userName = User.Identity.Name;
        var response = await _personService.GetPerson(userName);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);   
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var userName = User.Identity.Name;
        var response = await _personService.GetPerson(userName);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }
        return View("NotFoundView");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PersonViewModel model)
    {
        if (ModelState.IsValid)
            Console.WriteLine(ModelState.IsValid);
        {
            var userName = User.Identity.Name;
            var response = await _personService.GetPerson(userName);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var personViewModel = response.Data;
                personViewModel.Age = model.Age;
                personViewModel.Gender = model.Gender;
                personViewModel.LookingGender = model.LookingGender;
                personViewModel.Description = model.Description;
                personViewModel.City = model.City;
                personViewModel.Country = model.Country;
                personViewModel.Avatar = model.Avatar;
                personViewModel.Tg = model.Tg;

                var saveResponse = await _personService.Save(personViewModel);

                if (saveResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return RedirectToAction("Detail");
                }
            }
            else
            {
                return View("NotFoundView");
            }
        }
        
        return View("EditNotValidView");
    }
    
    [HttpGet]
    public IActionResult SearchHome()
    {
        if (TempData.ContainsKey("LoginErrors"))
        {
            var loginErrors = TempData["LoginErrors"] as List<string>;
            if (loginErrors != null && loginErrors.Any())
            {
                foreach (var error in loginErrors)
                {
                    ModelState.AddModelError("", error);
                }
            }
        }
        return View(new SearchViewModel());
    }

    [HttpPost]
    public IActionResult SearchHome(SearchViewModel model)
    {
        if (ModelState.IsValid)
        {
            var searchResults = _personService.SearchPerson(model);
            
            return View("SearchPerson", searchResults);
        }

        return View("EditNotValidView");
    }
    
    



    // [HttpGet]
    // public IActionResult GetLatestUsers()
    // {
    //     var latestUsers = _personService.GetLatestUsers(3); // Получаем последних 3 пользователя
    //     return View("LatestUsers", latestUsers); // Передаем список пользователей в представление
    // }
}