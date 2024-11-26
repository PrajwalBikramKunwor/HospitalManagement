﻿using HospitalManagement.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccessLayer.DataContext;
public class HospitalManagementContext : DbContext
{

    public HospitalManagementContext()
    {
    }
    public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options) : base(options)
    {

    }
    // public DbSet<Staff> Staff { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<MenuHeader> MenuHeader { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Banner> Banner { get; set; }
    public DbSet<ColorImages> ColorImages { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            object value = optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
