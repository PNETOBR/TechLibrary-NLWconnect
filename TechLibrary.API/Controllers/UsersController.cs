using Microsoft.AspNetCore.Mvc;
using TechLibrary.API.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.API.Controllers;

[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

    public IActionResult Register(RequestUserJson request)
    {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
    }

}
