using Microsoft.EntityFrameworkCore;
using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Persistence;

public class ECommerceDbContext : DbContext
{
    public virtual DbSet<Order> Orders { get; set; }
}