using FluentValidation;
using GamesProjectWeb.Logic.Common.Models;

namespace GamesProjectWeb.Logic.Validator
{
    public class LinkRequestValidator : AbstractValidator<LinkRequest>
    {
        public LinkRequestValidator()
        {
            RuleFor(link => link.Link).NotEmpty().NotNull();
        }
    }
}
