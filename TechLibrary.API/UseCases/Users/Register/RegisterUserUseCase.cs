using FluentValidation.Results;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.API.Domain.Entities;
using TechLibrary.API.Infraestructure.DataAccess;
using TechLibrary.API.Infraestructure.Security.Cryptography;
using TechLibrary.API.Infraestructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.API.UseCases.Users.Register;
public class RegisterUserUseCase 
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request)
     {
        var dbContext = new TechLibraryDbContext();

        Validate(request, dbContext);

        var cryptography = new BCryptAlgorithm();

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = cryptography.HashPassword(request.Password),
        };

        dbContext.Users.Add(entity);
        dbContext.SaveChanges();

        var tokenGenerator = new JwtTokenGenerator(); //break

        return new ResponseRegisteredUserJson
        {
            Name = entity.Name,
            AcessToken = tokenGenerator.Generate(entity)
        };
    }

    private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals (request.Email));

        if (existUserWithEmail)
            result.Errors.Add(new ValidationFailure("Email", "Esse Email ja existe!"));


        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);

        }
    }
}
