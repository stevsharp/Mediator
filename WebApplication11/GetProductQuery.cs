using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication11
{

    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }

    }

    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
