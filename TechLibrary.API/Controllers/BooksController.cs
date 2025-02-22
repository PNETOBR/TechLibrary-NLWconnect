using Microsoft.AspNetCore.Mvc;
using TechLibrary.API.UseCases.Books.Filter;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;



namespace TechLibrary.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet("Filter")]
    [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]

    public IActionResult Filter(int pageNumber, string? title)
    {
        var useCase = new FilterBookUseCase();
        
        var request = new RequestFilterBooksJson
        {
            PageNumber = pageNumber,
            Title = title
        };

        var result = useCase.Execute(request);
        
        return Ok(result);
    }
}
