using Amino.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amino.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);

        IGenericRepository<Game> Games { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Platform> Platforms { get; }
        IGenericRepository<Customer> Customers { get; }

    }
}
