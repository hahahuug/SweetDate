using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SweetDate.Domain.ViewModel;
using SweetDate.Service.Interfaces;

namespace SweetDate.Controllers;

public class ProfilController : Controller
{
    private readonly IProfilService _profilService;
        
    public ProfilController(IProfilService profilService)
    {
        _profilService = profilService;
    }

    [HttpGet]
    public IActionResult Register() => View();

        [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var response = await _profilService.Register(registerViewModel);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("SearchHome","Person");
            }
            ModelState.AddModelError("", response.Description);
        }
        TempData["RegisterErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

        return RedirectToAction("Index", "Home"); 
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var response = await _profilService.Login(loginViewModel);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                // В случае успешного входа перенаправляем на SearchHome
                return RedirectToAction("SearchHome", "Person");
            }
            ModelState.AddModelError("", response.Description);
        }
        // Сохраняем ошибки валидации в TempData
        TempData["LoginErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

        return RedirectToAction("Index", "Home");
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

}