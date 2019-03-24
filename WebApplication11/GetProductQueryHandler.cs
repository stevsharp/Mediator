using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication11
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, Product>
    {
        private readonly NorthwindDbContext _context;
      
        public GetProductQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Set<Product>()
                .Where(p => p.ProductId == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return product;
        }
    }

    public class GetAllProductsQueryHandler : MediatR.IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly NorthwindDbContext _context;

        public GetAllProductsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Set<Product>()
                        .OrderBy(p => p.ProductName)
                        .ToListAsync(cancellationToken);

            return products;
        }
    }
}
