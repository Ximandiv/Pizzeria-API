using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.Data;

public class PizzeriaContext : DbContext
{
    public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
        : base(options) { }

    public DbSet<Domain.Entities.Pizza.Pizza> Pizzas { get; set; } 
}
