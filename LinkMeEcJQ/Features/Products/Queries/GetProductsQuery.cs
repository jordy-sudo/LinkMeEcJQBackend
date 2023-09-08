using MediatR;
using System.Collections.Generic;

namespace LinkMeEcJQ.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductViewModel>>
    {
    }

    public class ProductViewModel
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
