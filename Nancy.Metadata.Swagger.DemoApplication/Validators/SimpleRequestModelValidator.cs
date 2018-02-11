using FluentValidation;
using Nancy.Metadata.Swagger.DemoApplication.Model;

namespace Nancy.Metadata.Swagger.DemoApplication.Validators
{
    public class SimpleRequestModelValidator : AbstractValidator<SimpleRequestModel>
    {
        public SimpleRequestModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
