﻿using Microsoft.EntityFrameworkCore;
using SoftTechChallenge.Infraestructure.Models;


namespace SoftTechChallenge.Infraestructure.Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}