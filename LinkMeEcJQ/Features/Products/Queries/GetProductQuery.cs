using LinkMeEcJQ.Domain;
using MediatR;

public class GetProductQuery : IRequest<Product>
{
    public string ProductId { get; set; }
}