using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using Ofernandoavila.Academy.Business.Interfaces.Settings;
using Ofernandoavila.Academy.Business.Models.Settings;

namespace Ofernandoavila.Academy.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        
        public MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if(!modelState.IsValid)
                NotificateInvalidModelError(modelState);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if(!_notificator.HasNotification())
            {
                return Ok(result);
            }

            return BadRequest(new { errors = _notificator.GetNotifications().Select( n => n.Message) });

        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode, object result = null)
        {
            return statusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.Created => CreatedAtAction("GetById", result),
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.NotFound => NotFound(),
                HttpStatusCode.BadRequest => BadRequest(),
                _ => throw new NotImplementedException($"Status code { statusCode } not implemented!")
            };
        }

        protected void NotificateInvalidModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception is null ? error.ErrorMessage : error.Exception.Message;
                NotificateError(errorMessage);
            }
        }

        protected void NotificateError(string errorMessage)
        {
            _notificator.Handle(new Notification(errorMessage));
        }
    }
}
