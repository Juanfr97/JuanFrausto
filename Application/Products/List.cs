using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<List<Product>> 
        {
            public DateTime From { get; set; }
            public DateTime To { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly ApplicationDbContext _dataContext;

            public Handler(ApplicationDbContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Products.Where(p=>p.ExpirationDate>=request.From&&p.ExpirationDate<=request.To).ToListAsync();
            }
        }
    }
}
