using Domain;
using MediatR;
using Persitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Barcode { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int YearProduction { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string Review { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _dataContext;

            public Handler(ApplicationDbContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var value = new Product()
                {
                    Barcode = request.Barcode,
                    Name = request.Name,
                    Category = request.Category,
                    YearProduction = request.YearProduction,
                    ExpirationDate = request.ExpirationDate,
                    Review = request.Review,
                };
                _dataContext.Products.Add(value);
                if (await _dataContext.SaveChangesAsync() > 0) return Unit.Value;
                throw new Exception("Problemas guardando los cambios");
            }
        }
    }
}
