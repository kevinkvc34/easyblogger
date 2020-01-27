using Microsoft.EntityFrameworkCore;
using System;

namespace blog.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Post> Posts {get;set;}
    }
}