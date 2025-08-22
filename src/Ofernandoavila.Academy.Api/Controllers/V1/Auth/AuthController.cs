using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ofernandoavila.Academy.API.ViewModels;
using Ofernandoavila.Academy.Business.Interfaces.Settings;

namespace Ofernandoavila.Academy.API.Controllers.V1.Auth
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v1")]
    public class AuthController(INotificator notificator,
                                IMapper mapper) : MainController(notificator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(model);
        }
    }
}
