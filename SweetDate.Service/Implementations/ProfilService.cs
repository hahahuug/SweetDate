using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SweetDate.DAL.Interfaces;
using SweetDate.Domain.Entity;
using SweetDate.Domain.Enum;
using SweetDate.Domain.Hash;
using SweetDate.Domain.Response;
using SweetDate.Domain.ViewModel;
using SweetDate.Service.Interfaces;

namespace SweetDate.Service.Implementations;

public class ProfilService : IProfilService
{
    private readonly IBaseRepository<Person> _personRepository;
    private readonly IBaseRepository<User> _userRepository;
    private readonly ILogger<ProfilService> _logger;
    
    public ProfilService(IBaseRepository<User> userRepository,
        ILogger<ProfilService> logger, IBaseRepository<Person> personRepository)
    {
        _userRepository = userRepository;
        _logger = logger;
        _personRepository = personRepository;
    }
    public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Username == model.Username);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "A user with this username already exists",
                };
            }

            user = new User()
            {
                Username = model.Username,
                Name = model.Name,
                Login = model.Login,
                Password = HashPassword.HashPassowrd(model.Password),
            };

            await _userRepository.Create(user);

            var person = new Person()
            {
                UserId = user.Id,
                Description = "-",
                Age = 18, 
                Gender = "-",
                Tg = "-",
                City = "-",
                LookingGender = "-",
                Country = "-",
                Avatar = "https://sun9-29.userapi.com/impg/LyRedDWXtEzye5GAjGgwQvBqJHpyK5S3p7BBwA/yWkB6U6pe4w.jpg?size=604x604&quality=95&sign=d96a317fca088cedb8ed190a561245c5&c_uniq_tag=iItB1_raY80BY_qtZrGwFwZihOSfMVpY6hDGGLMRrJQ&type=album"
            };
            
            

            await _personRepository.Create(person);
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Object added",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Register]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Username == model.Username);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "User not found"
                };
            }

            if (user.Password != HashPassword.HashPassowrd(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Invalid password or login"
                };
            }
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Login]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
        };
        return new ClaimsIdentity(claims, "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
}