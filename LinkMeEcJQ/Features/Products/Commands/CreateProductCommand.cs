using FluentValidation;
using MediatR;

namespace LinkMeEcJQ.Features.Products.Commands
{
    public class CreateProductCommand : IRequest
    {
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
