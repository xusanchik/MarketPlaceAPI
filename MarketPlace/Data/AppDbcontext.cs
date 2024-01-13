using MarketPlace.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace MarketPlace.Data;
public class AppDbcontext :IdentityDbContext<User>
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options, IServiceProvider services) : base(options)
    {
        this.Services = services;
    }
    public IServiceProvider Services { get; set; }
    public DbSet<Account > Accounts { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Food> Foodss { get; set; }
    public DbSet<FoodMarket> FoodMarkets { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AuditableEntity> AuditTable { get; set; }  


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Services));
    }
}
