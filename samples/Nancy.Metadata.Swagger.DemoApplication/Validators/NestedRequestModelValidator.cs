using FluentValidation;
using Nancy.Metadata.Swagger.DemoApplication.Model;

namespace Nancy.Metadata.Swagger.DemoApplication.Validators
{
    public class NestedRequestModelValidator : AbstractValidator<NestedRequestModel>
    {
        public NestedRequestModelValidator()
        {
            RuleFor(x => x.SimpleModel.Name).NotEmpty().NotNull();
        }
    }
}
