using FluentValidation;
using MediatR;

namespace LinkMeEcJQ.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
