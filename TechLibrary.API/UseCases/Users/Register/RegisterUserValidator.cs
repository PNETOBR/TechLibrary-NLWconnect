using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatorio.");
        RuleFor(request => request.Email).EmailAddress().WithMessage("O Email não é valido.");
        RuleFor(request => request.Password).NotEmpty().WithMessage("A Senha é obrigatorio.");
        When(request => string.IsNullOrEmpty(request.Password) == false, () =>
        {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A Senha deve conter mais que 6 caracteres");
        });

        //NotEmpyt valida se o campo é nulo ou vazio / when é a função anonima que valida se a senha é nula ou vazia
    }
}
