using System;
using Microsoft.EntityFrameworkCore;
using api_test.Model;

namespace api_test.Database
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options ):base(options){}
        public DbSet<User> Users {get;set;}
        public DbSet<Post> Posts{get;set;}
        public DbSet<Comment> Comments{get;set;}
    }
}