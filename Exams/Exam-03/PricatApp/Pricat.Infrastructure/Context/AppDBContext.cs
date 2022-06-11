using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pricat.Domain;
using Pricat.Domain.Entities;

#nullable disable

namespace Pricat.Infrastructure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> categories { get; set; }
        public virtual DbSet<Products> products { get; set; }

    }
}